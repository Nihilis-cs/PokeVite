using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using server.models;


public class PokeDbContext : IdentityDbContext<User, Role, String, IdentityUserClaim<String>, UtilisateurRole, IdentityUserLogin<String>, IdentityRoleClaim<String>, IdentityUserToken<String>>
{
    public PokeDbContext(DbContextOptions<PokeDbContext> options) : base(options)
    { }
    public DbSet<Pokemon> Pokemons { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserPokemon> UserPokemons { get; set; } = null!;
    public DbSet<Collection> Collections { get; set; } = null!;
    public DbSet<CollectionPokemon> CollectionPokemons { get; set; } = null!;
    public DbSet<UtilisateurRole> UtilisateurRoles { get; set; } = null!;
    public DbSet<RefreshToken> Refresh_Token { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(b =>
        {
            b.HasKey(u => u.Id);
        });

        modelBuilder.Entity<Pokemon>(b =>
        {
            b.HasKey(u => u.Id);
        });

        modelBuilder.Entity<Collection>(b =>
        {
            b.HasKey(u => u.Id);
            b.HasOne<User>(c => c.User)
                    .WithMany(u => u.Collections)
                    .HasForeignKey(c => c.UserId);
        });

        modelBuilder.Entity<UserPokemon>(b => //Abandon?
        {
            b.HasKey(up => new { up.UserId, up.PokemonId });
            b.HasOne<Pokemon>(up => up.Pokemon)
                    .WithMany(p => p.Users)
                    .HasForeignKey(up => up.PokemonId);
            b.HasOne<User>(up => up.User)
                    .WithMany(u => u.Pokemons)
                    .HasForeignKey(up => up.UserId);
        });

        modelBuilder.Entity<CollectionPokemon>(b =>
        {
            b.HasKey(up => new { up.CollectionId, up.PokemonId });
            b.HasOne<Pokemon>(cp => cp.Pokemon)
                    .WithMany(p => p.Collections)
                    .HasForeignKey(cp => cp.PokemonId);
            b.HasOne<Collection>(cp => cp.Collection)
                    .WithMany(c => c.Pokemons)
                    .HasForeignKey(cp => cp.CollectionId);
        });

        modelBuilder.Entity<RefreshToken>(b =>
            {
                b.HasKey(rt => rt.Id);
                b.Property(rt => rt.Token).HasMaxLength(150);
                b.HasOne(rt => rt.User)
                            .WithMany(u => u.RefreshTokens)
                            .HasForeignKey(rt => rt.IdUtilisateur)
                            .OnDelete(DeleteBehavior.Cascade)
                            .IsRequired();
                b.ToTable("REFRESH_TOKEN");
            });

        modelBuilder.Entity<Role>(b =>
        {
            b.HasKey(r => r.Id);
            b.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
            b.ToTable("roles");
            b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
            b.Property(r => r.Name).HasMaxLength(256);
            b.Property(r => r.NormalizedName).HasMaxLength(256);
            b.HasMany<UtilisateurRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
        });

        modelBuilder.Entity<UtilisateurRole>(b =>
        {
            b.ToTable("UTILISATEUR_ROLE");
            b.HasKey(ur => new { ur.UserId, ur.RoleId });
            b.HasOne(ur => ur.Role)
                           .WithMany(r => r.UtilisateurRoles)
                           .HasForeignKey(ur => ur.RoleId)
                           .IsRequired();
            b.HasOne(ur => ur.User)
                           .WithMany(r => r.UtilisateurRoles)
                           .HasForeignKey(ur => ur.UserId)
                           .IsRequired();
        });
    }

}