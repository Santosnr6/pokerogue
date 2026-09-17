using PokeRogue.Domain.Models;

namespace PokeRogue.Application.Interfaces
{
    public interface IBattleService
    {
        Task<BattleStartResult> StartBattleAsync(
            int runId,
            int mapNodeId,
            List<BattleOpponentSetup> opponents
        );
        Task<BattleAttackResult> ExecuteNextAttackAsync(
            int battleId
        );
        Task<BattleSwitchResult> SwitchPokemonAsync(
            int battleId,
            int runPokemonId
        );
        Task<BattleStateResult> GetBattleStateAsync(
            int battleId
        );
    }
}