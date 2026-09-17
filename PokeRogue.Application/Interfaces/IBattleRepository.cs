using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface IBattleRepository
    {
        Task<Battle> CreateAsync(Battle battle);
        Task<Battle?> GetByIdAsync(int battleId);
        Task SaveChangesAsync();
    }
}