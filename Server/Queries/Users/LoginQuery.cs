using MediatR;
using server.Controllers;
using server.Models.DTO;
using server.Models.DTO.Tokens;

namespace server.Queries;

public class LoginQuery : IRequest<TokenResponse>
{
    public LoginDto _LoginDto { get; set; }
}
