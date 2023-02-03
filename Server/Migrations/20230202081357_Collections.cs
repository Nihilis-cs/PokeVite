using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Collections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collection",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_collection", x => x.id);
                    table.ForeignKey(
                        name: "fk_collection_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "collectionpokemon",
                columns: table => new
                {
                    pokemonid = table.Column<Guid>(type: "uuid", nullable: false),
                    collectionid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_collectionpokemon", x => new { x.collectionid, x.pokemonid });
                    table.ForeignKey(
                        name: "fk_collectionpokemon_collection_collectionid",
                        column: x => x.collectionid,
                        principalTable: "collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_collectionpokemon_pokemons_pokemonid",
                        column: x => x.pokemonid,
                        principalTable: "pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_collection_userid",
                table: "collection",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_collectionpokemon_pokemonid",
                table: "collectionpokemon",
                column: "pokemonid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collectionpokemon");

            migrationBuilder.DropTable(
                name: "collection");
        }
    }
}
