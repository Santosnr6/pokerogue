using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPokemonPartyPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartyPosition",
                table: "RunPokemon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartyPosition",
                table: "RunPokemon");
        }
    }
}
