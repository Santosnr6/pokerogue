using PokeRogue.Domain.Enums;

namespace PokeRogue.Domain.Entities
{
    public class RunNode
    {
        public int Id { get; set; }
        public int RunId { get; set; }
        public Run Run { get; set; } = null!;
        public int MapNodeId { get; set; }
        public MapNode MapNode { get; set; } = null!;
        public NodeEventType Type { get; set; }
        public bool IsCompleted { get; set; }
    }
}
