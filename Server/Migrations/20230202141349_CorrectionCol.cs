using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_collection_users_userid",
                table: "collection");

            migrationBuilder.DropForeignKey(
                name: "fk_collectionpokemon_collection_collectionid",
                table: "collectionpokemon");

            migrationBuilder.DropForeignKey(
                name: "fk_collectionpokemon_pokemons_pokemonid",
                table: "collectionpokemon");

            migrationBuilder.DropPrimaryKey(
                name: "pk_collectionpokemon",
                table: "collectionpokemon");

            migrationBuilder.DropPrimaryKey(
                name: "pk_collection",
                table: "collection");

            migrationBuilder.RenameTable(
                name: "collectionpokemon",
                newName: "collectionpokemons");

            migrationBuilder.RenameTable(
                name: "collection",
                newName: "collections");

            migrationBuilder.RenameIndex(
                name: "ix_collectionpokemon_pokemonid",
                table: "collectionpokemons",
                newName: "ix_collectionpokemons_pokemonid");

            migrationBuilder.RenameIndex(
                name: "ix_collection_userid",
                table: "collections",
                newName: "ix_collections_userid");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "collections",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_collectionpokemons",
                table: "collectionpokemons",
                columns: new[] { "collectionid", "pokemonid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_collections",
                table: "collections",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_collectionpokemons_collections_collectionid",
                table: "collectionpokemons",
                column: "collectionid",
                principalTable: "collections",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_collectionpokemons_pokemons_pokemonid",
                table: "collectionpokemons",
                column: "pokemonid",
                principalTable: "pokemons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_collections_users_userid",
                table: "collections",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_collectionpokemons_collections_collectionid",
                table: "collectionpokemons");

            migrationBuilder.DropForeignKey(
                name: "fk_collectionpokemons_pokemons_pokemonid",
                table: "collectionpokemons");

            migrationBuilder.DropForeignKey(
                name: "fk_collections_users_userid",
                table: "collections");

            migrationBuilder.DropPrimaryKey(
                name: "pk_collections",
                table: "collections");

            migrationBuilder.DropPrimaryKey(
                name: "pk_collectionpokemons",
                table: "collectionpokemons");

            migrationBuilder.DropColumn(
                name: "description",
                table: "collections");

            migrationBuilder.RenameTable(
                name: "collections",
                newName: "collection");

            migrationBuilder.RenameTable(
                name: "collectionpokemons",
                newName: "collectionpokemon");

            migrationBuilder.RenameIndex(
                name: "ix_collections_userid",
                table: "collection",
                newName: "ix_collection_userid");

            migrationBuilder.RenameIndex(
                name: "ix_collectionpokemons_pokemonid",
                table: "collectionpokemon",
                newName: "ix_collectionpokemon_pokemonid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_collection",
                table: "collection",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_collectionpokemon",
                table: "collectionpokemon",
                columns: new[] { "collectionid", "pokemonid" });

            migrationBuilder.AddForeignKey(
                name: "fk_collection_users_userid",
                table: "collection",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_collectionpokemon_collection_collectionid",
                table: "collectionpokemon",
                column: "collectionid",
                principalTable: "collection",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_collectionpokemon_pokemons_pokemonid",
                table: "collectionpokemon",
                column: "pokemonid",
                principalTable: "pokemons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
