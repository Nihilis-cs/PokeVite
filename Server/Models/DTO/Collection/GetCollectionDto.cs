namespace server.models.DTO;

public class GetCollectionDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string UserId { get; set; } = null!;
    public ICollection<PokeDto> Pokemons { get; set; } = null!;
    public int Count { get; set; }
}