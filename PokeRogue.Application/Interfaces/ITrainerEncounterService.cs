using PokeRogue.Domain.Models;

namespace PokeRogue.Application.Interfaces
{
    public interface ITrainerEncounterService
    {
        Task<TrainerEncounterStartResult>
            StartEncounterAsync(int runId);
    }
}