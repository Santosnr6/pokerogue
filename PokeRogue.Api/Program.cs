using Microsoft.EntityFrameworkCore;
using PokeRogue.Application.Interfaces;
using PokeRogue.Application.Services;
using PokeRogue.Infrastructure.Data;
using PokeRogue.Infrastructure.Repositories;
using System.Text.Json.Serialization;

namespace PokeRogue.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter()
                    );
                });
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<PokeRogueDbContext>(options =>
                options.UseSqlite(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

            builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
            builder.Services.AddScoped<IPokemonService, PokemonService>();
            builder.Services.AddScoped<IMapGeneratorService, MapGeneratorService>();
            builder.Services.AddScoped<ICityMapFactory, CityMapFactory>();
            builder.Services.AddScoped<IRunMapService, RunMapService>();
            builder.Services.AddScoped<IRunMapRepository, RunMapRepository>();
            builder.Services.AddScoped<IRunRepository, RunRepository>();
            builder.Services.AddScoped<IRunService, RunService>();
            builder.Services.AddScoped<IRunPokemonRepository, RunPokemonRepository>();
            builder.Services.AddScoped<ICatchOptionRepository, CatchOptionRepository>();
            builder.Services.AddScoped<ICatchZoneRepository, CatchZoneRepository>();
            builder.Services.AddScoped<ICatchService, CatchService>();
            builder.Services.AddScoped<IItemOptionRepository, ItemOptionRepository>();
            builder.Services.AddScoped<IRunItemRepository, RunItemRepository>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();
            builder.Services.AddScoped<IItemEventService, ItemEventService>();
            builder.Services.AddScoped<ITmEventService, TmEventService>();
            builder.Services.AddScoped<IPokemonCenterService, PokemonCenterService>();
            builder.Services.AddScoped<IBattleRepository, BattleRepository>(); 
            builder.Services.AddScoped<IBattleService, BattleService>();
            builder.Services.AddScoped<IRandomEncounterService, RandomEncounterService>();
            builder.Services.AddScoped<ITrainerTypeRepository, TrainerTypeRepository>();
            builder.Services.AddScoped<ITrainerEncounterService, TrainerEncounterService>();
            builder.Services.AddScoped<IGymEncounterService, GymEncounterService>();

            var app = builder.Build();

            // Seed database
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<PokeRogueDbContext>();

                DbSeeder.Seed(dbContext);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}