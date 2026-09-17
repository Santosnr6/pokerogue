namespace PokeRogue.Domain.Models
{
    public class BattlePokemonState
    {
        public int? RunPokemonId { get; set; }
        public int PokemonSpeciesId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
        public bool IsActive { get; set; }
        public bool IsFainted { get; set; }
    }
}