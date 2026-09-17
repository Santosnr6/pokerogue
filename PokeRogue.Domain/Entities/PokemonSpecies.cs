using System;
using System.Collections.Generic;
using System.Text;
using PokeRogue.Domain.Enums;

namespace PokeRogue.Domain.Entities
{
    public class PokemonSpecies
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int EvolutionStage { get; set; } = 1;
        public int? EvolveAtLevel { get; set; }
        public int? EvolvesIntoSpeciesId { get; set; }
        public PokemonType Type1 { get; set; }
        public PokemonType? Type2 { get; set; }
        public int BaseHp { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseSpecialAttack { get; set; }
        public int BaseSpecialDefense { get; set; }
        public int BaseSpeed { get; set; }
        public int AttackLineId { get; set; }
        public AttackLine AttackLine { get; set; } = null!;
        public bool IsStarter { get; set; }
    }
}