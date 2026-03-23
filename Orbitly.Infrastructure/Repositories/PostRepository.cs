using Microsoft.EntityFrameworkCore;
using Orbitly.Application.Posts;
using Orbitly.Domain.Entities;
using Orbitly.Infrastructure.Persistence;

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
}