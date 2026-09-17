using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface ITmEventService
    {
        Task UpgradePokemonAttackAsync(
            int runId,
            int runPokemonId
        );
    }
}