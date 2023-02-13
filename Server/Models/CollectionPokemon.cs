namespace server.models;

public class CollectionPokemon
{
    public string PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null!;
    public string CollectionId { get; set; }
    public Collection Collection { get; set; } = null!;
}