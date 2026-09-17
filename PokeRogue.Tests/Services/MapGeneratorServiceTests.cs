using PokeRogue.Application.Services;

namespace PokeRogue.Tests.Services
{
    public class MapGeneratorServiceTests
    {
        [Fact]
        public void GenerateMap_ShouldCreate22RunNodes()
        {
            // Arrange
            var mapFactory = new CityMapFactory();
            var generator = new MapGeneratorService();

            var layout = mapFactory.CreateCityMap(1);

            // Act
            var result = generator.GenerateMap(
                runId: 1,
                layout.Nodes
            );

            // Assert
            Assert.Equal(22, result.Count);
        }

        [Fact]
        public void GenerateMap_ShouldNotCreateEventForStartNode()
        {
            var mapFactory = new CityMapFactory();
            var generator = new MapGeneratorService();

            var layout = mapFactory.CreateCityMap(1);

            var result = generator.GenerateMap(1, layout.Nodes);

            Assert.DoesNotContain(
                result,
                node => node.MapNodeId == 1
            );
        }

        [Fact]
        public void GenerateMap_ShouldAlwaysPlaceCatchPokemonOnNode2()
        {
            var mapFactory = new CityMapFactory();
            var generator = new MapGeneratorService();

            var layout = mapFactory.CreateCityMap(1);

            var result = generator.GenerateMap(1, layout.Nodes);

            var catchNode = result.Single(
                node => node.Type == Domain.Enums.NodeEventType.CatchPokemon
            );

            Assert.Equal(2, catchNode.MapNodeId);
        }

        [Fact]
        public void GenerateMap_ShouldAlwaysPlaceGymLeaderOnNode23()
        {
            var mapFactory = new CityMapFactory();
            var generator = new MapGeneratorService();

            var layout = mapFactory.CreateCityMap(1);

            var result = generator.GenerateMap(1, layout.Nodes);

            var gymNode = result.Single(
                node => node.Type == Domain.Enums.NodeEventType.GymLeader
            );

            Assert.Equal(23, gymNode.MapNodeId);
        }

        [Fact]
        public void GenerateMap_ShouldContainAtLeastSixTrainers()
        {
            var mapFactory = new CityMapFactory();
            var generator = new MapGeneratorService();

            var layout = mapFactory.CreateCityMap(1);

            var result = generator.GenerateMap(1, layout.Nodes);

            int trainerCount = result.Count(
                node => node.Type == Domain.Enums.NodeEventType.PokemonTrainer
            );

            Assert.True(trainerCount >= 6);
        }

        [Fact]
        public void GenerateMap_ShouldAlwaysRespectGenerationRules()
        {
            var mapFactory = new CityMapFactory();
            var generator = new MapGeneratorService();

            var layout = mapFactory.CreateCityMap(1);

            for (int i = 0; i < 1000; i++)
            {
                var result = generator.GenerateMap(i, layout.Nodes);

                Assert.Equal(22, result.Count);

                Assert.Single(
                    result.Where(n =>
                        n.Type == Domain.Enums.NodeEventType.CatchPokemon)
                );

                Assert.Single(
                    result.Where(n =>
                        n.Type == Domain.Enums.NodeEventType.GymLeader)
                );

                Assert.Single(
                    result.Where(n =>
                        n.Type == Domain.Enums.NodeEventType.PokemonCenter)
                );

                Assert.True(
                    result.Count(n =>
                        n.Type == Domain.Enums.NodeEventType.PokemonTrainer) >= 6
                );

                Assert.True(
                    result.Count(n =>
                        n.Type == Domain.Enums.NodeEventType.Item) >= 2
                );

                Assert.True(
                    result.Count(n =>
                        n.Type == Domain.Enums.NodeEventType.TM) >= 1
                );
            }
        }
    }
}