using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Interfaces
{
    public interface ICatchService
    {
        Task<List<PokemonSpecies>> GetCatchOptionsAsync(
            int runId
        );
        Task<RunPokemon?> ChoosePokemonAsync(
            int runId,
            int pokemonSpeciesId
        );
    }
}