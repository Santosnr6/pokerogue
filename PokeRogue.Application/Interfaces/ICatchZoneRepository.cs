using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface ICatchZoneRepository
    {
        Task<List<CatchZone>> GetByCityAsync(int cityNumber);
    }
}