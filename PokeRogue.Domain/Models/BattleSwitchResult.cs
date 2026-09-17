using PokeRogue.Domain.Enums;

namespace PokeRogue.Domain.Models
{
    public class BattleSwitchResult
    {
        public int PreviousPokemonId { get; set; }
        public string PreviousPokemonName { get; set; } = string.Empty;
        public int NewPokemonId { get; set; }
        public string NewPokemonName { get; set; } = string.Empty;
        public int NewPokemonCurrentHp { get; set; }
        public int NewPokemonMaxHp { get; set; }
        public BattleStatus BattleStatus { get; set; }
    }
}