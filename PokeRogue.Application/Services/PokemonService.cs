using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;

namespace PokeRogue.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<List<PokemonSpecies>> GetAllAsync()
        {
            return await _pokemonRepository.GetAllAsync();
        }

        public async Task<PokemonSpecies?> GetByIdAsync(int id)
        {
            return await _pokemonRepository.GetByIdAsync(id);
        }

        public async Task<List<PokemonSpecies>> GetStartersAsync()
        {
            return await _pokemonRepository.GetStartersAsync();
        }
    }
}