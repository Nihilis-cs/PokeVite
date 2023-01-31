using System.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Commands;
using server.models;
using server.Models.DTO;
using server.Queries;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly IMediator _Mediator;

    public UserController(IMediator aMediator)
    {
        _Mediator = aMediator;
    }

    [HttpPost("new")]
    public async Task<IActionResult> createUser([FromBody] CreateUserDto user)
    {
        var vResult = await _Mediator.Send(new CreateUserCommand { User = user });
        return Ok(vResult);

    }

    [HttpGet("all")]
    public async Task<IActionResult> getAllUsers()
    {
        var vResult = await _Mediator.Send(new GetAllUsersQuery());
        return Ok(vResult);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> getUserById(string name)
    {
        var vResult = await _Mediator.Send(new GetUserByNameQuery(name));
        return Ok(vResult);
    }


}