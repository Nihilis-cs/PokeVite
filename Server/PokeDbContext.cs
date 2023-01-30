using Microsoft.EntityFrameworkCore;
using server.configuration;
using server.models;
public class PokeDbContext : DbContext
{
    public PokeDbContext(DbContextOptions<PokeDbContext> options) : base(options)
    {}
    public DbSet<Pokemon> Pokemons { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserPokemon>().HasKey(up => new { up.UserId, up.PokemonId });
        modelBuilder.Entity<UserPokemon>()
                    .HasOne<Pokemon>(up => up.Pokemon)
                    .WithMany(p => p.Users)
                    .HasForeignKey(up => up.UserId);
        modelBuilder.Entity<UserPokemon>()
                    .HasOne<User>(up => up.User)
                    .WithMany(u => u.Pokemons)
                    .HasForeignKey(up => up.PokemonId);
    }

}