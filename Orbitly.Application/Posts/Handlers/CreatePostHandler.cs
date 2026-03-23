using MediatR;
using Orbitly.Application.Posts;
using Orbitly.Domain.Entities;

namespace Orbitly.Application.Posts.Commands;

public class CreatePostHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IPostRepository _repository;

    public CreatePostHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var alreadyPosted = await _repository.HasPostToday(request.UserId);

        if (alreadyPosted)
            throw new Exception("You can only post once per day");

        var post = new Post(request.UserId, request.Content);

        await _repository.AddAsync(post);

        return post.Id;
    }
}