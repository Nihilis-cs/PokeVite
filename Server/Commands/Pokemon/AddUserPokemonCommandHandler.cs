using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using server.models;

namespace server.Commands;

public class AddUserPokemonCommandHandler : IRequestHandler<AddUserPokemonCommand, string>
{
    private readonly PokeDbContext _DbContext;
    public AddUserPokemonCommandHandler(PokeDbContext aDbContext)
    {
        _DbContext = aDbContext;
    }
    public async Task<string> Handle(AddUserPokemonCommand request, CancellationToken cancellationToken)
    {
        var vDto = request.UserPokemon;
        var vPkmn = await _DbContext.Pokemons.Where(p => p.Name == request.UserPokemon.PokemonName).FirstOrDefaultAsync();

        if (vPkmn == null) //Si le Pokemon n'est pas dans la base
        {
            vPkmn = new Pokemon()
            {
                Name = request.UserPokemon.PokemonName,
                Url = request.UserPokemon.PokemonUrl!
            };
            await _DbContext.Pokemons.AddAsync(vPkmn);
        }

        var vUser = await _DbContext.Users.Where(u => u.Name == request.UserPokemon.UserName).FirstOrDefaultAsync();
        if (vUser == null)
        {
            return "Error code 666 - Unknown user";
        }

        var vNewUserPokemon = new UserPokemon
        {
            PokemonId = vPkmn.Id,
            UserId = vUser.Id,
        };
        await _DbContext.UserPokemons.AddAsync(vNewUserPokemon);
        
        var vRet = await _DbContext.SaveChangesAsync();
        if (vRet == 0)
        {
            return "Error code 69 - He non, ça a planté";
        }

        return vNewUserPokemon.PokemonId.ToString();
    }
}