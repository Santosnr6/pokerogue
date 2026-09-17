using PokeRogue.Application.Models;

namespace PokeRogue.Application.Interfaces
{
    public interface IRunMapService
    {
        GeneratedMap CreateRunMap(int runId, int cityNumber);
        Task<GeneratedMap?> GetRunMapAsync(int runId);
    }
}