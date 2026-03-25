using Microsoft.EntityFrameworkCore;
using Orbitly.Application.Posts;
using Orbitly.Domain.Entities;
using Orbitly.Infrastructure.Persistence;
using System.Linq;

namespace Orbitly.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly OrbitlyDbContext _context;

    public PostRepository(OrbitlyDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasPostToday(Guid userId)
    {
        var start = DateTime.UtcNow.Date;
        var end = start.AddDays(1);

        return await _context.Posts
            .AnyAsync(p => p.UserId == userId 
                    && p.CreatedAt >= start 
                    && p.CreatedAt < end);
    }

    public async Task<List<Post>> GetRecentPostsAsync(int page, int pageSize)
    {
        return await _context.Posts
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<Post>> GetRandomPostsAsync(int count)
    {
        return await _context.Posts
            .OrderBy(p => Guid.NewGuid())
            .Take(count)
            .ToListAsync();
    }

    public async Task<List<Post>> GetPostsByUsersAsync(List<Guid> userIds)
    {
        return await _context.Posts
            .Where(p => userIds.Contains(p.UserId))
            .OrderByDescending(p => p.CreatedAt)
            .Take(10)
            .ToListAsync();
    }
}