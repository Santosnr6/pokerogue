using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Models
{
    public class GeneratedMap
    {
        public List<RunNode> RunNodes { get; set; } = new();
        public List<MapConnection> Connections { get; set; } = new();
    }
}