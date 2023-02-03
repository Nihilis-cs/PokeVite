using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Commands;
using server.models.DTO;
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
    public async Task<IActionResult> createPokemon([FromBody] PokeDto aPoke)
    {
        var vResult = await _Mediator.Send(new AddPokemonCommand { Pokemon = aPoke });
        return Ok(vResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getAllPokemonByUser(string id)
    {
        var vResult = await _Mediator.Send(new GetAllPokemonByUserQuery(id));
        return Ok(vResult);
    }



    // [HttpPost("newlist")]
    // public async Task<IActionResult> createPokemon([FromBody] PokeDto[] aPoke)
    // {
    //     var vResult = await _Mediator.Send(new AddListPokemonCommand { Pokemon = aPoke });
    //     return Ok(vResult);
    // }


}