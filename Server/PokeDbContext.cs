using Microsoft.EntityFrameworkCore;
using server.configuration;
using server.models;
public class PokeDbContext : DbContext
{
    public PokeDbContext(DbContextOptions<PokeDbContext> options) : base(options)
    { }
    public DbSet<Pokemon> Pokemons { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserPokemon> UserPokemons { get; set; } = null!;
    public DbSet<Collection> Collections {get; set;}= null!;
    public DbSet<CollectionPokemon> CollectionPokemons {get; set;} = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }

}