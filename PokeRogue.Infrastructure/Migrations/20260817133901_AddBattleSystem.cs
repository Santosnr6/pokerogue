using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBattleSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stage1Power",
                table: "AttackLines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stage2Power",
                table: "AttackLines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stage3Power",
                table: "AttackLines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RunId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerPokemonId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpponentPokemonSpeciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpponentLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    OpponentCurrentHp = table.Column<int>(type: "INTEGER", nullable: false),
                    OpponentAttackStage = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPlayerTurn = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropColumn(
                name: "Stage1Power",
                table: "AttackLines");

            migrationBuilder.DropColumn(
                name: "Stage2Power",
                table: "AttackLines");

            migrationBuilder.DropColumn(
                name: "Stage3Power",
                table: "AttackLines");
        }
    }
}
