using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orbitly.Application.Feed.Queries;

namespace Orbitly.Api.Controllers;

[ApiController]
[Route("api/feed")]
public class FeedController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeedController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetFeed([FromQuery] GetFeedQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}