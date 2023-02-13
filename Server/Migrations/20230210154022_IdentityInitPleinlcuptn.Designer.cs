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
    [Migration("20230210154022_IdentityInitPleinlcuptn")]
    partial class IdentityInitPleinlcuptn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claimtype");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claimvalue");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("roleid");

                    b.HasKey("Id")
                        .HasName("pk_aspnetroleclaims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_aspnetroleclaims_roleid");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claimtype");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claimvalue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_aspnetuserclaims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_aspnetuserclaims_userid");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("loginprovider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("providerkey");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("providerdisplayname");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_aspnetuserlogins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_aspnetuserlogins_userid");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("loginprovider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_aspnetusertokens");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datecreation");

                    b.Property<DateTime>("DateExpiration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dateexpiration");

                    b.Property<string>("IdUtilisateur")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("idutilisateur");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("token");

                    b.HasKey("Id")
                        .HasName("pk_refresh_token");

                    b.HasIndex("IdUtilisateur")
                        .HasDatabaseName("ix_refresh_token_idutilisateur");

                    b.ToTable("REFRESH_TOKEN", (string)null);
                });

            modelBuilder.Entity("UserPokemon", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.Property<string>("PokemonId")
                        .HasColumnType("text")
                        .HasColumnName("pokemonid");

                    b.HasKey("UserId", "PokemonId")
                        .HasName("pk_userpokemons");

                    b.HasIndex("PokemonId")
                        .HasDatabaseName("ix_userpokemons_pokemonid");

                    b.ToTable("userpokemons", (string)null);
                });

            modelBuilder.Entity("server.models.Collection", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.HasKey("Id")
                        .HasName("pk_collections");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_collections_userid");

                    b.ToTable("collections", (string)null);
                });

            modelBuilder.Entity("server.models.CollectionPokemon", b =>
                {
                    b.Property<string>("CollectionId")
                        .HasColumnType("text")
                        .HasColumnName("collectionid");

                    b.Property<string>("PokemonId")
                        .HasColumnType("text")
                        .HasColumnName("pokemonid");

                    b.HasKey("CollectionId", "PokemonId")
                        .HasName("pk_collectionpokemons");

                    b.HasIndex("PokemonId")
                        .HasDatabaseName("ix_collectionpokemons_pokemonid");

                    b.ToTable("collectionpokemons", (string)null);
                });

            modelBuilder.Entity("server.models.Pokemon", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
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

            modelBuilder.Entity("server.models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrencystamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalizedname");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("server.models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("accessfailedcount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrencystamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("emailconfirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockoutenabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockoutend");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalizedemail");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalizedusername");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("passwordhash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phonenumber");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phonenumberconfirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("securitystamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("twofactorenabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_aspnetusers");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("server.models.UtilisateurRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("userid");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("roleid");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_utilisateur_role");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_utilisateur_role_roleid");

                    b.ToTable("UTILISATEUR_ROLE", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("server.models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_aspnetroleclaims_aspnetroles_roleid");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("server.models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_aspnetuserclaims_aspnetusers_userid");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("server.models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_aspnetuserlogins_aspnetusers_userid");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("server.models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_aspnetusertokens_aspnetusers_userid");
                });

            modelBuilder.Entity("RefreshToken", b =>
                {
                    b.HasOne("server.models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUtilisateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_refresh_token_aspnetusers_idutilisateur");

                    b.Navigation("User");
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
                        .HasConstraintName("fk_userpokemons_user_userid");

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
                        .HasConstraintName("fk_collections_user_userid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("server.models.CollectionPokemon", b =>
                {
                    b.HasOne("server.models.Collection", "Collection")
                        .WithMany("Pokemons")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_collectionpokemons_collections_collectionid");

                    b.HasOne("server.models.Pokemon", "Pokemon")
                        .WithMany("Collections")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_collectionpokemons_pokemons_pokemonid");

                    b.Navigation("Collection");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("server.models.UtilisateurRole", b =>
                {
                    b.HasOne("server.models.Role", "Role")
                        .WithMany("UtilisateurRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_utilisateur_role_roles_roleid");

                    b.HasOne("server.models.User", "User")
                        .WithMany("UtilisateurRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_utilisateur_role_aspnetusers_userid");

                    b.Navigation("Role");

                    b.Navigation("User");
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

            modelBuilder.Entity("server.models.Role", b =>
                {
                    b.Navigation("UtilisateurRoles");
                });

            modelBuilder.Entity("server.models.User", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Pokemons");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UtilisateurRoles");
                });
#pragma warning restore 612, 618
        }
    }
}