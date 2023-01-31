using MediatR;
using server.Models.DTO;

namespace server.Commands;

public class AddUserPokemonCommand : IRequest<string>
{
    public UserPokemonDto UserPokemon { get; set; } = null!;
}