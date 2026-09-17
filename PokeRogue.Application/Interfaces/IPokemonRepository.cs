using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface IPokemonRepository
    {
        Task<List<PokemonSpecies>> GetAllAsync();
        Task<PokemonSpecies?> GetByIdAsync(int id);
        Task<List<PokemonSpecies>> GetStartersAsync();
    }
}