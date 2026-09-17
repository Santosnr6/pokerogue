using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;
using PokeRogue.Domain.Models;
using PokeRogue.Domain.Services;

namespace PokeRogue.Application.Services
{
    public class TrainerEncounterService
        : ITrainerEncounterService
    {
        private readonly IRunRepository _runRepository;
        private readonly IRunMapRepository _runMapRepository;
        private readonly ICatchZoneRepository _catchZoneRepository;
        private readonly ITrainerTypeRepository _trainerTypeRepository;
        private readonly IBattleService _battleService;

        public TrainerEncounterService(
            IRunRepository runRepository,
            IRunMapRepository runMapRepository,
            ICatchZoneRepository catchZoneRepository,
            ITrainerTypeRepository trainerTypeRepository,
            IBattleService battleService
        )
        {
            _runRepository = runRepository;
            _runMapRepository = runMapRepository;
            _catchZoneRepository = catchZoneRepository;
            _trainerTypeRepository = trainerTypeRepository;
            _battleService = battleService;
        }

        public async Task<TrainerEncounterStartResult>
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
                runNode.Type != NodeEventType.PokemonTrainer)
            {
                throw new InvalidOperationException(
                    "The current node is not a Pokémon Trainer event."
                );
            }

            if (runNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "This Trainer event has already been completed."
                );
            }

            var catchZones =
                await _catchZoneRepository.GetByCityAsync(
                    run.CurrentCity
                );

            if (catchZones.Count == 0)
            {
                throw new InvalidOperationException(
                    "No Pokémon are available in this city."
                );
            }

            var city =
                CityRegistry.GetCity(
                    run.CurrentCity
                );

            int teamSize =
                GetTrainerTeamSize(
                    run.CurrentCity
                );

            var availablePokemon =
                catchZones
                    .Select(zone =>
                        zone.PokemonSpecies
                    )
                    .DistinctBy(pokemon =>
                        pokemon.Id
                    )
                    .ToList();

            var availableStages =
                availablePokemon
                    .GroupBy(pokemon =>
                        pokemon.EvolutionStage
                    )
                    .Where(group =>
                        group.Count() >= teamSize
                    )
                    .Select(group =>
                        group.Key
                    )
                    .ToList();

            if (availableStages.Count == 0)
            {
                throw new InvalidOperationException(
                    "No evolution stage contains enough Pokémon for a trainer team."
                );
            }

            int evolutionStage =
                EvolutionStageSelector.PickAvailableStage(
                    city.TrainerEvolutionWeights,
                    availableStages
                );

            var stagePokemon =
                availablePokemon
                    .Where(pokemon =>
                        pokemon.EvolutionStage ==
                        evolutionStage
                    )
                    .ToList();

            var trainerTypes =
                await _trainerTypeRepository.GetAllAsync();

            var eligibleTrainerTypes =
                trainerTypes
                    .Where(trainer =>
                        stagePokemon.Count(pokemon =>
                            MatchesTrainerType(
                                pokemon,
                                trainer
                            )
                        ) >= teamSize
                    )
                    .ToList();

            if (eligibleTrainerTypes.Count == 0)
            {
                throw new InvalidOperationException(
                    "No suitable trainer type could be generated for this city and evolution stage."
                );
            }

            var trainerType =
                eligibleTrainerTypes[
                    Random.Shared.Next(
                        eligibleTrainerTypes.Count
                    )
                ];

            var trainerPokemonPool =
                stagePokemon
                    .Where(pokemon =>
                        MatchesTrainerType(
                            pokemon,
                            trainerType
                        )
                    )
                    .OrderBy(_ =>
                        Random.Shared.Next()
                    )
                    .Take(teamSize)
                    .ToList();

            var opponents =
                new List<BattleOpponentSetup>();

            for (int i = 0;
                 i < trainerPokemonPool.Count;
                 i++)
            {
                var species =
                    trainerPokemonPool[i];

                int level =
                    Random.Shared.Next(
                        city.TrainerPokemonMinLevel,
                        city.TrainerPokemonMaxLevel + 1
                    );

                opponents.Add(
                    new BattleOpponentSetup
                    {
                        PokemonSpeciesId =
                            species.Id,

                        Level =
                            level,

                        AttackStage =
                            GetTrainerAttackStage(
                                run.CurrentCity
                            ),

                        PartyPosition =
                            i + 1
                    }
                );
            }

            var battle =
                await _battleService.StartBattleAsync(
                    runId,
                    run.CurrentNodeId,
                    opponents
                );

            return new TrainerEncounterStartResult
            {
                TrainerName =
                    trainerType.Name,

                Battle =
                    battle
            };
        }

        private static bool MatchesTrainerType(
            PokemonSpecies pokemon,
            TrainerType trainer
        )
        {
            bool matchesType1 =
                pokemon.Type1 == trainer.Type1 ||
                pokemon.Type2 == trainer.Type1;

            bool matchesType2 =
                trainer.Type2.HasValue &&
                (
                    pokemon.Type1 ==
                        trainer.Type2.Value ||
                    pokemon.Type2 ==
                        trainer.Type2.Value
                );

            return matchesType1 ||
                matchesType2;
        }

        private static int GetTrainerTeamSize(
            int cityNumber
        )
        {
            return cityNumber switch
            {
                <= 2 => 2,
                <= 5 => 3,
                _ => 4
            };
        }

        private static int GetTrainerAttackStage(
            int cityNumber
        )
        {
            return cityNumber switch
            {
                <= 3 => 1,
                <= 6 => 2,
                _ => 3
            };
        }
    }
}