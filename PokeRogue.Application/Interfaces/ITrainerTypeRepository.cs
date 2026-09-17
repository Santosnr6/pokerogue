using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface ITrainerTypeRepository
    {
        Task<List<TrainerType>> GetAllAsync();
    }
}