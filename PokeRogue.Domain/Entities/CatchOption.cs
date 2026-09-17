using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Domain.Entities
{
    public class CatchOption
    {
        public int Id { get; set; }
        public int RunId { get; set; }
        public int MapNodeId { get; set; }
        public int PokemonSpeciesId { get; set; }
        public PokemonSpecies PokemonSpecies { get; set; } = null!;
    }
}
