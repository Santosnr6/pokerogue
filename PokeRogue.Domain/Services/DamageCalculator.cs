using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;
using PokeRogue.Domain.Models;

namespace PokeRogue.Domain.Services
{
    public static class DamageCalculator
    {
        private const double CriticalMultiplier = 1.5;
        private const int CriticalChancePercent = 10;

        public static DamageResult Calculate(
            BattleParticipant attacker,
            BattleParticipant defender
        )
        {
            PokemonSpecies attackerSpecies =
                attacker.PokemonSpecies;

            PokemonSpecies defenderSpecies =
                defender.PokemonSpecies;

            PokemonAttack attack =
                PokemonAttackResolver.GetAttack(
                    attackerSpecies,
                    attacker.AttackStage
                );

            int attackStat;
            int defenseStat;

            // Physical attacks use Attack vs Defense.
            // Special attacks use Special Attack vs Special Defense.
            if (attack.Category == AttackCategory.Physical)
            {
                attackStat =
                    PokemonStatCalculator.CalculateAttack(
                        attackerSpecies,
                        attacker.Level
                    );

                defenseStat =
                    PokemonStatCalculator.CalculateDefense(
                        defenderSpecies,
                        defender.Level
                    );
            }
            else
            {
                attackStat =
                    PokemonStatCalculator.CalculateSpecialAttack(
                        attackerSpecies,
                        attacker.Level
                    );

                defenseStat =
                    PokemonStatCalculator.CalculateSpecialDefense(
                        defenderSpecies,
                        defender.Level
                    );
            }

            double baseDamage =
                (
                    (
                        (2.0 * attacker.Level / 5.0 + 2)
                        * attack.Power
                        * attackStat
                        / defenseStat
                    )
                    / 50.0
                )
                + 2;

            double typeMultiplier =
                TypeEffectivenessService.GetMultiplier(
                    attack.Type,
                    defenderSpecies
                );

            bool isCritical =
                Random.Shared.Next(100)
                < CriticalChancePercent;

            double criticalMultiplier =
                isCritical
                    ? CriticalMultiplier
                    : 1.0;

            double randomModifier =
                Random.Shared.NextDouble() * 0.15 + 0.85;

            double finalDamage =
                baseDamage
                * typeMultiplier
                * criticalMultiplier
                * randomModifier;

            int damage =
                Math.Max(
                    1,
                    (int)Math.Floor(finalDamage)
                );

            return new DamageResult
            {
                Damage = damage,
                IsCritical = isCritical,
                TypeMultiplier = typeMultiplier
            };
        }
    }
}