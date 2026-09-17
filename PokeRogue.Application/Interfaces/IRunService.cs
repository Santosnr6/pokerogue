using PokeRogue.Application.Models;
using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface IRunService
    {
        Task<Run> StartNewAsync();
        Task<Run?> GetRunAsync(int id);
        Task<MoveResult?> MoveToNodeAsync(
            int runId,
            int targetNodeId
        );
        Task<RunPokemon?> ChooseStarterAsync(
            int runId,
            int pokemonSpeciesId
        );
        Task AdvanceToNextCityAsync(int runId);
    }
}
