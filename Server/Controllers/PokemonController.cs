using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Commands;
using server.Models.DTO;
using server.Queries;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]

public class PokemonController : ControllerBase
{
    private readonly IMediator _Mediator;

    public PokemonController(IMediator aMediator)
    {
        _Mediator = aMediator;
    }

    [HttpPost("new")]
    public async Task<IActionResult> createUserPokemon([FromBody] UserPokemonDto aUserPkmnDto)
    {
        var vResult = await _Mediator.Send(new AddUserPokemonCommand { UserPokemon = aUserPkmnDto });
        return Ok(vResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getAllPokemonByUser(string id)
    {
        var vResult = await _Mediator.Send(new GetAllPokemonByUserQuery(id));
        return Ok(vResult);
    }


}