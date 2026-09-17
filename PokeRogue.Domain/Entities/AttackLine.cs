using PokeRogue.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Domain.Entities
{
    public class AttackLine
    {
        public int Id { get; set; }
        public string Stage1Name { get; set; } = string.Empty;
        public string Stage2Name { get; set; } = string.Empty;
        public string Stage3Name { get; set; } = string.Empty;
        public int Stage1Power { get; set; }
        public int Stage2Power { get; set; }
        public int Stage3Power { get; set; }
        public PokemonType Type { get; set; }
        public AttackCategory Category { get; set; }
    }
}
