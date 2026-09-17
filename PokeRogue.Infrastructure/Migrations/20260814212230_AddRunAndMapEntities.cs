using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRunAndMapEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapNode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CityNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Row = table.Column<int>(type: "INTEGER", nullable: false),
                    Column = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFixedEvent = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapNode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MapConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FromNodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToNodeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapConnections_MapNode_FromNodeId",
                        column: x => x.FromNodeId,
                        principalTable: "MapNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapConnections_MapNode_ToNodeId",
                        column: x => x.ToNodeId,
                        principalTable: "MapNode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapConnections_FromNodeId",
                table: "MapConnections",
                column: "FromNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MapConnections_ToNodeId",
                table: "MapConnections",
                column: "ToNodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapConnections");

            migrationBuilder.DropTable(
                name: "MapNode");
        }
    }
}
