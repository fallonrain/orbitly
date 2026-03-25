using MediatR;
using Orbitly.Application.Feed;

namespace Orbitly.Application.Feed.Queries;

public class GetFeedQuery : IRequest<FeedResponse>
{
    public Guid UserId { get; set; } 
    public int Page { get; set; }
    public int PageSize { get; set; }
}