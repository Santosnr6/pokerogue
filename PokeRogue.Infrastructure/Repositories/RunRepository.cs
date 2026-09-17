using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class RunRepository : IRunRepository
    {
        private readonly PokeRogueDbContext _context;

        public RunRepository(PokeRogueDbContext context)
        {
            _context = context;
        }

        public async Task<Run> CreateAsync(Run run)
        {
            _context.Runs.Add(run);
            await _context.SaveChangesAsync();
            return run;
        }

        public async Task<Run?> GetByIdAsync(int id)
        {
            return await _context.Runs
                .Include(run => run.Pokemon)
                    .ThenInclude(pokemon => pokemon.PokemonSpecies)
                .Include(run => run.Items)
                    .ThenInclude(runItem => runItem.Item)
                .FirstOrDefaultAsync(run => run.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
