using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPokemonEvolutionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EvolveAtLevel",
                table: "PokemonSpecies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvolvesIntoSpeciesId",
                table: "PokemonSpecies",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvolveAtLevel",
                table: "PokemonSpecies");

            migrationBuilder.DropColumn(
                name: "EvolvesIntoSpeciesId",
                table: "PokemonSpecies");
        }
    }
}
