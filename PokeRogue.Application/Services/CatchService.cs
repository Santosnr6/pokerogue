using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;
using PokeRogue.Domain.Services;

namespace PokeRogue.Application.Services
{
    public class CatchService : ICatchService
    {
        private readonly IRunRepository _runRepository;
        private readonly IRunMapRepository _runMapRepository;
        private readonly ICatchOptionRepository _catchOptionRepository;
        private readonly ICatchZoneRepository _catchZoneRepository;
        private readonly IRunPokemonRepository _runPokemonRepository;

        public CatchService(
            IRunRepository runRepository,
            IRunMapRepository runMapRepository,
            ICatchOptionRepository catchOptionRepository,
            ICatchZoneRepository catchZoneRepository,
            IRunPokemonRepository runPokemonRepository
        )
        {
            _runRepository = runRepository;
            _runMapRepository = runMapRepository;
            _catchOptionRepository = catchOptionRepository;
            _catchZoneRepository = catchZoneRepository;
            _runPokemonRepository = runPokemonRepository;
        }

        public async Task<List<PokemonSpecies>>
            GetCatchOptionsAsync(int runId)
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

            var runNode =
                await _runMapRepository.GetRunNodeAsync(
                    runId,
                    run.CurrentNodeId
                );

            if (runNode == null ||
                runNode.Type != NodeEventType.CatchPokemon)
            {
                throw new InvalidOperationException(
                    "The current node is not a Catch Pokémon event."
                );
            }

            if (runNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "This Catch Pokémon event has already been completed."
                );
            }

            var existingOptions =
                await _catchOptionRepository
                    .GetByRunAndNodeAsync(
                        runId,
                        run.CurrentNodeId
                    );

            if (existingOptions.Count > 0)
            {
                return existingOptions
                    .Select(option =>
                        option.PokemonSpecies
                    )
                    .ToList();
            }

            var catchZone =
                await _catchZoneRepository
                    .GetByCityAsync(
                        run.CurrentCity
                    );

            if (catchZone.Count < 3)
            {
                throw new InvalidOperationException(
                    "Not enough Pokémon are available in this catch zone."
                );
            }

            var city =
                CityRegistry.GetCity(
                    run.CurrentCity
                );

            // A Catch event needs three unique Pokémon.
            // Only evolution stages containing at least
            // three different species are eligible.
            var availableStages =
                catchZone
                    .GroupBy(option =>
                        option.PokemonSpecies.EvolutionStage
                    )
                    .Where(group =>
                        group
                            .Select(option =>
                                option.PokemonSpeciesId
                            )
                            .Distinct()
                            .Count() >= 3
                    )
                    .Select(group =>
                        group.Key
                    )
                    .ToList();

            if (availableStages.Count == 0)
            {
                throw new InvalidOperationException(
                    "No evolution stage contains enough Pokémon for this Catch event."
                );
            }

            int evolutionStage =
                EvolutionStageSelector.PickAvailableStage(
                    city.CatchEvolutionWeights,
                    availableStages
                );

            var eligibleCatchZone =
                catchZone
                    .Where(option =>
                        option.PokemonSpecies.EvolutionStage ==
                        evolutionStage
                    )
                    .ToList();

            var selectedPokemon =
                CatchRandomizer.PickWeightedPokemon(
                    eligibleCatchZone,
                    3
                );

            var options =
                selectedPokemon
                    .Select(species =>
                        new CatchOption
                        {
                            RunId =
                                runId,

                            MapNodeId =
                                run.CurrentNodeId,

                            PokemonSpeciesId =
                                species.Id
                        }
                    )
                    .ToList();

            await _catchOptionRepository.SaveAsync(
                options
            );

            return selectedPokemon;
        }

        public async Task<RunPokemon?>
            ChoosePokemonAsync(
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

            var runNode =
                await _runMapRepository.GetRunNodeAsync(
                    runId,
                    run.CurrentNodeId
                );

            if (runNode == null ||
                runNode.Type != NodeEventType.CatchPokemon)
            {
                throw new InvalidOperationException(
                    "The current node is not a Catch Pokémon event."
                );
            }

            if (runNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "This Catch Pokémon event has already been completed."
                );
            }

            var options =
                await _catchOptionRepository
                    .GetByRunAndNodeAsync(
                        runId,
                        run.CurrentNodeId
                    );

            var selectedOption =
                options.FirstOrDefault(option =>
                    option.PokemonSpeciesId ==
                    pokemonSpeciesId
                );

            if (selectedOption == null)
            {
                throw new InvalidOperationException(
                    "That Pokémon is not one of the available choices."
                );
            }

            var city =
                CityRegistry.GetCity(
                    run.CurrentCity
                );

            int catchLevel =
                Random.Shared.Next(
                    city.WildPokemonMinLevel,
                    city.WildPokemonMaxLevel + 1
                );

            int maxHp =
                PokemonStatCalculator.CalculateHp(
                    selectedOption.PokemonSpecies,
                    catchLevel
                );

            int partyPosition =
                await _runPokemonRepository
                    .GetNextPartyPositionAsync(
                        runId
                    );

            var runPokemon =
                new RunPokemon
                {
                    RunId =
                        runId,

                    PokemonSpeciesId =
                        pokemonSpeciesId,

                    Level =
                        catchLevel,

                    CurrentHp =
                        maxHp,

                    AttackStage =
                        1,

                    PartyPosition =
                        partyPosition,

                    HeldItemId =
                        null
                };

            var createdPokemon =
                await _runPokemonRepository.CreateAsync(
                    runPokemon
                );

            await _catchOptionRepository
                .DeleteByRunAndNodeAsync(
                    runId,
                    run.CurrentNodeId
                );

            await _runMapRepository.MarkCompletedAsync(
                runId,
                run.CurrentNodeId
            );

            return createdPokemon;
        }
    }
}