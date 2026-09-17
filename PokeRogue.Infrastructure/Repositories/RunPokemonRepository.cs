using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class RunPokemonRepository : IRunPokemonRepository
    {
        private readonly PokeRogueDbContext _context;

        public RunPokemonRepository(PokeRogueDbContext context)
        {
            _context = context;
        }

        public async Task<RunPokemon> CreateAsync(RunPokemon runPokemon)
        {
            _context.RunPokemon.Add(runPokemon);

            await _context.SaveChangesAsync();

            return runPokemon;
        }

        public async Task<bool> RunHasPokemonAsync(int runId)
        {
            return await _context.RunPokemon
                .AnyAsync(pokemon => pokemon.RunId == runId);
        }

        public async Task<List<RunPokemon>> GetByRunIdAsync(int runId)
        {
            return await _context.RunPokemon
                .Include(pokemon => pokemon.PokemonSpecies)
                    .ThenInclude(species => species.AttackLine)
                .Where(pokemon => pokemon.RunId == runId)
                .OrderBy(pokemon => pokemon.PartyPosition)
                .ToListAsync();
        }

        public async Task<RunPokemon?> GetByIdAsync(
            int runPokemonId
        )
        {
            return await _context.RunPokemon
                .Include(pokemon => pokemon.PokemonSpecies)
                    .ThenInclude(species => species.AttackLine)
                .FirstOrDefaultAsync(
                    pokemon => pokemon.Id == runPokemonId
                );
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetNextPartyPositionAsync(int runId)
        {
            int maxPosition = await _context.RunPokemon
                .Where(pokemon => pokemon.RunId == runId)
                .Select(pokemon => (int?)pokemon.PartyPosition)
                .MaxAsync() ?? 0;

            return maxPosition + 1;
        }
    }
}