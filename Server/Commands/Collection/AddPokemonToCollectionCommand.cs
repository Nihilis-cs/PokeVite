using MediatR;
using server.Models.DTO;

namespace server.Commands;
public class AddPokemonToCollectionCommand : IRequest<string>
{
    public AddPokemonToCollectionDto Dto {get; set;} = null!;

}