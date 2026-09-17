using System.Text.Json.Serialization;

namespace PokeRogue.Domain.Entities
{
    public class RunPokemon
    {
        public int Id { get; set; }
        public int RunId { get; set; }
        [JsonIgnore]
        public Run Run { get; set; } = null!;
        public int PokemonSpeciesId { get; set; }
        public PokemonSpecies PokemonSpecies { get; set; } = null!;
        public int Level { get; set; }
        public int CurrentHp { get; set; }
        public int AttackStage { get; set; }
        public int PartyPosition { get; set; }
        public int? HeldItemId { get; set; }
        public Item? HeldItem { get; set; }
    }
}
