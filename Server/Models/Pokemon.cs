namespace server.models;

public class Pokemon 
{
    public string Name {get; set;} = null!;
    public string Url {get; set;} = null!;
    public int NoPokedex {get; set;}
    public Guid Id {get; set;}
    public ICollection<UserPokemon>? Users {get; set;}
}