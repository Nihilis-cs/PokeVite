using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using server.configuration;
using server.models;
using server.Models.DTO;

namespace server.Queries;

public class GetAllPokemonByUserQueryHandler : IRequestHandler<GetAllPokemonByUserQuery, ICollection<GetPokemonByUserDto>>
{
    private readonly IConfiguration _Configuration;
    public GetAllPokemonByUserQueryHandler(IConfiguration aConfiguration)
    {
        _Configuration = aConfiguration;
    }
    public async Task<ICollection<GetPokemonByUserDto>> Handle(GetAllPokemonByUserQuery request, CancellationToken cancellationToken)
    {
        using (var vConnection = new NpgsqlConnection(Configuration.GetConnectionString(_Configuration)))
        {
            var vPkmns = await vConnection.QueryAsync<Pokemon>("SELECT p.Name, p.Url FROM pokemons p INNER JOIN userpokemons u ON p.id = u.pokemonid WHERE u.userid = @UserId", new { UserId = new Guid(request.UserId) });
            if (vPkmns != null)
            {
                var vPokeList = new List<GetPokemonByUserDto>();
                foreach (var p in vPkmns)
                {
                    vPokeList.Add(new GetPokemonByUserDto
                    {
                        Name = p.Name,
                        Url = p.Url
                    });
                }
                return vPokeList;
            }
        }
        return null;
    }
}