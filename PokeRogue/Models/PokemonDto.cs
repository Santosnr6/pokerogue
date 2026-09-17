namespace PokeRogue.Blazor.Models
{
    public class PokemonDto
    {
        // Used when the API returns a PokemonSpecies
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type1 { get; set; } = string.Empty;
        public string? Type2 { get; set; }

        // Used when the API returns a RunPokemon
        public int RunId { get; set; }
        public int PokemonSpeciesId { get; set; }
        public PokemonSpeciesDto? PokemonSpecies { get; set; }
        public int Level { get; set; }
        public int CurrentHp { get; set; }
        public int AttackStage { get; set; }
        public int PartyPosition { get; set; }
    }

    public class PokemonSpeciesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type1 { get; set; } = string.Empty;
        public string? Type2 { get; set; }
    }
}