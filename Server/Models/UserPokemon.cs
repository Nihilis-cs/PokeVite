using System.Diagnostics.Contracts;
using server.models;

public class UserPokemon
{
    public Guid PokemonId{get; set;}
    public Pokemon Pokemon{get; set;} = null!;
    public Guid UserId {get; set;}
    public User User {get; set;} = null!;
}