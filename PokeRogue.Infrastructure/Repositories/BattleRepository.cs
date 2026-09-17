using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Domain.Entities;
using PokeRogue.Infrastructure.Data;

namespace PokeRogue.Infrastructure.Repositories
{
    public class BattleRepository : IBattleRepository
    {
        private readonly PokeRogueDbContext _context;

        public BattleRepository(
            PokeRogueDbContext context
        )
        {
            _context = context;
        }

        public async Task<Battle> CreateAsync(
            Battle battle
        )
        {
            _context.Battles.Add(
                battle
            );

            await _context.SaveChangesAsync();

            return battle;
        }

        public async Task<Battle?> GetByIdAsync(
            int battleId
        )
        {
            return await _context.Battles
                .Include(battle =>
                    battle.OpponentPokemon
                )
                    .ThenInclude(pokemon =>
                        pokemon.PokemonSpecies
                    )
                        .ThenInclude(species =>
                            species.AttackLine
                        )
                .Include(battle =>
                    battle.PlayerParty
                )
                    .ThenInclude(playerPokemon =>
                        playerPokemon.RunPokemon
                    )
                        .ThenInclude(runPokemon =>
                            runPokemon.PokemonSpecies
                        )
                            .ThenInclude(species =>
                                species.AttackLine
                            )
                .FirstOrDefaultAsync(
                    battle =>
                        battle.Id == battleId
                );
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}