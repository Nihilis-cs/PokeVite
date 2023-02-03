using MediatR;
using server.models.DTO;

namespace server.Queries;

public class GetCollectionQuery : IRequest<GetCollectionDto>{
    public string ColId { get; set; }
    public GetCollectionQuery(string aColId)
    {
        ColId = aColId;
    }
}
