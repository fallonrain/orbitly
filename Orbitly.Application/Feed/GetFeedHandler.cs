using MediatR;
using Orbitly.Application.Feed.Queries;
using Orbitly.Application.Posts;
using Orbitly.Application.Feed;
using Orbitly.Domain.Entities;
using Orbitly.Application.Connections;
using System.Linq;


namespace Orbitly.Application.Feed;

public class GetFeedHandler : IRequestHandler<GetFeedQuery, FeedResponse>
{
    private readonly IPostRepository _repository;

    private readonly IConnectionRepository _connectionRepository;

    public GetFeedHandler(IPostRepository repository, IConnectionRepository connectionRepository)
    {
        _repository = repository;
        _connectionRepository = connectionRepository;
    }

    public async Task<FeedResponse> Handle(GetFeedQuery request, CancellationToken cancellationToken)
    {
        var recentPosts = await _repository.GetRecentPostsAsync(request.Page, request.PageSize);

        var randomPosts = await _repository.GetRandomPostsAsync(request.PageSize);

        var connections = await _connectionRepository.GetConnectionsAsync(request.UserId);

        var constellationPosts = await _repository.GetPostsByUsersAsync(connections);

        return new FeedResponse
        {
            RecentPosts = recentPosts.Select(Map).ToList(),
            RandomPosts = randomPosts.Select(Map).ToList(),
            ConstellationPosts = constellationPosts.Select(Map).ToList()
        };
    }

    private static PostDto Map(Post p) => new()
    {
        Id = p.Id,
        UserId = p.UserId,
        Content = p.Content,
        CreatedAt = p.CreatedAt
    };
}