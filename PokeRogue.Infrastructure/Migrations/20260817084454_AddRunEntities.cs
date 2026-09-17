using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeRogue.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRunEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapConnections_MapNode_FromNodeId",
                table: "MapConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_MapConnections_MapNode_ToNodeId",
                table: "MapConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_RunPokemons_Items_HeldItemId",
                table: "RunPokemons");

            migrationBuilder.DropForeignKey(
                name: "FK_RunPokemons_PokemonSpecies_PokemonSpeciesId",
                table: "RunPokemons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RunPokemons",
                table: "RunPokemons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapNode",
                table: "MapNode");

            migrationBuilder.RenameTable(
                name: "RunPokemons",
                newName: "RunPokemon");

            migrationBuilder.RenameTable(
                name: "MapNode",
                newName: "MapNodes");

            migrationBuilder.RenameIndex(
                name: "IX_RunPokemons_PokemonSpeciesId",
                table: "RunPokemon",
                newName: "IX_RunPokemon_PokemonSpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_RunPokemons_HeldItemId",
                table: "RunPokemon",
                newName: "IX_RunPokemon_HeldItemId");

            migrationBuilder.AddColumn<int>(
                name: "RunId",
                table: "RunPokemon",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsStartNode",
                table: "MapNodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RunPokemon",
                table: "RunPokemon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapNodes",
                table: "MapNodes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Runs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurrentCity = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentNodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RunStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunNodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RunId = table.Column<int>(type: "INTEGER", nullable: false),
                    MapNodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunNodes_MapNodes_MapNodeId",
                        column: x => x.MapNodeId,
                        principalTable: "MapNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RunNodes_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RunPokemon_RunId",
                table: "RunPokemon",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_RunNodes_MapNodeId",
                table: "RunNodes",
                column: "MapNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RunNodes_RunId",
                table: "RunNodes",
                column: "RunId");

            migrationBuilder.AddForeignKey(
                name: "FK_MapConnections_MapNodes_FromNodeId",
                table: "MapConnections",
                column: "FromNodeId",
                principalTable: "MapNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapConnections_MapNodes_ToNodeId",
                table: "MapConnections",
                column: "ToNodeId",
                principalTable: "MapNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunPokemon_Items_HeldItemId",
                table: "RunPokemon",
                column: "HeldItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RunPokemon_PokemonSpecies_PokemonSpeciesId",
                table: "RunPokemon",
                column: "PokemonSpeciesId",
                principalTable: "PokemonSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunPokemon_Runs_RunId",
                table: "RunPokemon",
                column: "RunId",
                principalTable: "Runs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapConnections_MapNodes_FromNodeId",
                table: "MapConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_MapConnections_MapNodes_ToNodeId",
                table: "MapConnections");

            migrationBuilder.DropForeignKey(
                name: "FK_RunPokemon_Items_HeldItemId",
                table: "RunPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_RunPokemon_PokemonSpecies_PokemonSpeciesId",
                table: "RunPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_RunPokemon_Runs_RunId",
                table: "RunPokemon");

            migrationBuilder.DropTable(
                name: "RunNodes");

            migrationBuilder.DropTable(
                name: "Runs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RunPokemon",
                table: "RunPokemon");

            migrationBuilder.DropIndex(
                name: "IX_RunPokemon_RunId",
                table: "RunPokemon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapNodes",
                table: "MapNodes");

            migrationBuilder.DropColumn(
                name: "RunId",
                table: "RunPokemon");

            migrationBuilder.DropColumn(
                name: "IsStartNode",
                table: "MapNodes");

            migrationBuilder.RenameTable(
                name: "RunPokemon",
                newName: "RunPokemons");

            migrationBuilder.RenameTable(
                name: "MapNodes",
                newName: "MapNode");

            migrationBuilder.RenameIndex(
                name: "IX_RunPokemon_PokemonSpeciesId",
                table: "RunPokemons",
                newName: "IX_RunPokemons_PokemonSpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_RunPokemon_HeldItemId",
                table: "RunPokemons",
                newName: "IX_RunPokemons_HeldItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RunPokemons",
                table: "RunPokemons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapNode",
                table: "MapNode",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MapConnections_MapNode_FromNodeId",
                table: "MapConnections",
                column: "FromNodeId",
                principalTable: "MapNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MapConnections_MapNode_ToNodeId",
                table: "MapConnections",
                column: "ToNodeId",
                principalTable: "MapNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RunPokemons_Items_HeldItemId",
                table: "RunPokemons",
                column: "HeldItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RunPokemons_PokemonSpecies_PokemonSpeciesId",
                table: "RunPokemons",
                column: "PokemonSpeciesId",
                principalTable: "PokemonSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
