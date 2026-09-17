using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Enums;
using PokeRogue.Domain.Models;

namespace PokeRogue.Application.Services
{
    public class GymEncounterService
        : IGymEncounterService
    {
        private readonly IRunRepository _runRepository;
        private readonly IRunMapRepository _runMapRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IBattleService _battleService;

        public GymEncounterService(
            IRunRepository runRepository,
            IRunMapRepository runMapRepository,
            IPokemonRepository pokemonRepository,
            IBattleService battleService
        )
        {
            _runRepository = runRepository;
            _runMapRepository = runMapRepository;
            _pokemonRepository = pokemonRepository;
            _battleService = battleService;
        }

        public async Task<GymEncounterStartResult>
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
                runNode.Type != NodeEventType.GymLeader
            )
            {
                throw new InvalidOperationException(
                    "The current node is not a Gym Leader event."
                );
            }

            if (runNode.IsCompleted)
            {
                throw new InvalidOperationException(
                    "This Gym has already been completed."
                );
            }

            var gym =
                GetGymForCity(
                    run.CurrentCity
                );

            var opponents =
                new List<BattleOpponentSetup>();

            for (int i = 0;
                 i < gym.Pokemon.Count;
                 i++)
            {
                var gymPokemon =
                    gym.Pokemon[i];

                var species =
                    await _pokemonRepository
                        .GetByIdAsync(
                            gymPokemon.PokemonSpeciesId
                        );

                if (species == null)
                {
                    throw new InvalidOperationException(
                        $"Pokémon with ID " +
                        $"{gymPokemon.PokemonSpeciesId} " +
                        $"was not found."
                    );
                }

                opponents.Add(
                    new BattleOpponentSetup
                    {
                        PokemonSpeciesId =
                            species.Id,

                        Level =
                            gymPokemon.Level,

                        AttackStage =
                            gymPokemon.AttackStage,

                        PartyPosition =
                            i + 1
                    }
                );
            }

            var battle =
                await _battleService
                    .StartBattleAsync(
                        runId,
                        run.CurrentNodeId,
                        opponents
                    );

            return new GymEncounterStartResult
            {
                GymLeaderName =
                    gym.LeaderName,

                Battle =
                    battle
            };
        }

        private static GymSetup
            GetGymForCity(int cityNumber)
        {
            return cityNumber switch
            {
                1 => new GymSetup
                {
                    LeaderName = "Brock",

                    Pokemon = new()
                    {
                        new GymPokemonSetup
                        {
                            PokemonSpeciesId = 74,
                            Level = 8,
                            AttackStage = 1
                        },

                        new GymPokemonSetup
                        {
                            PokemonSpeciesId = 95,
                            Level = 10,
                            AttackStage = 1
                        }
                    }
                },

                _ => throw new InvalidOperationException(
                    $"No Gym has been configured " +
                    $"for city {cityNumber}."
                )
            };
        }

        private class GymSetup
        {
            public string LeaderName { get; set; } =
                string.Empty;

            public List<GymPokemonSetup> Pokemon
            { get; set; } = new();
        }

        private class GymPokemonSetup
        {
            public int PokemonSpeciesId { get; set; }

            public int Level { get; set; }

            public int AttackStage { get; set; } = 1;
        }
    }
}