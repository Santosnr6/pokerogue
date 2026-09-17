using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Domain.Entities
{
    public class MapConnection
    {
        public int Id { get; set; }
        public int FromNodeId { get; set; }
        public MapNode FromNode { get; set; } = null!;
        public int ToNodeId { get; set; }
        public MapNode ToNode { get; set; } = null!;
    }
}
