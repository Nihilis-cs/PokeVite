using MediatR;
using server.models;

namespace server.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly PokeDbContext _DbContext;

    public CreateUserCommandHandler(PokeDbContext aDbContext) 
    {
        _DbContext = aDbContext;
    }
    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var vDto = request.User;

        var vNewUser = new User(){Name = vDto.Name};
        await _DbContext.Users.AddAsync(vNewUser);
        await _DbContext.SaveChangesAsync();

        return vNewUser.Id.ToString();
    }
}