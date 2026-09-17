using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Domain.Entities
{
    public class MapLayout
    {
        public List<MapNode> Nodes { get; set; } = new();
        public List<MapConnection> Connections { get; set; } = new();
    }
}
