using PokeRogue.Domain.Enums;

namespace PokeRogue.Domain.Models
{
    public class BattleStateResult
    {
        public int BattleId { get; set; }
        public BattleStatus Status { get; set; }
        public bool IsPlayerTurn { get; set; }
        public BattlePokemonState PlayerPokemon { get; set; } = null!;
        public BattlePokemonState OpponentPokemon { get; set; } = null!;
        public List<BattlePokemonState> Party { get; set; } = new();
        public int OpponentPokemonRemaining { get; set; }
    }
}