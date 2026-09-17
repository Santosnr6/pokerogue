using PokeRogue.Domain.Models;

namespace PokeRogue.Application.Interfaces
{
    public interface IRandomEncounterService
    {
        Task<BattleStartResult> StartEncounterAsync(
            int runId
        );
    }
}