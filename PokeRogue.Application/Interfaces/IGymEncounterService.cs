using PokeRogue.Domain.Models;

namespace PokeRogue.Application.Interfaces
{
    public interface IGymEncounterService
    {
        Task<GymEncounterStartResult> StartEncounterAsync(int runId);
    }
}