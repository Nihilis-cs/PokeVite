using MediatR;
using Microsoft.EntityFrameworkCore;
using server.models;

namespace server.Commands;

public class AddPokemonToCollectionCommandHandler : IRequestHandler<AddPokemonToCollectionCommand, string>
{
    private readonly PokeDbContext _DbContext;

    public AddPokemonToCollectionCommandHandler(PokeDbContext aDbContext) 
    {
        _DbContext = aDbContext;
    }
    public async Task<string> Handle(AddPokemonToCollectionCommand request, CancellationToken cancellationToken)
    {
        var vDto = request.Dto;
        var vPkmn = await _DbContext.Pokemons.Where(p => p.Name == vDto.pokemonName).FirstAsync();
        var vCollection = await _DbContext.Collections.Where(c => c.Id == vDto.collectionId).FirstAsync();
        var vNewPokeCol = new CollectionPokemon(){PokemonId = vPkmn.Id, Pokemon = vPkmn, CollectionId = vCollection.Id, Collection = vCollection};
        await _DbContext.CollectionPokemons.AddAsync(vNewPokeCol);
        var vRes = await _DbContext.SaveChangesAsync();

        return(vCollection.Name + " updated with " + vPkmn.Name );
    }
}