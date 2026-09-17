using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class TrainerTypeRepository
        : ITrainerTypeRepository
    {
        private readonly PokeRogueDbContext _context;

        public TrainerTypeRepository(
            PokeRogueDbContext context
        )
        {
            _context = context;
        }

        public async Task<List<TrainerType>> GetAllAsync()
        {
            return await _context.TrainerTypes
                .ToListAsync();
        }
    }
}