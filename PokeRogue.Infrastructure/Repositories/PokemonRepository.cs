using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokeRogueDbContext _context;

        public PokemonRepository(PokeRogueDbContext context)
        {
            _context = context;
        }

        public async Task<List<PokemonSpecies>> GetAllAsync()
        {
            return await _context.PokemonSpecies
                .Include(p => p.AttackLine)
                .ToListAsync();
        }

        public async Task<PokemonSpecies?> GetByIdAsync(int id)
        {
            return await _context.PokemonSpecies
                .Include(p => p.AttackLine)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PokemonSpecies>> GetStartersAsync()
        {
            return await _context.PokemonSpecies
                .Include(p => p.AttackLine)
                .Where(p => p.IsStarter)
                .ToListAsync();
        }
    }
}