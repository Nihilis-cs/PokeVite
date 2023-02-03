using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Npgsql;
using server.configuration;
using server.models;
using server.models.DTO;
using server.Models.DTO;

namespace server.Queries;

public class GetAllCollectionByUserQueryHandler : IRequestHandler<GetAllCollectionByUserQuery, ICollection<GetCollectionListDto>>
{
    private readonly IConfiguration _Configuration;
    public GetAllCollectionByUserQueryHandler(IConfiguration aConfiguration)
    {
        _Configuration = aConfiguration;
    }
    public async Task<ICollection<GetCollectionListDto>> Handle(GetAllCollectionByUserQuery request, CancellationToken cancellationToken)
    {
        using (var vConnection = new NpgsqlConnection(Configuration.GetConnectionString(_Configuration)))
        {
            var vCollections = await vConnection.QueryAsync<Collection>("SELECT c.id, c.name, c.description, c.userid FROM collections c WHERE c.userid = @UserId", new { UserId = new Guid(request.UserId) });
            if (vCollections != null)
            {
                var vColList = new List<GetCollectionListDto>();
                foreach (var c in vCollections)
                {
                    vColList.Add(new GetCollectionListDto
                    {
                        Name = c.Name,
                        UserId = c.UserId.ToString(),
                        Description = c.Description,
                        ColId = c.Id.ToString()
                    });
                }
                return vColList;
            }
        }
        return null;
    }
}