using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class ManytomanyOopsie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Users_UserId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_UserId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pokemons");

            migrationBuilder.CreateTable(
                name: "UserPokemon",
                columns: table => new
                {
                    PokemonId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPokemon", x => new { x.UserId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_UserPokemon_Pokemons_UserId",
                        column: x => x.UserId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPokemon_Users_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPokemon_PokemonId",
                table: "UserPokemon",
                column: "PokemonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPokemon");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Pokemons",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_UserId",
                table: "Pokemons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Users_UserId",
                table: "Pokemons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
