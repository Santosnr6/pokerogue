using PokeRogue.Application.Models;
using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface IRunMapRepository
    {
        Task SaveRunNodesAsync(List<RunNode> runNodes);
        Task<GeneratedMap?> GetRunMapAsync(int runId);
        Task<bool> ConnectionExistsAsync(int fromNodeId, int toNodeId);
        Task<RunNode?> GetRunNodeAsync(int runId, int mapNodeId);
        Task MarkCompletedAsync(int runId, int mapNodeId);
    }
}