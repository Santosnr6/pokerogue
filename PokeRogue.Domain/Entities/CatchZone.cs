namespace PokeRogue.Domain.Entities
{
    public class CatchZone
    {
        public int Id { get; set; }

        public int CityNumber { get; set; }

        public int PokemonSpeciesId { get; set; }

        public PokemonSpecies PokemonSpecies { get; set; } = null!;

        public int Weight { get; set; }
    }
}

