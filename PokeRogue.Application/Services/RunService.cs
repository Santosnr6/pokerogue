using PokeRogue.Application.Interfaces;
using PokeRogue.Application.Models;
using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;
using PokeRogue.Domain.Services;

namespace PokeRogue.Application.Services
{
    public class RunService : IRunService
    {
        private readonly IRunRepository _runRepository;
        private readonly IRunMapService _runMapService;
        private readonly IRunMapRepository _runMapRepository;
        private readonly IRunPokemonRepository _runPokemonRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPokemonCenterService _pokemonCenterService;

        public RunService(
            IRunRepository runRepository,
            IRunMapService runMapService,
            IRunMapRepository runMapRepository,
            IRunPokemonRepository runPokemonRepository,
            IPokemonRepository pokemonRepository,
            IPokemonCenterService pokemonCenterService
        )
        {
            _runRepository = runRepository;
            _runMapService = runMapService;
            _runMapRepository = runMapRepository;
            _runPokemonRepository = runPokemonRepository;
            _pokemonRepository = pokemonRepository;
            _pokemonCenterService = pokemonCenterService;
        }

        public async Task<Run> StartNewAsync()
        {
            var run = new Run
            {
                CurrentCity = 1,
                CurrentNodeId = 1,
                RunStatus = RunStatus.InProgress,
                StartedAt = DateTime.UtcNow
            };

            run =
                await _runRepository.CreateAsync(
                    run
                );

            var generatedMap =
                _runMapService.CreateRunMap(
                    run.Id,
                    run.CurrentCity
                );

            await _runMapRepository.SaveRunNodesAsync(
                generatedMap.RunNodes
            );

            return run;
        }

        public async Task<Run?> GetRunAsync(
            int id
        )
        {
            return await _runRepository.GetByIdAsync(
                id
            );
        }

        public async Task<MoveResult?> MoveToNodeAsync(
            int runId,
            int targetNodeId
        )
        {
            var run =
                await _runRepository.GetByIdAsync(
                    runId
                );

            if (run == null)
            {
                return null;
            }

            bool hasPokemon =
                await _runPokemonRepository
                    .RunHasPokemonAsync(
                        runId
                    );

            if (!hasPokemon)
            {
                throw new InvalidOperationException(
                    "You must choose a starter before moving."
                );
            }

            var currentRunNode =
                await _runMapRepository.GetRunNodeAsync(
                    runId,
                    run.CurrentNodeId
                );

            if (currentRunNode != null &&
                !currentRunNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "You must complete the current event before moving."
                );
            }

            bool canMove =
                await _runMapRepository.ConnectionExistsAsync(
                    run.CurrentNodeId,
                    targetNodeId
                );

            if (!canMove)
            {
                throw new InvalidOperationException(
                    "You cannot move to that node."
                );
            }

            var targetRunNode =
                await _runMapRepository.GetRunNodeAsync(
                    runId,
                    targetNodeId
                );

            if (targetRunNode == null)
            {
                throw new InvalidOperationException(
                    "No event exists on that node."
                );
            }

            run.CurrentNodeId =
                targetNodeId;

            await _runRepository.SaveChangesAsync();

            if (targetRunNode.Type ==
                NodeEventType.PokemonCenter)
            {
                await _pokemonCenterService.HealAsync(
                    runId
                );
            }

            return new MoveResult
            {
                CurrentNodeId =
                    targetNodeId,

                EventType =
                    targetRunNode.Type
            };
        }

        public async Task<RunPokemon?> ChooseStarterAsync(
            int runId,
            int pokemonSpeciesId
        )
        {
            var run =
                await _runRepository.GetByIdAsync(
                    runId
                );

            if (run == null)
            {
                return null;
            }

            bool alreadyHasPokemon =
                await _runPokemonRepository
                    .RunHasPokemonAsync(
                        runId
                    );

            if (alreadyHasPokemon)
            {
                throw new InvalidOperationException(
                    "A starter has already been chosen."
                );
            }

            var species =
                await _pokemonRepository.GetByIdAsync(
                    pokemonSpeciesId
                );

            if (species == null ||
                !species.IsStarter)
            {
                throw new InvalidOperationException(
                    "That Pokémon is not a valid starter."
                );
            }

            const int starterLevel = 5;

            int maxHp =
                PokemonStatCalculator.CalculateHp(
                    species,
                    starterLevel
                );

            var runPokemon =
                new RunPokemon
                {
                    RunId =
                        runId,

                    PokemonSpeciesId =
                        species.Id,

                    Level =
                        starterLevel,

                    CurrentHp =
                        maxHp,

                    AttackStage =
                        1,

                    PartyPosition =
                        1,

                    HeldItemId =
                        null
                };

            return await _runPokemonRepository.CreateAsync(
                runPokemon
            );
        }

        public async Task AdvanceToNextCityAsync(
            int runId
        )
        {
            var run =
                await _runRepository.GetByIdAsync(
                    runId
                );

            if (run == null)
            {
                throw new InvalidOperationException(
                    "Run was not found."
                );
            }

            var party =
                await _runPokemonRepository.GetByRunIdAsync(
                    runId
                );

            // Full heal AFTER the Gym's +3 level reward.
            foreach (var pokemon in party)
            {
                pokemon.CurrentHp =
                    PokemonStatCalculator.CalculateHp(
                        pokemon.PokemonSpecies,
                        pokemon.Level
                    );
            }

            await _runPokemonRepository.SaveChangesAsync();

            int nextCity =
                run.CurrentCity + 1;

            var generatedMap =
                _runMapService.CreateRunMap(
                    run.Id,
                    nextCity
                );

            if (generatedMap.RunNodes.Count == 0)
            {
                throw new InvalidOperationException(
                    $"No map could be generated for city {nextCity}."
                );
            }

            await _runMapRepository.SaveRunNodesAsync(
                generatedMap.RunNodes
            );

            int startNodeId =
                generatedMap.RunNodes
                    .Min(node =>
                        node.MapNodeId
                    );

            run.CurrentCity =
                nextCity;

            run.CurrentNodeId =
                startNodeId;

            await _runRepository.SaveChangesAsync();
        }
    }
}