using System.Security;
using System.Text;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Npgsql;
using server.configuration;
using server.models;
using server.models.DTO;


namespace server.Queries;

public class GetCollectionQueryHandler : IRequestHandler<GetCollectionQuery, GetCollectionDto>
{
    private readonly IConfiguration _Configuration;
    public GetCollectionQueryHandler(IConfiguration aConfiguration)
    {
        _Configuration = aConfiguration;
    }
    public async Task<GetCollectionDto> Handle(GetCollectionQuery request, CancellationToken cancellationToken)
    {
        using (var vConnection = new NpgsqlConnection(Configuration.GetConnectionString(_Configuration)))
        {
            StringBuilder vBuilder = new StringBuilder();
            // J'ai une une collection
            vBuilder.Append("SELECT c.id, c.Name, c.Description FROM Collections c WHERE c.Id = @ColId;");
            // Je veux les pokemons associées
            vBuilder.Append("SELECT p.id, p.name, p.nopokedex, p.url FROM pokemons p");
            vBuilder.Append(" INNER JOIN collectionpokemons cp ON p.id = cp.pokemonid");
            vBuilder.Append(" WHERE cp.CollectionId = @ColId ORDER BY p.nopokedex ASC;");
            var vResultQuery = await vConnection.QueryMultipleAsync(vBuilder.ToString(), new { ColId = Guid.Parse(request.ColId) });
            if (vResultQuery != null)
            {
                var vCollection = vResultQuery.Read<Collection>().First();
                var vRet = new GetCollectionDto(){
                    Name = vCollection.Name,
                    Description = vCollection.Description,
                    UserId = vCollection.UserId.ToString()
                };

                var vListPokemon = vResultQuery.Read<Pokemon>().ToList();
                vRet.Pokemons = new HashSet<PokeDto>();
                foreach (var poke in vListPokemon)
                {
                    vRet.Pokemons.Add(new PokeDto
                    {
                        Name = poke.Name,
                        Url = poke.Url
                    });
                    vRet.Count++;
                }
                return vRet;
            }
        }
        return null;
    }
}