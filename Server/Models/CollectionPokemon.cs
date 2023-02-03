namespace server.models;

public class CollectionPokemon
{
    public Guid PokemonId { get; set; }
    public Pokemon Pokemon { get; set; } = null!;
    public Guid CollectionId { get; set; }
    public Collection Collection { get; set; } = null!;
}