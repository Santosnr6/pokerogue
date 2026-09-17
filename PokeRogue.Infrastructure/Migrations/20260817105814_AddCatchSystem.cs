using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCatchSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatchOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RunId = table.Column<int>(type: "INTEGER", nullable: false),
                    MapNodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonSpeciesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatchOptions_PokemonSpecies_PokemonSpeciesId",
                        column: x => x.PokemonSpeciesId,
                        principalTable: "PokemonSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatchZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonSpeciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatchZones_PokemonSpecies_PokemonSpeciesId",
                        column: x => x.PokemonSpeciesId,
                        principalTable: "PokemonSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatchOptions_PokemonSpeciesId",
                table: "CatchOptions",
                column: "PokemonSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CatchZones_PokemonSpeciesId",
                table: "CatchZones",
                column: "PokemonSpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatchOptions");

            migrationBuilder.DropTable(
                name: "CatchZones");
        }
    }
}
