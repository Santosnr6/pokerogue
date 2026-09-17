using PokeRogue.Domain.Enums;

namespace PokeRogue.Domain.Entities
{
    public class Battle
    {
        public int Id { get; set; }
        public int RunId { get; set; }
        public int MapNodeId { get; set; }
        public int PlayerPokemonId { get; set; }
        public int? ActiveOpponentPokemonId { get; set; }
        public bool IsPlayerTurn { get; set; }
        public BattleStatus Status { get; set; }
        public List<BattlePlayerPokemon> PlayerParty { get; set; } = new();
        public List<BattleOpponentPokemon> OpponentPokemon { get; set; } = new();
    }
}