using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class ItemOptionRepository : IItemOptionRepository
    {
        private readonly PokeRogueDbContext _context;

        public ItemOptionRepository(PokeRogueDbContext context)
        {
            _context = context;
        }

        public async Task<List<ItemOption>> GetByRunAndNodeAsync(
            int runId,
            int mapNodeId
        )
        {
            return await _context.ItemOptions
                .Include(option => option.Item)
                .Where(option =>
                    option.RunId == runId &&
                    option.MapNodeId == mapNodeId
                )
                .ToListAsync();
        }

        public async Task SaveAsync(List<ItemOption> options)
        {
            _context.ItemOptions.AddRange(options);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteByRunAndNodeAsync(
            int runId,
            int mapNodeId
        )
        {
            var options = await _context.ItemOptions
                .Where(option =>
                    option.RunId == runId &&
                    option.MapNodeId == mapNodeId
                )
                .ToListAsync();

            _context.ItemOptions.RemoveRange(options);

            await _context.SaveChangesAsync();
        }
    }
}