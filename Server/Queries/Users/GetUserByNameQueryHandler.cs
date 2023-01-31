using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using server.configuration;
using server.models;
using server.Models.DTO;

public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, GetUsersDto?>
{
    private readonly IConfiguration _Configuration;

    public GetUserByNameQueryHandler(IConfiguration aConfiguration)
    {
        _Configuration = aConfiguration;
    }
    public async Task<GetUsersDto?> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        using (var vConnection = new NpgsqlConnection(Configuration.GetConnectionString(_Configuration)))
        {
            var vUser = await vConnection.QueryFirstOrDefaultAsync<User>("SELECT u.Id, u.Name FROM Users u WHERE u.Name = @Name", new { Name = request.Name });
            if (vUser != null)
            {
                return new GetUsersDto()
                {
                    Name = vUser.Name,
                    Id = vUser.Id.ToString()
                };
            }
        }
        return null;
    }
}