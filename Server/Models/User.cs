namespace server.models;
public class User
{
    public string Name {get; set;} = null!;
    public Guid Id {get; set;}
    public ICollection<UserPokemon>? Pokemons {get; set;}
}