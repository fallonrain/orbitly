using MediatR;

namespace Orbitly.Application.Posts.Commands;

public record CreatePostCommand(Guid UserId, string Content) : IRequest<Guid>;