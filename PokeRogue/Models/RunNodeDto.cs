namespace PokeRogue.Blazor.Models
{
    public class RunNodeDto
    {
        public int Id { get; set; }
        public int RunId { get; set; }
        public int MapNodeId { get; set; }
        public MapNodeDto? MapNode { get; set; } = null!;
        public string Type { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}