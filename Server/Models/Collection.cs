namespace server.models;
public class Collection
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<CollectionPokemon> Pokemons { get; set; } = null!;
}
