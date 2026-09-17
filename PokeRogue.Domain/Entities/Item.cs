using PokeRogue.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ItemEffectType EffectType { get; set; }
        public ItemTrigger Trigger { get; set; }
        public ItemTarget Target { get; set; }
        public int Value { get; set; }
        public PokemonType? TargetPokemonType { get; set; }
        public bool IsConsumable { get; set; }
    }
}
