using MediatR;
using server.models.DTO;
using server.Models.DTO;

namespace server.Commands;

public class AddPokemonCommand : IRequest<string>
{
    public PokeDto Pokemon { get; set; } = null!;
}

// public class AddListPokemonCommand : IRequest<int>
// {
//     public PokeDto[] Pokemon { get; set; } = null!;
// }