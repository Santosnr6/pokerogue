using PokeRogue.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokeRogue.Domain.Services
{
    public static class PokemonStatCalculator
    {
        public static int CalculateHp(PokemonSpecies species, int level)
        {
            return (2 * species.BaseHp * level / 100) + level + 10;
        }

        public static int CalculateAttack(PokemonSpecies species, int level)
        {
            return (2 * species.BaseAttack * level / 100) + 5;
        }

        public static int CalculateDefense(PokemonSpecies species, int level)
        {
            return (2 * species.BaseDefense * level / 100) + 5;
        }

        public static int CalculateSpecialAttack(PokemonSpecies species, int level)
        {
            return (2 * species.BaseSpecialAttack * level / 100) + 5;
        }

        public static int CalculateSpecialDefense(PokemonSpecies species, int level)
        {
            return (2 * species.BaseSpecialDefense * level / 100) + 5;
        }

        public static int CalculateSpeed(PokemonSpecies species, int level)
        {
            return (2 * species.BaseSpeed * level / 100) + 5;
        }

        public static int CalculateStat(int baseStat, int level)
        {
            return (2 * baseStat * level / 100) + 5;
        }
    }
}
