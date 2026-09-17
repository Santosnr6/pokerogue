using PokeRogue.Domain.Models;

namespace PokeRogue.Domain.Services
{
    public static class CityRegistry
    {
        public static CityInfo GetCity(
            int cityNumber
        )
        {
            return cityNumber switch
            {
                1 => new CityInfo
                {
                    Number = 1,
                    Name = "Pewter City",
                    Description =
                        "A rugged city surrounded by mountains.",

                    WildPokemonMinLevel = 3,
                    WildPokemonMaxLevel = 5,

                    TrainerPokemonMinLevel = 4,
                    TrainerPokemonMaxLevel = 5,

                    CatchEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        },

                    WildEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        },

                    TrainerEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        }
                },

                2 => new CityInfo
                {
                    Number = 2,
                    Name = "Cerulean City",
                    Description =
                        "A bright city surrounded by waterways.",

                    WildPokemonMinLevel = 9,
                    WildPokemonMaxLevel = 11,

                    TrainerPokemonMinLevel = 10,
                    TrainerPokemonMaxLevel = 12,

                    CatchEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        },

                    WildEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        },

                    TrainerEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        }
                },

                3 => new CityInfo
                {
                    Number = 3,
                    Name = "Vermilion City",
                    Description =
                        "A busy port city by the sea.",

                    WildPokemonMinLevel = 14,
                    WildPokemonMaxLevel = 16,

                    TrainerPokemonMinLevel = 15,
                    TrainerPokemonMaxLevel = 17,

                    CatchEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        },

                    WildEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        },

                    TrainerEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        }
                },

                4 => new CityInfo
                {
                    Number = 4,
                    Name = "Celadon City",
                    Description =
                        "A large green city filled with shops and gardens.",

                    WildPokemonMinLevel = 19,
                    WildPokemonMaxLevel = 21,

                    TrainerPokemonMinLevel = 20,
                    TrainerPokemonMaxLevel = 22,

                    CatchEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        },

                    WildEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 25,
                            Stage2 = 75
                        },

                    TrainerEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 15,
                            Stage2 = 85
                        }
                },

                5 => new CityInfo
                {
                    Number = 5,
                    Name = "Fuchsia City",
                    Description =
                        "A peaceful city close to wild areas and safari grounds.",

                    WildPokemonMinLevel = 24,
                    WildPokemonMaxLevel = 26,

                    TrainerPokemonMinLevel = 25,
                    TrainerPokemonMaxLevel = 27,

                    CatchEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 100
                        },

                    WildEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 10,
                            Stage2 = 90
                        },

                    TrainerEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage2 = 100
                        }
                },

                6 => new CityInfo
                {
                    Number = 6,
                    Name = "Saffron City",
                    Description =
                        "A major city filled with powerful trainers.",

                    WildPokemonMinLevel = 29,
                    WildPokemonMaxLevel = 31,

                    TrainerPokemonMinLevel = 30,
                    TrainerPokemonMaxLevel = 32,

                    CatchEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 35,
                            Stage2 = 65
                        },

                    WildEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage2 = 45,
                            Stage3 = 55
                        },

                    TrainerEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage2 = 30,
                            Stage3 = 70
                        }
                },

                7 => new CityInfo
                {
                    Number = 7,
                    Name = "Cinnabar Island",
                    Description =
                        "A volcanic island with unusually strong Pokémon.",

                    WildPokemonMinLevel = 34,
                    WildPokemonMaxLevel = 36,

                    TrainerPokemonMinLevel = 35,
                    TrainerPokemonMaxLevel = 37,

                    CatchEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 20,
                            Stage2 = 80
                        },

                    WildEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage2 = 20,
                            Stage3 = 80
                        },

                    TrainerEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage2 = 10,
                            Stage3 = 90
                        }
                },

                8 => new CityInfo
                {
                    Number = 8,
                    Name = "Viridian City",
                    Description =
                        "The final city before the end of the run.",

                    WildPokemonMinLevel = 39,
                    WildPokemonMaxLevel = 41,

                    TrainerPokemonMinLevel = 40,
                    TrainerPokemonMaxLevel = 42,

                    CatchEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage1 = 10,
                            Stage2 = 90
                        },

                    WildEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage3 = 100
                        },

                    TrainerEvolutionWeights =
                        new EvolutionStageWeights
                        {
                            Stage3 = 100
                        }
                },

                _ => throw new InvalidOperationException(
                    $"City {cityNumber} is not configured."
                )
            };
        }
    }
}