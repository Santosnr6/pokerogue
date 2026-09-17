using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Domain.Enums;

namespace PokeRogue.Application.Services
{
    public class MapGeneratorService : IMapGeneratorService
    {
        public List<RunNode> GenerateMap(
            int runId,
            List<MapNode> mapNodes
        )
        {
            if (mapNodes.Count == 0)
            {
                throw new ArgumentException("Map must contain nodes!");
            }

            var runNodes = new List<RunNode>();

            int startRow = mapNodes.Min(node => node.Row);
            int firstEventRow = startRow + 1;
            int gymRow = mapNodes.Max(node => node.Row);

            // Start row contains no events at all.
            var eventNodes = mapNodes
                .Where(node => node.Row != startRow)
                .ToList();

            if (eventNodes.Count == 0)
            {
                throw new InvalidOperationException(
                    "Map must contain event nodes."
                );
            }

            // Catch Pokémon:
            // left-most node on the first row after START.
            MapNode catchNode = eventNodes
                .Where(node => node.Row == firstEventRow)
                .OrderBy(node => node.Column)
                .FirstOrDefault()
                ?? throw new InvalidOperationException(
                    "No valid Catch Pokémon node was found."
                );

            // Gym:
            // final node on the highest row.
            MapNode gymNode = eventNodes
                .Where(node => node.Row == gymRow)
                .OrderBy(node => node.Column)
                .FirstOrDefault()
                ?? throw new InvalidOperationException(
                    "No valid Gym Leader node was found."
                );

            // Pokémon Center:
            // random node on the row directly before the Gym.
            var pokemonCenterCandidates = eventNodes
                .Where(node =>
                    node.Row == gymRow - 1 &&
                    node.Id != catchNode.Id &&
                    node.Id != gymNode.Id)
                .ToList();

            if (pokemonCenterCandidates.Count == 0)
            {
                throw new InvalidOperationException(
                    "No valid position found for Pokémon Center."
                );
            }

            MapNode pokemonCenterNode =
                pokemonCenterCandidates[
                    Random.Shared.Next(pokemonCenterCandidates.Count)
                ];

            // Fixed / semi-fixed events

            runNodes.Add(
                CreateRunNode(
                    runId,
                    catchNode,
                    NodeEventType.CatchPokemon
                )
            );

            runNodes.Add(
                CreateRunNode(
                    runId,
                    pokemonCenterNode,
                    NodeEventType.PokemonCenter
                )
            );

            runNodes.Add(
                CreateRunNode(
                    runId,
                    gymNode,
                    NodeEventType.GymLeader
                )
            );

            // Nodes that are still available for random events.
            var availableNodes = eventNodes
                .Where(node =>
                    node.Id != catchNode.Id &&
                    node.Id != pokemonCenterNode.Id &&
                    node.Id != gymNode.Id)
                .OrderBy(_ => Random.Shared.Next())
                .ToList();

            // Minimum event requirements.

            AddEvents(
                runNodes,
                availableNodes,
                runId,
                NodeEventType.PokemonTrainer,
                6
            );

            AddEvents(
                runNodes,
                availableNodes,
                runId,
                NodeEventType.Item,
                2
            );

            AddEvents(
                runNodes,
                availableNodes,
                runId,
                NodeEventType.TM,
                1
            );

            // All remaining nodes are randomly assigned
            // one of the allowed random event types.
            NodeEventType[] randomEventTypes =
            {
                NodeEventType.RandomEncounter,
                NodeEventType.PokemonTrainer,
                NodeEventType.Item,
                NodeEventType.TM
            };

            foreach (MapNode node in availableNodes)
            {
                NodeEventType randomEvent =
                    randomEventTypes[
                        Random.Shared.Next(randomEventTypes.Length)
                    ];

                runNodes.Add(
                    CreateRunNode(
                        runId,
                        node,
                        randomEvent
                    )
                );
            }

            return runNodes;
        }

        private static void AddEvents(
            List<RunNode> runNodes,
            List<MapNode> availableNodes,
            int runId,
            NodeEventType eventType,
            int amount
        )
        {
            if (availableNodes.Count < amount)
            {
                throw new InvalidOperationException(
                    $"Not enough map nodes to place {amount} {eventType} events."
                );
            }

            for (int i = 0; i < amount; i++)
            {
                MapNode node = availableNodes[0];

                availableNodes.RemoveAt(0);

                runNodes.Add(
                    CreateRunNode(
                        runId,
                        node,
                        eventType
                    )
                );
            }
        }

        private static RunNode CreateRunNode(
            int runId,
            MapNode mapNode,
            NodeEventType eventType
        )
        {
            return new RunNode
            {
                RunId = runId,
                MapNodeId = mapNode.Id,
                Type = eventType,
                IsCompleted = false
            };
        }
    }
}