using PokeRogue.Domain.Enums;

namespace PokeRogue.Domain.Entities
{
    public class Run
    {
        public int Id { get; set; }
        public int CurrentCity { get; set; }
        public int CurrentNodeId { get; set; }
        public RunStatus RunStatus { get; set; }
        public DateTime StartedAt { get; set; }
        public List<RunPokemon> Pokemon { get; set; } = new();
        public List<RunItem> Items { get; set; } = new();
    }
}
