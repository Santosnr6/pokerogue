namespace PokeRogue.Blazor.Models
{
    public class MapConnectionDto
    {
        public int Id { get; set; }
        public int FromNodeId { get; set; }
        public MapNodeDto? FromNode { get; set; }
        public int ToNodeId { get; set; }
        public MapNodeDto? ToNode { get; set; }
    }
}