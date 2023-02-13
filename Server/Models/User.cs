
using Microsoft.AspNetCore.Identity;

namespace server.models;
public class User : IdentityUser
{
    public string Name { get; set; } = null!;
    public ICollection<UserPokemon>? Pokemons { get; set; }
    public ICollection<Collection>? Collections { get; set; }
    public ICollection<UtilisateurRole> UtilisateurRoles { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
}