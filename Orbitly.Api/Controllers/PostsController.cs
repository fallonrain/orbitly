using MediatR;
using Microsoft.AspNetCore.Mvc;
using Orbitly.Application.Posts.Commands;

namespace Orbitly.Api.Controllers;

[ApiController]
[Route("api/posts")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostCommand command)
{
    try
    {
        var postId = await _mediator.Send(command);
        return Ok(postId);
    }
    catch (Exception ex)
    {
        return BadRequest(new { error = ex.Message });
    }
}
}