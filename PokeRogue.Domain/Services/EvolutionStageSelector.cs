using PokeRogue.Domain.Models;

namespace PokeRogue.Domain.Services
{
    public static class EvolutionStageSelector
    {
        public static int PickStage(
            EvolutionStageWeights weights
        )
        {
            int totalWeight =
                weights.Stage1 +
                weights.Stage2 +
                weights.Stage3;

            if (totalWeight <= 0)
            {
                throw new InvalidOperationException(
                    "At least one evolution stage must have a positive weight."
                );
            }

            int roll =
                Random.Shared.Next(
                    1,
                    totalWeight + 1
                );

            if (roll <= weights.Stage1)
            {
                return 1;
            }

            roll -= weights.Stage1;

            if (roll <= weights.Stage2)
            {
                return 2;
            }

            return 3;
        }

        public static int PickAvailableStage(
            EvolutionStageWeights configuredWeights,
            IEnumerable<int> availableStages
        )
        {
            var stages =
                availableStages
                    .Where(stage =>
                        stage >= 1 &&
                        stage <= 3
                    )
                    .Distinct()
                    .ToHashSet();

            if (stages.Count == 0)
            {
                throw new InvalidOperationException(
                    "No valid evolution stages are available."
                );
            }

            var availableWeights =
                new EvolutionStageWeights
                {
                    Stage1 =
                        stages.Contains(1)
                            ? configuredWeights.Stage1
                            : 0,

                    Stage2 =
                        stages.Contains(2)
                            ? configuredWeights.Stage2
                            : 0,

                    Stage3 =
                        stages.Contains(3)
                            ? configuredWeights.Stage3
                            : 0
                };

            int configuredTotalWeight =
                availableWeights.Stage1 +
                availableWeights.Stage2 +
                availableWeights.Stage3;

            if (configuredTotalWeight > 0)
            {
                return PickStage(
                    availableWeights
                );
            }

            // Development fallback:
            // if none of the configured stages exist
            // in the current Pokémon pool, choose evenly
            // between the stages that actually exist.
            var fallbackWeights =
                new EvolutionStageWeights
                {
                    Stage1 =
                        stages.Contains(1)
                            ? 1
                            : 0,

                    Stage2 =
                        stages.Contains(2)
                            ? 1
                            : 0,

                    Stage3 =
                        stages.Contains(3)
                            ? 1
                            : 0
                };

            return PickStage(
                fallbackWeights
            );
        }

        public static bool IsStageAllowed(
            int evolutionStage,
            EvolutionStageWeights weights
        )
        {
            return evolutionStage switch
            {
                1 => weights.Stage1 > 0,
                2 => weights.Stage2 > 0,
                3 => weights.Stage3 > 0,
                _ => false
            };
        }
    }
}