using PokeRogue.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Application.Models
{
    public class MoveResult
    {
        public int CurrentNodeId { get; set; }
        public NodeEventType EventType { get; set; }
    }
}
