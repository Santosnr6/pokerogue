using PokeRogue.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Domain.Entities
{
    public class TrainerType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PokemonType Type1 { get; set; }
        public PokemonType? Type2 { get; set; }
    }
}
