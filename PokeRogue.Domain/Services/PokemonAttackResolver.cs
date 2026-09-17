using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Models;

namespace PokeRogue.Domain.Services
{
    public static class PokemonAttackResolver
    {
        public static PokemonAttack GetAttack(
            PokemonSpecies species,
            int attackStage
        )
        {
            var attackLine = species.AttackLine;

            return attackStage switch
            {
                1 => new PokemonAttack
                {
                    Name = attackLine.Stage1Name,
                    Power = attackLine.Stage1Power,
                    Type = attackLine.Type,
                    Category = attackLine.Category
                },

                2 => new PokemonAttack
                {
                    Name = attackLine.Stage2Name,
                    Power = attackLine.Stage2Power,
                    Type = attackLine.Type,
                    Category = attackLine.Category
                },

                3 => new PokemonAttack
                {
                    Name = attackLine.Stage3Name,
                    Power = attackLine.Stage3Power,
                    Type = attackLine.Type,
                    Category = attackLine.Category
                },

                _ => throw new ArgumentOutOfRangeException(
                    nameof(attackStage),
                    "Attack stage must be between 1 and 3."
                )
            };
        }
    }
}