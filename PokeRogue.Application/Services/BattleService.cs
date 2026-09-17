using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;
using PokeRogue.Domain.Models;
using PokeRogue.Domain.Services;

namespace PokeRogue.Application.Services
{
    public class BattleService : IBattleService
    {
        private readonly IBattleRepository _battleRepository;
        private readonly IRunRepository _runRepository;
        private readonly IRunPokemonRepository _runPokemonRepository;
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IRunMapRepository _runMapRepository;
        private readonly IRunMapService _runMapService;
        private readonly IRunService _runService;

        public BattleService(
            IBattleRepository battleRepository,
            IRunRepository runRepository,
            IRunPokemonRepository runPokemonRepository,
            IPokemonRepository pokemonRepository,
            IRunMapRepository runMapRepository,
            IRunMapService runMapService,
            IRunService runService
        )
        {
            _battleRepository = battleRepository;
            _runRepository = runRepository;
            _runPokemonRepository = runPokemonRepository;
            _pokemonRepository = pokemonRepository;
            _runMapRepository = runMapRepository;
            _runMapService = runMapService;
            _runService = runService;
        }

        public async Task<BattleStartResult> StartBattleAsync(
            int runId,
            int mapNodeId,
            List<BattleOpponentSetup> opponents
        )
        {
            var run =
                await _runRepository.GetByIdAsync(runId);

            if (run == null)
            {
                throw new InvalidOperationException(
                    "Run was not found."
                );
            }

            if (opponents.Count == 0)
            {
                throw new InvalidOperationException(
                    "A battle must contain at least one opponent Pokémon."
                );
            }

            var playerParty =
                await _runPokemonRepository.GetByRunIdAsync(
                    runId
                );

            var playerPokemon =
                playerParty
                    .Where(pokemon =>
                        pokemon.CurrentHp > 0
                    )
                    .OrderBy(pokemon =>
                        pokemon.PartyPosition
                    )
                    .FirstOrDefault();

            if (playerPokemon == null)
            {
                throw new InvalidOperationException(
                    "The player has no Pokémon able to battle."
                );
            }

            var opponentPokemon =
                new List<BattleOpponentPokemon>();

            foreach (var setup in opponents)
            {
                var species =
                    await _pokemonRepository.GetByIdAsync(
                        setup.PokemonSpeciesId
                    );

                if (species == null)
                {
                    throw new InvalidOperationException(
                        $"Pokémon species " +
                        $"{setup.PokemonSpeciesId} " +
                        $"was not found."
                    );
                }

                int maxHp =
                    PokemonStatCalculator.CalculateHp(
                        species,
                        setup.Level
                    );

                opponentPokemon.Add(
                    new BattleOpponentPokemon
                    {
                        PokemonSpeciesId =
                            species.Id,

                        PokemonSpecies =
                            species,

                        Level =
                            setup.Level,

                        CurrentHp =
                            maxHp,

                        AttackStage =
                            setup.AttackStage,

                        PartyPosition =
                            setup.PartyPosition
                    }
                );
            }

            var firstOpponent =
                opponentPokemon
                    .OrderBy(pokemon =>
                        pokemon.PartyPosition
                    )
                    .First();

            int playerSpeed =
                PokemonStatCalculator.CalculateSpeed(
                    playerPokemon.PokemonSpecies,
                    playerPokemon.Level
                );

            int opponentSpeed =
                PokemonStatCalculator.CalculateSpeed(
                    firstOpponent.PokemonSpecies,
                    firstOpponent.Level
                );

            bool playerAttacksFirst =
                playerSpeed == opponentSpeed
                    ? Random.Shared.Next(2) == 0
                    : playerSpeed > opponentSpeed;

            var battle = new Battle
            {
                RunId =
                    runId,

                MapNodeId =
                    mapNodeId,

                PlayerPokemonId =
                    playerPokemon.Id,

                IsPlayerTurn =
                    playerAttacksFirst,

                Status =
                    BattleStatus.InProgress,

                OpponentPokemon =
                    opponentPokemon,

                PlayerParty =
                    playerParty
                        .Select(pokemon =>
                            new BattlePlayerPokemon
                            {
                                RunPokemonId =
                                    pokemon.Id,

                                EligibleForLevelUp =
                                    pokemon.CurrentHp > 0
                            }
                        )
                        .ToList()
            };

            battle =
                await _battleRepository.CreateAsync(
                    battle
                );

            var activeOpponent =
                battle.OpponentPokemon
                    .OrderBy(pokemon =>
                        pokemon.PartyPosition
                    )
                    .First();

            battle.ActiveOpponentPokemonId =
                activeOpponent.Id;

            await _battleRepository.SaveChangesAsync();

            int playerMaxHp =
                PokemonStatCalculator.CalculateHp(
                    playerPokemon.PokemonSpecies,
                    playerPokemon.Level
                );

            return new BattleStartResult
            {
                BattleId =
                    battle.Id,

                PlayerPokemonName =
                    playerPokemon.PokemonSpecies.Name,

                PlayerPokemonLevel =
                    playerPokemon.Level,

                PlayerCurrentHp =
                    playerPokemon.CurrentHp,

                PlayerMaxHp =
                    playerMaxHp,

                OpponentPokemonName =
                    activeOpponent.PokemonSpecies.Name,

                OpponentPokemonLevel =
                    activeOpponent.Level,

                OpponentCurrentHp =
                    activeOpponent.CurrentHp,

                OpponentMaxHp =
                    activeOpponent.CurrentHp,

                PlayerAttacksFirst =
                    playerAttacksFirst
            };
        }

        public async Task<BattleAttackResult> ExecuteNextAttackAsync(
            int battleId
        )
        {
            var battle =
                await _battleRepository.GetByIdAsync(battleId);

            if (battle == null)
            {
                throw new InvalidOperationException(
                    "Battle was not found."
                );
            }

            if (battle.Status != BattleStatus.InProgress)
            {
                throw new InvalidOperationException(
                    "This battle has already ended."
                );
            }

            var playerPokemon =
                await _runPokemonRepository.GetByIdAsync(
                    battle.PlayerPokemonId
                );

            if (playerPokemon == null)
            {
                throw new InvalidOperationException(
                    "Player Pokémon was not found."
                );
            }

            var opponentPokemon =
                battle.OpponentPokemon
                    .FirstOrDefault(pokemon =>
                        pokemon.Id ==
                        battle.ActiveOpponentPokemonId
                    );

            if (opponentPokemon == null)
            {
                throw new InvalidOperationException(
                    "Active opponent Pokémon was not found."
                );
            }

            if (battle.IsPlayerTurn)
            {
                return await ExecutePlayerAttackAsync(
                    battle,
                    playerPokemon,
                    opponentPokemon
                );
            }

            return await ExecuteOpponentAttackAsync(
                battle,
                playerPokemon,
                opponentPokemon
            );
        }

        private async Task<BattleAttackResult> ExecutePlayerAttackAsync(
            Battle battle,
            RunPokemon playerPokemon,
            BattleOpponentPokemon opponentPokemon
        )
        {
            int previousHp =
                opponentPokemon.CurrentHp;

            int maxHp =
                PokemonStatCalculator.CalculateHp(
                    opponentPokemon.PokemonSpecies,
                    opponentPokemon.Level
                );

            PokemonAttack attack =
                PokemonAttackResolver.GetAttack(
                    playerPokemon.PokemonSpecies,
                    playerPokemon.AttackStage
                );

            var attacker =
                new BattleParticipant
                {
                    PokemonSpecies =
                        playerPokemon.PokemonSpecies,

                    Level =
                        playerPokemon.Level,

                    CurrentHp =
                        playerPokemon.CurrentHp,

                    AttackStage =
                        playerPokemon.AttackStage
                };

            var defender =
                new BattleParticipant
                {
                    PokemonSpecies =
                        opponentPokemon.PokemonSpecies,

                    Level =
                        opponentPokemon.Level,

                    CurrentHp =
                        opponentPokemon.CurrentHp,

                    AttackStage =
                        opponentPokemon.AttackStage
                };

            DamageResult damageResult =
                DamageCalculator.Calculate(
                    attacker,
                    defender
                );

            opponentPokemon.CurrentHp =
                Math.Max(
                    0,
                    previousHp - damageResult.Damage
                );

            bool fainted =
                opponentPokemon.CurrentHp == 0;

            int? newActiveOpponentPokemonId =
                null;

            string? newActiveOpponentPokemonName =
                null;

            if (fainted)
            {
                var nextOpponent =
                    battle.OpponentPokemon
                        .Where(pokemon =>
                            pokemon.CurrentHp > 0 &&
                            pokemon.Id != opponentPokemon.Id
                        )
                        .OrderBy(pokemon =>
                            pokemon.PartyPosition
                        )
                        .FirstOrDefault();

                if (nextOpponent == null)
                {
                    battle.Status =
                        BattleStatus.PlayerWon;

                    var runNode =
                        await _runMapRepository.GetRunNodeAsync(
                            battle.RunId,
                            battle.MapNodeId
                        );

                    if (runNode == null)
                    {
                        throw new InvalidOperationException(
                            "The battle node was not found."
                        );
                    }

                    await RewardLevelsAsync(
                        battle
                    );

                    await _runMapRepository.MarkCompletedAsync(
                        battle.RunId,
                        battle.MapNodeId
                    );

                    if (runNode.Type ==
                        NodeEventType.GymLeader)
                    {
                        await _runService
                            .AdvanceToNextCityAsync(
                                battle.RunId
                            );
                    }
                }
                else
                {
                    battle.ActiveOpponentPokemonId =
                        nextOpponent.Id;

                    newActiveOpponentPokemonId =
                        nextOpponent.Id;

                    newActiveOpponentPokemonName =
                        nextOpponent.PokemonSpecies.Name;

                    // Player has already used its turn.
                    // The newly entered opponent attacks next.
                    battle.IsPlayerTurn =
                        false;
                }
            }
            else
            {
                battle.IsPlayerTurn =
                    false;
            }

            await _battleRepository.SaveChangesAsync();

            return new BattleAttackResult
            {
                AttackerName =
                    playerPokemon.PokemonSpecies.Name,

                DefenderName =
                    opponentPokemon.PokemonSpecies.Name,

                AttackName =
                    attack.Name,

                Damage =
                    damageResult.Damage,

                IsCritical =
                    damageResult.IsCritical,

                TypeMultiplier =
                    damageResult.TypeMultiplier,

                PreviousHp =
                    previousHp,

                CurrentHp =
                    opponentPokemon.CurrentHp,

                MaxHp =
                    maxHp,

                Fainted =
                    fainted,

                NewActiveOpponentPokemonId =
                    newActiveOpponentPokemonId,

                NewActiveOpponentPokemonName =
                    newActiveOpponentPokemonName,

                BattleStatus =
                    battle.Status
            };
        }

        private async Task<BattleAttackResult> ExecuteOpponentAttackAsync(
            Battle battle,
            RunPokemon playerPokemon,
            BattleOpponentPokemon opponentPokemon
        )
        {
            int previousHp = playerPokemon.CurrentHp;

            int maxHp =
                PokemonStatCalculator.CalculateHp(
                    playerPokemon.PokemonSpecies,
                    playerPokemon.Level
                );

            PokemonAttack attack =
                PokemonAttackResolver.GetAttack(
                    opponentPokemon.PokemonSpecies,
                    opponentPokemon.AttackStage
                );

            var attacker = new BattleParticipant
            {
                PokemonSpecies = opponentPokemon.PokemonSpecies,
                Level = opponentPokemon.Level,
                CurrentHp = opponentPokemon.CurrentHp,
                AttackStage = opponentPokemon.AttackStage
            };

            var defender = new BattleParticipant
            {
                PokemonSpecies = playerPokemon.PokemonSpecies,
                Level = playerPokemon.Level,
                CurrentHp = playerPokemon.CurrentHp,
                AttackStage = playerPokemon.AttackStage
            };

            DamageResult damageResult =
                DamageCalculator.Calculate(
                    attacker,
                    defender
                );

            playerPokemon.CurrentHp =
                Math.Max(
                    0,
                    previousHp - damageResult.Damage
                );

            bool fainted =
                playerPokemon.CurrentHp == 0;

            int? newActivePlayerPokemonId = null;
            string? newActivePlayerPokemonName = null;

            if (fainted)
            {
                var party =
                    await _runPokemonRepository.GetByRunIdAsync(
                        battle.RunId
                    );

                var nextPokemon = party
                    .Where(pokemon =>
                        pokemon.CurrentHp > 0 &&
                        pokemon.Id != playerPokemon.Id
                    )
                    .OrderBy(pokemon => pokemon.PartyPosition)
                    .FirstOrDefault();

                if (nextPokemon == null)
                {
                    battle.Status =
                        BattleStatus.PlayerLost;
                }
                else
                {
                    battle.PlayerPokemonId =
                        nextPokemon.Id;

                    newActivePlayerPokemonId = nextPokemon.Id;
                    newActivePlayerPokemonName = nextPokemon.PokemonSpecies.Name;

                    // The opponent has already used its turn.
                    // The newly entered Pokémon gets the next turn.
                    battle.IsPlayerTurn = true;
                }
            }
            else
            {
                battle.IsPlayerTurn = true;
            }

            await _runPokemonRepository.SaveChangesAsync();
            await _battleRepository.SaveChangesAsync();

            return new BattleAttackResult
            {
                AttackerName =
                    opponentPokemon.PokemonSpecies.Name,

                DefenderName =
                    playerPokemon.PokemonSpecies.Name,

                AttackName =
                    attack.Name,

                Damage =
                    damageResult.Damage,

                IsCritical =
                    damageResult.IsCritical,

                TypeMultiplier =
                    damageResult.TypeMultiplier,

                PreviousHp =
                    previousHp,

                CurrentHp =
                    playerPokemon.CurrentHp,

                MaxHp =
                    maxHp,

                Fainted =
                    fainted,

                NewActivePlayerPokemonId =
                    newActivePlayerPokemonId,

                NewActivePlayerPokemonName =
                    newActivePlayerPokemonName,

                BattleStatus =
                    battle.Status
            };
        }

        public async Task<BattleSwitchResult> SwitchPokemonAsync(
            int battleId,
            int runPokemonId
        )
        {
            var battle =
                await _battleRepository.GetByIdAsync(battleId);

            if (battle == null)
            {
                throw new InvalidOperationException(
                    "Battle was not found."
                );
            }

            if (battle.Status != BattleStatus.InProgress)
            {
                throw new InvalidOperationException(
                    "This battle has already ended."
                );
            }

            if (!battle.IsPlayerTurn)
            {
                throw new InvalidOperationException(
                    "You can only switch Pokémon on your turn."
                );
            }

            var currentPokemon =
                await _runPokemonRepository.GetByIdAsync(
                    battle.PlayerPokemonId
                );

            if (currentPokemon == null)
            {
                throw new InvalidOperationException(
                    "Current Pokémon was not found."
                );
            }

            var newPokemon =
                await _runPokemonRepository.GetByIdAsync(
                    runPokemonId
                );

            if (newPokemon == null ||
                newPokemon.RunId != battle.RunId)
            {
                throw new InvalidOperationException(
                    "That Pokémon does not belong to this run."
                );
            }

            if (newPokemon.Id == currentPokemon.Id)
            {
                throw new InvalidOperationException(
                    "That Pokémon is already active."
                );
            }

            if (newPokemon.CurrentHp <= 0)
            {
                throw new InvalidOperationException(
                    "You cannot switch to a fainted Pokémon."
                );
            }

            int newPokemonMaxHp =
                PokemonStatCalculator.CalculateHp(
                    newPokemon.PokemonSpecies,
                    newPokemon.Level
                );

            battle.PlayerPokemonId = newPokemon.Id;

            // Switching uses the player's turn.
            battle.IsPlayerTurn = false;

            await _battleRepository.SaveChangesAsync();

            return new BattleSwitchResult
            {
                PreviousPokemonName =
                    currentPokemon.PokemonSpecies.Name,

                NewPokemonName =
                    newPokemon.PokemonSpecies.Name,

                NewPokemonCurrentHp =
                    newPokemon.CurrentHp,

                NewPokemonMaxHp =
                    newPokemonMaxHp,

                BattleStatus =
                    battle.Status
            };
        }

        public async Task<BattleStateResult> GetBattleStateAsync(
            int battleId
        )
        {
            var battle =
                await _battleRepository.GetByIdAsync(battleId);

            if (battle == null)
            {
                throw new InvalidOperationException(
                    "Battle was not found."
                );
            }

            var party =
                await _runPokemonRepository.GetByRunIdAsync(
                    battle.RunId
                );

            var activePlayerPokemon =
                party.FirstOrDefault(pokemon =>
                    pokemon.Id == battle.PlayerPokemonId
                );

            if (activePlayerPokemon == null)
            {
                throw new InvalidOperationException(
                    "Active player Pokémon was not found."
                );
            }

            var activeOpponentPokemon =
                battle.OpponentPokemon
                    .FirstOrDefault(pokemon =>
                        pokemon.Id ==
                        battle.ActiveOpponentPokemonId
                    );

            if (activeOpponentPokemon == null)
            {
                throw new InvalidOperationException(
                    "Active opponent Pokémon was not found."
                );
            }

            var partyState =
                party
                    .Select(pokemon =>
                        new BattlePokemonState
                        {
                            RunPokemonId =
                                pokemon.Id,

                            PokemonSpeciesId =
                                pokemon.PokemonSpeciesId,

                            Name =
                                pokemon.PokemonSpecies.Name,

                            Level =
                                pokemon.Level,

                            CurrentHp =
                                pokemon.CurrentHp,

                            MaxHp =
                                PokemonStatCalculator.CalculateHp(
                                    pokemon.PokemonSpecies,
                                    pokemon.Level
                                ),

                            IsActive =
                                pokemon.Id ==
                                battle.PlayerPokemonId,

                            IsFainted =
                                pokemon.CurrentHp <= 0
                        }
                    )
                    .ToList();

            var playerState =
                partyState.First(state =>
                    state.RunPokemonId ==
                    battle.PlayerPokemonId
                );

            var opponentState =
                new BattlePokemonState
                {
                    RunPokemonId = null,

                    PokemonSpeciesId =
                        activeOpponentPokemon.PokemonSpeciesId,

                    Name =
                        activeOpponentPokemon.PokemonSpecies.Name,

                    Level =
                        activeOpponentPokemon.Level,

                    CurrentHp =
                        activeOpponentPokemon.CurrentHp,

                    MaxHp =
                        PokemonStatCalculator.CalculateHp(
                            activeOpponentPokemon.PokemonSpecies,
                            activeOpponentPokemon.Level
                        ),

                    IsActive = true,

                    IsFainted =
                        activeOpponentPokemon.CurrentHp <= 0
                };

            int opponentPokemonRemaining =
                battle.OpponentPokemon.Count(
                    pokemon =>
                        pokemon.CurrentHp > 0
                );

            return new BattleStateResult
            {
                BattleId =
                    battle.Id,

                Status =
                    battle.Status,

                IsPlayerTurn =
                    battle.IsPlayerTurn,

                PlayerPokemon =
                    playerState,

                OpponentPokemon =
                    opponentState,

                Party =
                    partyState,

                OpponentPokemonRemaining =
                    opponentPokemonRemaining
            };
        }

        private async Task RewardLevelsAsync(
            Battle battle
        )
        {
            var runNode =
                await _runMapRepository.GetRunNodeAsync(
                    battle.RunId,
                    battle.MapNodeId
                );

            if (runNode == null)
            {
                throw new InvalidOperationException(
                    "The battle node was not found."
                );
            }

            int levelsToGain =
                runNode.Type switch
                {
                    NodeEventType.RandomEncounter => 1,
                    NodeEventType.PokemonTrainer => 2,
                    NodeEventType.GymLeader => 3,
                    _ => 0
                };

            if (levelsToGain == 0)
            {
                return;
            }

            foreach (var battlePlayerPokemon
                in battle.PlayerParty)
            {
                if (!battlePlayerPokemon.EligibleForLevelUp)
                {
                    continue;
                }

                var pokemon =
                    battlePlayerPokemon.RunPokemon;

                int oldMaxHp =
                    PokemonStatCalculator.CalculateHp(
                        pokemon.PokemonSpecies,
                        pokemon.Level
                    );

                bool isFainted =
                    pokemon.CurrentHp <= 0;

                pokemon.Level +=
                    levelsToGain;

                int newMaxHp =
                    PokemonStatCalculator.CalculateHp(
                        pokemon.PokemonSpecies,
                        pokemon.Level
                    );

                if (!isFainted)
                {
                    int hpIncrease =
                        newMaxHp - oldMaxHp;

                    pokemon.CurrentHp +=
                        hpIncrease;
                }
            }

            await _runPokemonRepository.SaveChangesAsync();
        }

        private async Task AdvanceAfterGymVictoryAsync(
            Battle battle
        )
        {
            var run =
                await _runRepository.GetByIdAsync(
                    battle.RunId
                );

            if (run == null)
            {
                throw new InvalidOperationException(
                    "Run was not found."
                );
            }

            var party =
                await _runPokemonRepository.GetByRunIdAsync(
                    battle.RunId
                );

            // Full heal AFTER the +3 level reward.
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

            run.CurrentCity =
                nextCity;

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

            var startNode =
                generatedMap.RunNodes
                    .OrderBy(node =>
                        node.MapNodeId
                    )
                    .First();

            run.CurrentNodeId =
                startNode.MapNodeId;

            await _runRepository.SaveChangesAsync();
        }
    }
}