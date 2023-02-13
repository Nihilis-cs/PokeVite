using System.Diagnostics.Contracts;
using server.models;

public class UserPokemon
{
    public string PokemonId{get; set;}
    public Pokemon Pokemon{get; set;} = null!;
    public string UserId {get; set;}
    public User User {get; set;} = null!;
}