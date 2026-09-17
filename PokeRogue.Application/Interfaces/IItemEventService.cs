using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface IItemEventService
    {
        Task<List<Item>> GetItemOptionsAsync(int runId);
        Task<Item?> ChooseItemAsync(
            int runId,
            int itemId
        );
    }
}