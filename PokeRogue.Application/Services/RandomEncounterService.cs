using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;
using PokeRogue.Domain.Models;
using PokeRogue.Domain.Services;

namespace PokeRogue.Application.Services
{
    public class RandomEncounterService
        : IRandomEncounterService
    {
        private readonly IRunRepository _runRepository;
        private readonly IRunMapRepository _runMapRepository;
        private readonly ICatchZoneRepository _catchZoneRepository;
        private readonly IBattleService _battleService;

        public RandomEncounterService(
            IRunRepository runRepository,
            IRunMapRepository runMapRepository,
            ICatchZoneRepository catchZoneRepository,
            IBattleService battleService
        )
        {
            _runRepository = runRepository;
            _runMapRepository = runMapRepository;
            _catchZoneRepository = catchZoneRepository;
            _battleService = battleService;
        }

        public async Task<BattleStartResult>
            StartEncounterAsync(int runId)
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
                runNode.Type !=
                NodeEventType.RandomEncounter)
            {
                throw new InvalidOperationException(
                    "The current node is not a Random Encounter."
                );
            }

            if (runNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "This Random Encounter has already been completed."
                );
            }

            var catchZone =
                await _catchZoneRepository.GetByCityAsync(
                    run.CurrentCity
                );

            if (catchZone.Count == 0)
            {
                throw new InvalidOperationException(
                    "No Pokémon are available in this area."
                );
            }

            var city =
                CityRegistry.GetCity(
                    run.CurrentCity
                );

            int evolutionStage =
                EvolutionStageSelector.PickAvailableStage(
                    city.WildEvolutionWeights,
                    catchZone.Select(option =>
                        option.PokemonSpecies.EvolutionStage
                    )
                );

            var eligibleCatchZone =
                catchZone
                    .Where(option =>
                        option.PokemonSpecies
                            .EvolutionStage ==
                        evolutionStage
                    )
                    .ToList();

            if (eligibleCatchZone.Count == 0)
            {
                throw new InvalidOperationException(
                    "No Pokémon are available for the selected evolution stage."
                );
            }

            var opponentSpecies =
                CatchRandomizer
                    .PickWeightedPokemon(
                        eligibleCatchZone,
                        1
                    )
                    .First();

            int opponentLevel =
                Random.Shared.Next(
                    city.WildPokemonMinLevel,
                    city.WildPokemonMaxLevel + 1
                );

            var opponents =
                new List<BattleOpponentSetup>
                {
                    new BattleOpponentSetup
                    {
                        PokemonSpeciesId =
                            opponentSpecies.Id,

                        Level =
                            opponentLevel,

                        AttackStage =
                            1,

                        PartyPosition =
                            1
                    }
                };

            return await _battleService
                .StartBattleAsync(
                    runId,
                    run.CurrentNodeId,
                    opponents
                );
        }
    }
}