using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Application.Models;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class RunMapRepository : IRunMapRepository
    {
        private readonly PokeRogueDbContext _context;

        public RunMapRepository(
            PokeRogueDbContext context
        )
        {
            _context = context;
        }

        public async Task SaveRunNodesAsync(
            List<RunNode> runNodes
        )
        {
            _context.RunNodes.AddRange(
                runNodes
            );

            await _context.SaveChangesAsync();
        }

        public async Task<GeneratedMap?> GetRunMapAsync(
            int runId
        )
        {
            int cityNumber =
                await _context.Runs
                    .Where(run =>
                        run.Id == runId
                    )
                    .Select(run =>
                        run.CurrentCity
                    )
                    .FirstOrDefaultAsync();

            if (cityNumber == 0)
            {
                return null;
            }

            var mapNodes =
                await _context.MapNodes
                    .Where(node =>
                        node.CityNumber ==
                        cityNumber
                    )
                    .ToListAsync();

            if (mapNodes.Count == 0)
            {
                return null;
            }

            var mapNodeIds =
                mapNodes
                    .Select(node =>
                        node.Id
                    )
                    .ToList();

            var runNodes =
                await _context.RunNodes
                    .Where(node =>
                        node.RunId == runId &&
                        mapNodeIds.Contains(
                            node.MapNodeId
                        )
                    )
                    .ToListAsync();

            if (runNodes.Count == 0)
            {
                return null;
            }

            var connections =
                await _context.MapConnections
                    .Where(connection =>
                        mapNodeIds.Contains(
                            connection.FromNodeId
                        ) &&
                        mapNodeIds.Contains(
                            connection.ToNodeId
                        )
                    )
                    .ToListAsync();

            return new GeneratedMap
            {
                RunNodes =
                    runNodes,

                Connections =
                    connections
            };
        }

        public async Task<bool> ConnectionExistsAsync(
            int fromNodeId,
            int toNodeId
        )
        {
            return await _context.MapConnections
                .AnyAsync(connection =>
                    connection.FromNodeId ==
                    fromNodeId &&
                    connection.ToNodeId ==
                    toNodeId
                );
        }

        public async Task<RunNode?> GetRunNodeAsync(
            int runId,
            int mapNodeId
        )
        {
            return await _context.RunNodes
                .FirstOrDefaultAsync(node =>
                    node.RunId ==
                    runId &&
                    node.MapNodeId ==
                    mapNodeId
                );
        }

        public async Task MarkCompletedAsync(
            int runId,
            int mapNodeId
        )
        {
            var runNode =
                await _context.RunNodes
                    .FirstOrDefaultAsync(node =>
                        node.RunId ==
                        runId &&
                        node.MapNodeId ==
                        mapNodeId
                    );

            if (runNode == null)
            {
                throw new InvalidOperationException(
                    "Run node was not found."
                );
            }

            runNode.IsCompleted =
                true;

            await _context.SaveChangesAsync();
        }
    }
}