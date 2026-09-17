namespace PokeRogue.Blazor.Models
{
    public class RunDto
    {
        public int Id { get; set; }
        public int CurrentCity { get; set; }
        public int CurrentNodeId { get; set; }
        public string RunStatus { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public List<PokemonDto> Pokemon { get; set; } = new();
    }
}