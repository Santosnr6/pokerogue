using PokeRogue.Domain.Entities;

namespace PokeRogue.Domain.Models
{
    public class BattleParticipant
    {
        public PokemonSpecies PokemonSpecies { get; set; } = null!;
        public int Level { get; set; }
        public int CurrentHp { get; set; }
        public int AttackStage { get; set; }
    }
}