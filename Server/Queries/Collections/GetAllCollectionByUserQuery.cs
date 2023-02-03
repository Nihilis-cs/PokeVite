using MediatR;
using Microsoft.Extensions.Configuration.UserSecrets;
using server.models.DTO;
using server.Models.DTO;

namespace server.Queries;

public class GetAllCollectionByUserQuery : IRequest<ICollection<GetCollectionListDto>>{
    public string UserId { get; set; }
    public GetAllCollectionByUserQuery(string aUserId)
    {
        UserId = aUserId;
    }
}
