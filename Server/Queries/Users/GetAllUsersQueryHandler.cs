using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Models.DTO;

namespace server.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ICollection<GetUsersDto>>
{
    private readonly PokeDbContext _DbContext;

    public GetAllUsersQueryHandler(PokeDbContext aDbContext)
    {
        _DbContext = aDbContext;
    }
    public async Task<ICollection<GetUsersDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _DbContext.Users.ToListAsync();
        var userList = new List<GetUsersDto>();
        foreach(var u in users)
        {
            userList.Add(new GetUsersDto{
                Name = u.Name,
                Id = u.Id.ToString()
            });
        }
        
        return userList;
    }
}