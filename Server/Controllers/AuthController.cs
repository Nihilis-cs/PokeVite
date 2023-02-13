using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using server.Queries;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _Mediator;

    public AuthController(IMediator aMediator)
    {
        _Mediator = aMediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto aModel)
    {
        if (ModelState.IsValid)
        {
            var vRes = await _Mediator.Send(new LoginQuery { _LoginDto = aModel });
            return Ok(vRes);
        }
        else
        {
            return BadRequest();
        }

    }

}