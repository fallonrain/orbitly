using Orbitly.Domain.Entities;

namespace Orbitly.Application.Posts;

public interface IPostRepository
{
    Task AddAsync(Post post);
    Task<bool> HasPostToday(Guid userId);
    Task<List<Post>> GetRecentPostsAsync(int page, int pageSize);
    Task<List<Post>> GetRandomPostsAsync(int count);
    Task<List<Post>> GetPostsByUsersAsync(List<Guid> userIds);
}