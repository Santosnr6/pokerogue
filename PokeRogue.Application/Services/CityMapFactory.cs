using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Services
{
    public class CityMapFactory : ICityMapFactory
    {
        public MapLayout CreateCityMap(int cityNumber)
        {
            // Gives each city its own unique range of IDs:
            // City 1 = 1-23
            // City 2 = 24-46
            // City 3 = 47-69
            int Id(int localId) => ((cityNumber - 1) * 23) + localId;

            var nodes = new List<MapNode>
            {
                // Row 1 - Start
                new MapNode { Id = Id(1), CityNumber = cityNumber, Row = 1, Column = 1 },

                // Row 2
                new MapNode { Id = Id(2), CityNumber = cityNumber, Row = 2, Column = 1 },
                new MapNode { Id = Id(3), CityNumber = cityNumber, Row = 2, Column = 2 },

                // Row 3
                new MapNode { Id = Id(4), CityNumber = cityNumber, Row = 3, Column = 1 },
                new MapNode { Id = Id(5), CityNumber = cityNumber, Row = 3, Column = 2 },
                new MapNode { Id = Id(6), CityNumber = cityNumber, Row = 3, Column = 3 },

                // Row 4
                new MapNode { Id = Id(7), CityNumber = cityNumber, Row = 4, Column = 1 },
                new MapNode { Id = Id(8), CityNumber = cityNumber, Row = 4, Column = 2 },
                new MapNode { Id = Id(9), CityNumber = cityNumber, Row = 4, Column = 3 },
                new MapNode { Id = Id(10), CityNumber = cityNumber, Row = 4, Column = 4 },

                // Row 5
                new MapNode { Id = Id(11), CityNumber = cityNumber, Row = 5, Column = 1 },
                new MapNode { Id = Id(12), CityNumber = cityNumber, Row = 5, Column = 2 },
                new MapNode { Id = Id(13), CityNumber = cityNumber, Row = 5, Column = 3 },

                // Row 6
                new MapNode { Id = Id(14), CityNumber = cityNumber, Row = 6, Column = 1 },
                new MapNode { Id = Id(15), CityNumber = cityNumber, Row = 6, Column = 2 },
                new MapNode { Id = Id(16), CityNumber = cityNumber, Row = 6, Column = 3 },
                new MapNode { Id = Id(17), CityNumber = cityNumber, Row = 6, Column = 4 },

                // Row 7
                new MapNode { Id = Id(18), CityNumber = cityNumber, Row = 7, Column = 1 },
                new MapNode { Id = Id(19), CityNumber = cityNumber, Row = 7, Column = 2 },
                new MapNode { Id = Id(20), CityNumber = cityNumber, Row = 7, Column = 3 },

                // Row 8 - Pokémon Center will be placed on one of these
                new MapNode { Id = Id(21), CityNumber = cityNumber, Row = 8, Column = 1 },
                new MapNode { Id = Id(22), CityNumber = cityNumber, Row = 8, Column = 2 },

                // Row 9 - Gym
                new MapNode { Id = Id(23), CityNumber = cityNumber, Row = 9, Column = 1 }
            };

            var connections = new List<MapConnection>
            {
                // Row 1 -> Row 2
                new MapConnection { FromNodeId = Id(1), ToNodeId = Id(2) },
                new MapConnection { FromNodeId = Id(1), ToNodeId = Id(3) },

                // Row 2 -> Row 3
                new MapConnection { FromNodeId = Id(2), ToNodeId = Id(4) },
                new MapConnection { FromNodeId = Id(2), ToNodeId = Id(5) },

                new MapConnection { FromNodeId = Id(3), ToNodeId = Id(5) },
                new MapConnection { FromNodeId = Id(3), ToNodeId = Id(6) },

                // Row 3 -> Row 4
                new MapConnection { FromNodeId = Id(4), ToNodeId = Id(7) },
                new MapConnection { FromNodeId = Id(4), ToNodeId = Id(8) },

                new MapConnection { FromNodeId = Id(5), ToNodeId = Id(8) },
                new MapConnection { FromNodeId = Id(5), ToNodeId = Id(9) },

                new MapConnection { FromNodeId = Id(6), ToNodeId = Id(9) },
                new MapConnection { FromNodeId = Id(6), ToNodeId = Id(10) },

                // Row 4 -> Row 5
                new MapConnection { FromNodeId = Id(7), ToNodeId = Id(11) },

                new MapConnection { FromNodeId = Id(8), ToNodeId = Id(11) },
                new MapConnection { FromNodeId = Id(8), ToNodeId = Id(12) },

                new MapConnection { FromNodeId = Id(9), ToNodeId = Id(12) },
                new MapConnection { FromNodeId = Id(9), ToNodeId = Id(13) },

                new MapConnection { FromNodeId = Id(10), ToNodeId = Id(13) },

                // Row 5 -> Row 6
                new MapConnection { FromNodeId = Id(11), ToNodeId = Id(14) },
                new MapConnection { FromNodeId = Id(11), ToNodeId = Id(15) },

                new MapConnection { FromNodeId = Id(12), ToNodeId = Id(15) },
                new MapConnection { FromNodeId = Id(12), ToNodeId = Id(16) },

                new MapConnection { FromNodeId = Id(13), ToNodeId = Id(16) },
                new MapConnection { FromNodeId = Id(13), ToNodeId = Id(17) },

                // Row 6 -> Row 7
                new MapConnection { FromNodeId = Id(14), ToNodeId = Id(18) },

                new MapConnection { FromNodeId = Id(15), ToNodeId = Id(18) },
                new MapConnection { FromNodeId = Id(15), ToNodeId = Id(19) },

                new MapConnection { FromNodeId = Id(16), ToNodeId = Id(19) },
                new MapConnection { FromNodeId = Id(16), ToNodeId = Id(20) },

                new MapConnection { FromNodeId = Id(17), ToNodeId = Id(20) },

                // Row 7 -> Row 8
                new MapConnection { FromNodeId = Id(18), ToNodeId = Id(21) },

                new MapConnection { FromNodeId = Id(19), ToNodeId = Id(21) },
                new MapConnection { FromNodeId = Id(19), ToNodeId = Id(22) },

                new MapConnection { FromNodeId = Id(20), ToNodeId = Id(22) },

                // Row 8 -> Gym
                new MapConnection { FromNodeId = Id(21), ToNodeId = Id(23) },
                new MapConnection { FromNodeId = Id(22), ToNodeId = Id(23) }
            };

            return new MapLayout
            {
                Nodes = nodes,
                Connections = connections
            };
        }
    }
}