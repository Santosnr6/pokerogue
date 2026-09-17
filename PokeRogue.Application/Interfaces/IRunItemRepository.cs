using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface IRunItemRepository
    {
        Task AddItemAsync(int runId, int itemId);
        Task<List<RunItem>> GetInventoryAsync(int runId);
    }
}