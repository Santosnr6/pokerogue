using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class CatchOptionRepository : ICatchOptionRepository
    {
        private readonly PokeRogueDbContext _context;

        public CatchOptionRepository (PokeRogueDbContext context)
        {
            _context = context;
        }

        public async Task<List<CatchOption>> GetByRunAndNodeAsync(
            int runId,
            int mapNodeId
        )
        {
            return await _context.CatchOptions
                .Include(option => option.PokemonSpecies)
                .Where(option =>
                    option.RunId == runId &&
                    option.MapNodeId == mapNodeId
                )
                .ToListAsync();
        }

        public async Task SaveAsync(List<CatchOption> options)
        {
            _context.CatchOptions.AddRange(options);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteByRunAndNodeAsync(
            int runId,
            int mapNodeId
        )
        {
            var options = await _context.CatchOptions
                .Where(option =>
                    option.RunId == runId &&
                    option.MapNodeId == mapNodeId
                )
                .ToListAsync();

            _context.CatchOptions.RemoveRange(options);

            await _context.SaveChangesAsync();
        }
    }
}
