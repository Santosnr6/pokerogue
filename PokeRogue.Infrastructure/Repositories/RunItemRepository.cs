using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class RunItemRepository : IRunItemRepository
    {
        private readonly PokeRogueDbContext _context;

        public RunItemRepository(PokeRogueDbContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(
            int runId,
            int itemId
        )
        {
            var existingItem = await _context.RunItems
                .FirstOrDefaultAsync(runItem =>
                    runItem.RunId == runId &&
                    runItem.ItemId == itemId
                );

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                var runItem = new RunItem
                {
                    RunId = runId,
                    ItemId = itemId,
                    Quantity = 1
                };

                _context.RunItems.Add(runItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<RunItem>> GetInventoryAsync(
            int runId
        )
        {
            return await _context.RunItems
                .Include(runItem => runItem.Item)
                .Where(runItem => runItem.RunId == runId)
                .ToListAsync();
        }
    }
}