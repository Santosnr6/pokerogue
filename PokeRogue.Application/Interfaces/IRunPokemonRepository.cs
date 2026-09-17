using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface IRunPokemonRepository
    {
        Task<RunPokemon> CreateAsync(RunPokemon runPokemon);
        Task<bool> RunHasPokemonAsync(int runId);
        Task<List<RunPokemon>> GetByRunIdAsync(int runId);
        Task<RunPokemon?> GetByIdAsync(int runPokemonId);
        Task SaveChangesAsync();
        Task<int> GetNextPartyPositionAsync(int runId);
    }
}