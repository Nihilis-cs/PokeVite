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
                name: "fk_userpokemons_pokemons_pokemonid",
                table: "userpokemons");

            migrationBuilder.DropForeignKey(
                name: "fk_userpokemons_users_userid",
                table: "userpokemons");

            migrationBuilder.AddForeignKey(
                name: "fk_userpokemons_pokemons_pokemonid",
                table: "userpokemons",
                column: "pokemonid",
                principalTable: "pokemons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_userpokemons_users_userid",
                table: "userpokemons",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_userpokemons_pokemons_pokemonid",
                table: "userpokemons");

            migrationBuilder.DropForeignKey(
                name: "fk_userpokemons_users_userid",
                table: "userpokemons");

            migrationBuilder.AddForeignKey(
                name: "fk_userpokemons_pokemons_pokemonid",
                table: "userpokemons",
                column: "userid",
                principalTable: "pokemons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_userpokemons_users_userid",
                table: "userpokemons",
                column: "pokemonid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
