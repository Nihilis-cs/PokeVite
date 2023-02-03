﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    [DbContext(typeof(PokeDbContext))]
    [Migration("20230202081357_Collections")]
    partial class Collections
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserPokemon", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid")
                        .HasColumnName("pokemonid");

                    b.HasKey("UserId", "PokemonId")
                        .HasName("pk_userpokemons");

                    b.HasIndex("PokemonId")
                        .HasDatabaseName("ix_userpokemons_pokemonid");

                    b.ToTable("userpokemons", (string)null);
                });

            modelBuilder.Entity("server.models.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_collection");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_collection_userid");

                    b.ToTable("collection", (string)null);
                });

            modelBuilder.Entity("server.models.CollectionPokemon", b =>
                {
                    b.Property<Guid>("CollectionId")
                        .HasColumnType("uuid")
                        .HasColumnName("collectionid");

                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid")
                        .HasColumnName("pokemonid");

                    b.HasKey("CollectionId", "PokemonId")
                        .HasName("pk_collectionpokemon");

                    b.HasIndex("PokemonId")
                        .HasDatabaseName("ix_collectionpokemon_pokemonid");

                    b.ToTable("collectionpokemon", (string)null);
                });

            modelBuilder.Entity("server.models.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("NoPokedex")
                        .HasColumnType("integer")
                        .HasColumnName("nopokedex");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("pk_pokemons");

                    b.ToTable("pokemons", (string)null);
                });

            modelBuilder.Entity("server.models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("UserPokemon", b =>
                {
                    b.HasOne("server.models.Pokemon", "Pokemon")
                        .WithMany("Users")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_userpokemons_pokemons_pokemonid");

                    b.HasOne("server.models.User", "User")
                        .WithMany("Pokemons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_userpokemons_users_userid");

                    b.Navigation("Pokemon");

                    b.Navigation("User");
                });

            modelBuilder.Entity("server.models.Collection", b =>
                {
                    b.HasOne("server.models.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_collection_users_userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("server.models.CollectionPokemon", b =>
                {
                    b.HasOne("server.models.Collection", "Collection")
                        .WithMany("Pokemons")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_collectionpokemon_collection_collectionid");

                    b.HasOne("server.models.Pokemon", "Pokemon")
                        .WithMany("Collections")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_collectionpokemon_pokemons_pokemonid");

                    b.Navigation("Collection");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("server.models.Collection", b =>
                {
                    b.Navigation("Pokemons");
                });

            modelBuilder.Entity("server.models.Pokemon", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("server.models.User", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Pokemons");
                });
#pragma warning restore 612, 618
        }
    }
}