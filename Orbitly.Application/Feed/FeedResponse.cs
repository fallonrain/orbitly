namespace Orbitly.Application.Feed;

public class FeedResponse
{
    public List<PostDto> RecentPosts { get; set; } = new();
    public List<PostDto> RandomPosts { get; set; } = new();
    public List<PostDto> ConstellationPosts { get; set; } = new();
}