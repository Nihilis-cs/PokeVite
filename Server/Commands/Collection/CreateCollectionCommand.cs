using MediatR;
using server.models.DTO;

namespace server.Commands;

public class CreateCollectionCommand : IRequest<string>
{
    public CreateCollectionDto Collection {get; set;} = null!;

}