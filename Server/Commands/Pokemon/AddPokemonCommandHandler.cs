using System.Text.RegularExpressions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using server.models;

namespace server.Commands;

public class AddPokemonCommandHandler : IRequestHandler<AddPokemonCommand, string>
{
    private readonly PokeDbContext _DbContext;
    public AddPokemonCommandHandler(PokeDbContext aDbContext)
    {
        _DbContext = aDbContext;
    }
    public async Task<string> Handle(AddPokemonCommand request, CancellationToken cancellationToken)
    {
        var vDto = request.Pokemon;
        var vPkmn = await _DbContext.Pokemons.Where(p => p.Name == request.Pokemon.Name).FirstOrDefaultAsync();

        if (vPkmn == null) //Si le Pokemon n'est pas dans la base
        {
            vPkmn = new Pokemon()
            {
                Name = request.Pokemon.Name,
                Url = request.Pokemon.Url!,
                NoPokedex = int.Parse(Regex.Match(request.Pokemon.Url!, @"\d+").Value)

            };
            await _DbContext.Pokemons.AddAsync(vPkmn);
        }
        var vRet = await _DbContext.SaveChangesAsync();
        if (vRet == 0)
        {
            return "Error code 69 - He non, ça a planté";
        }

        return vPkmn.Id.ToString();
    }
}

// public class AddListPokemonCommandHandler : IRequestHandler<AddListPokemonCommand, int>
// {
//     private readonly PokeDbContext _DbContext;
//     public AddListPokemonCommandHandler(PokeDbContext aDbContext)
//     {
//         _DbContext = aDbContext;
//     }
//     public async Task<int> Handle(AddListPokemonCommand request, CancellationToken cancellationToken)
//     {
//         var vDto = request.Pokemon;
//         var Pokedex = 0;
//         foreach (var poke in vDto)
//         {
//             Pokedex++;
//             await _DbContext.Pokemons.AddAsync(new Pokemon
//             {
//                 Name = poke.Name,
//                 Url = poke.Url!,
//                 NoPokedex = Pokedex
//             });
//         }
//         var vRet = await _DbContext.SaveChangesAsync();
//         return vRet;
//     }
// }