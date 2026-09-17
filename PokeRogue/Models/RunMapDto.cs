namespace PokeRogue.Blazor.Models
{
    public class RunMapDto
    {
        public List<RunNodeDto> RunNodes { get; set; } = new();
        public List<MapConnectionDto> Connections { get; set; } = new();
    }
}