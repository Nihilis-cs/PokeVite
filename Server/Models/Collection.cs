namespace server.models;
public class Collection
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<CollectionPokemon> Pokemons { get; set; } = null!;
}
