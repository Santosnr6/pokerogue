using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStarterFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStarter",
                table: "PokemonSpecies",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStarter",
                table: "PokemonSpecies");
        }
    }
}
