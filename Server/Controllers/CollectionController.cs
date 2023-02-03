using MediatR;
using Microsoft.AspNetCore.Mvc;
using server.Commands;
using server.models.DTO;
using server.Queries;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]

public class CollectionController : ControllerBase
{
    private readonly IMediator _Mediator;

    public CollectionController(IMediator aMediator)
    {
        _Mediator = aMediator;
    }

    [HttpPost("new")]
    public async Task<IActionResult> createCollection([FromBody] CreateCollectionDto aCol)
    {
        var vResult = await _Mediator.Send(new CreateCollectionCommand { Collection = aCol });
        return Ok(vResult);
    }

    [HttpGet("all")]
    public async Task<IActionResult> getCollectionsByUser([FromQuery] string userId)
    {
        var vResult = await _Mediator.Send(new GetAllCollectionByUserQuery(userId));
        return Ok(vResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getCollectionById(string id)
    {
        var vResult = await _Mediator.Send(new GetCollectionQuery(id));
        return Ok(vResult);
    }



}