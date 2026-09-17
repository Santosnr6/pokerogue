using Microsoft.EntityFrameworkCore;
using PokeRogue.Domain.Entities;

namespace PokeRogue.Infrastructure.Data
{
    public class PokeRogueDbContext : DbContext
    {
        public PokeRogueDbContext(
            DbContextOptions<PokeRogueDbContext> options
        ) : base(options)
        {
        }

        public DbSet<PokemonSpecies> PokemonSpecies { get; set; }
        public DbSet<AttackLine> AttackLines { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TrainerType> TrainerTypes { get; set; }
        public DbSet<MapConnection> MapConnections { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<RunPokemon> RunPokemon { get; set; }
        public DbSet<RunNode> RunNodes { get; set; }
        public DbSet<MapNode> MapNodes { get; set; }
        public DbSet<CatchOption> CatchOptions { get; set; }
        public DbSet<CatchZone> CatchZones { get; set; }
        public DbSet<ItemOption> ItemOptions { get; set; }
        public DbSet<RunItem> RunItems { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BattleOpponentPokemon> BattleOpponentPokemon { get; set; }

        public DbSet<BattlePlayerPokemon> BattlePlayerPokemon =>
            Set<BattlePlayerPokemon>();

        protected override void OnModelCreating(
            ModelBuilder modelBuilder
        )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BattlePlayerPokemon>()
                .HasOne(playerPokemon =>
                    playerPokemon.Battle
                )
                .WithMany(battle =>
                    battle.PlayerParty
                )
                .HasForeignKey(playerPokemon =>
                    playerPokemon.BattleId
                )
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BattlePlayerPokemon>()
                .HasOne(playerPokemon =>
                    playerPokemon.RunPokemon
                )
                .WithMany()
                .HasForeignKey(playerPokemon =>
                    playerPokemon.RunPokemonId
                )
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}