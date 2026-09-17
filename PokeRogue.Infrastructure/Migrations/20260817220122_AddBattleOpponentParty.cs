using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBattleOpponentParty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpponentAttackStage",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "OpponentCurrentHp",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "OpponentLevel",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "OpponentPokemonSpeciesId",
                table: "Battles");

            migrationBuilder.AddColumn<int>(
                name: "ActiveOpponentPokemonId",
                table: "Battles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BattleOpponentPokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BattleId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonSpeciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentHp = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackStage = table.Column<int>(type: "INTEGER", nullable: false),
                    PartyPosition = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleOpponentPokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleOpponentPokemon_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleOpponentPokemon_PokemonSpecies_PokemonSpeciesId",
                        column: x => x.PokemonSpeciesId,
                        principalTable: "PokemonSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleOpponentPokemon_BattleId",
                table: "BattleOpponentPokemon",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleOpponentPokemon_PokemonSpeciesId",
                table: "BattleOpponentPokemon",
                column: "PokemonSpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleOpponentPokemon");

            migrationBuilder.DropColumn(
                name: "ActiveOpponentPokemonId",
                table: "Battles");

            migrationBuilder.AddColumn<int>(
                name: "OpponentAttackStage",
                table: "Battles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpponentCurrentHp",
                table: "Battles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpponentLevel",
                table: "Battles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpponentPokemonSpeciesId",
                table: "Battles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
