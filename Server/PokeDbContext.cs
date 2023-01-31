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

        modelBuilder.Entity<UserPokemon>(b =>
        {
            b.HasKey(up => new { up.UserId, up.PokemonId });
            b.HasOne<Pokemon>(up => up.Pokemon)
                    .WithMany(p => p.Users)
                    .HasForeignKey(up => up.PokemonId);
            b.HasOne<User>(up => up.User)
                        .WithMany(u => u.Pokemons)
                        .HasForeignKey(up => up.UserId);
        });
    }

}