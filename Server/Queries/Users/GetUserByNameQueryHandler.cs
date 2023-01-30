using MediatR;
using Microsoft.EntityFrameworkCore;
using server.Models.DTO;

public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, GetUsersDto>
{
    private readonly PokeDbContext _DbContext;

    public GetUserByNameQueryHandler(PokeDbContext aDbContext)
    {
        _DbContext = aDbContext;
    }
    public async Task<GetUsersDto> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        var user = await _DbContext.Users.Where(u => u.Name == request.Name).FirstOrDefaultAsync();
        if (user != null){
            return new GetUsersDto(){ 
                Name= user.Name,
                Id= user.Id.ToString()
            };
        }
        return null;
    }
}