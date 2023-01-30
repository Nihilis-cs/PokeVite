using MediatR;
using server.Models.DTO;

namespace server.Commands;

public class CreateUserCommand : IRequest<string>
{
    public CreateUserDto User { get; set; } = null!;
}