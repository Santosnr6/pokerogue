using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllAsync();
    }
}