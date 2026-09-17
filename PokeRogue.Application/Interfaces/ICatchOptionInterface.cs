using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface ICatchOptionRepository
    {
        Task<List<CatchOption>> GetByRunAndNodeAsync(
            int runId,
            int mapNodeId
        );
        Task SaveAsync(List<CatchOption> options);
        Task DeleteByRunAndNodeAsync(
            int runId,
            int mapNodeId
        );
    }
}