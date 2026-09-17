namespace PokeRogue.Domain.Entities
{
    public class BattlePlayerPokemon
    {
        public int Id { get; set; } 
        public int BattleId { get; set; }
        public Battle Battle { get; set; } = null!;
        public int RunPokemonId { get; set; }
        public RunPokemon RunPokemon { get; set; } = null!;
        public bool EligibleForLevelUp { get; set; }
    }
}