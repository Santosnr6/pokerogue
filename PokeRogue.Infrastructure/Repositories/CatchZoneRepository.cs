using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class CatchZoneRepository : ICatchZoneRepository
    {
        private readonly PokeRogueDbContext _context;

        public CatchZoneRepository(PokeRogueDbContext context)
        {
            _context = context;
        }

        public async Task<List<CatchZone>> GetByCityAsync(
            int cityNumber
        )
        {
            return await _context.CatchZones
                .Include(zone => zone.PokemonSpecies)
                .Where(zone => zone.CityNumber == cityNumber)
                .ToListAsync();
        }
    }
}