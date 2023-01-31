using MediatR;
using Microsoft.Extensions.Configuration.UserSecrets;
using server.Models.DTO;

namespace server.Queries;

public class GetAllPokemonByUserQuery : IRequest<ICollection<GetPokemonByUserDto>>{
    public string UserId { get; set; }
    public GetAllPokemonByUserQuery(string aUserId)
    {
        UserId = aUserId;
    }
}
