using Orbitly.Domain.Entities;

namespace Orbitly.Application.Posts;

public interface IPostRepository
{
    Task AddAsync(Post post);
    Task<bool> HasPostToday(Guid userId);
}