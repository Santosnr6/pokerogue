using PokeRogue.Application.Services;
using PokeRogue.Domain.Entities;

namespace PokeRogue.Tests.Services
{
    public class CatchRandomizerTests
    {
        [Fact]
        public void PickWeightedPokemon_ShouldReturnThreeUniquePokemon()
        {
            // Arrange
            var catchZone = new List<CatchZone>
            {
                new CatchZone
                {
                    PokemonSpeciesId = 10,
                    Weight = 50,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 10,
                        Name = "Caterpie"
                    }
                },

                new CatchZone
                {
                    PokemonSpeciesId = 13,
                    Weight = 30,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 13,
                        Name = "Weedle"
                    }
                },

                new CatchZone
                {
                    PokemonSpeciesId = 16,
                    Weight = 20,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 16,
                        Name = "Pidgey"
                    }
                },

                new CatchZone
                {
                    PokemonSpeciesId = 19,
                    Weight = 10,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 19,
                        Name = "Rattata"
                    }
                }
            };

            // Act
            var result =
                CatchRandomizer.PickWeightedPokemon(
                    catchZone,
                    3
                );

            // Assert
            Assert.Equal(3, result.Count);

            Assert.Equal(
                3,
                result
                    .Select(pokemon => pokemon.Id)
                    .Distinct()
                    .Count()
            );
        }

        [Fact]
        public void PickWeightedPokemon_ShouldNeverReturnDuplicates()
        {
            var catchZone = new List<CatchZone>
            {
                new CatchZone
                {
                    Weight = 100,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 1,
                        Name = "Pokemon 1"
                    }
                },
                new CatchZone
                {
                    Weight = 50,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 2,
                        Name = "Pokemon 2"
                    }
                },
                new CatchZone
                {
                    Weight = 25,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 3,
                        Name = "Pokemon 3"
                    }
                },
                new CatchZone
                {
                    Weight = 10,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 4,
                        Name = "Pokemon 4"
                    }
                },
                new CatchZone
                {
                    Weight = 1,
                    PokemonSpecies = new PokemonSpecies
                    {
                        Id = 5,
                        Name = "Pokemon 5"
                    }
                }
            };

            for (int i = 0; i < 1000; i++)
            {
                var result =
                    CatchRandomizer.PickWeightedPokemon(
                        catchZone,
                        3
                    );

                int uniqueCount =
                    result
                        .Select(pokemon => pokemon.Id)
                        .Distinct()
                        .Count();

                Assert.Equal(3, uniqueCount);
            }
        }
    }
}