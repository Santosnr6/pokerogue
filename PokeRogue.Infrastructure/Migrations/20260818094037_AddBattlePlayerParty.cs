using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBattlePlayerParty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BattlePlayerPokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BattleId = table.Column<int>(type: "INTEGER", nullable: false),
                    RunPokemonId = table.Column<int>(type: "INTEGER", nullable: false),
                    EligibleForLevelUp = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattlePlayerPokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattlePlayerPokemon_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattlePlayerPokemon_RunPokemon_RunPokemonId",
                        column: x => x.RunPokemonId,
                        principalTable: "RunPokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattlePlayerPokemon_BattleId",
                table: "BattlePlayerPokemon",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_BattlePlayerPokemon_RunPokemonId",
                table: "BattlePlayerPokemon",
                column: "RunPokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattlePlayerPokemon");
        }
    }
}
