using PokeRogue.Domain.Enums;

namespace PokeRogue.Domain.Models
{
    public class PokemonAttack
    {
        public string Name { get; set; } = string.Empty;
        public int Power { get; set; }
        public PokemonType Type { get; set; }
        public AttackCategory Category { get; set; }
    }
}