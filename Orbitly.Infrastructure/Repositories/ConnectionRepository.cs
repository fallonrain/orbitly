using Microsoft.EntityFrameworkCore;
using Orbitly.Application.Connections;
using Orbitly.Domain.Entities;
using Orbitly.Infrastructure.Persistence;

namespace Orbitly.Infrastructure.Repositories;

public class ConnectionRepository : IConnectionRepository
{
    private readonly OrbitlyDbContext _context;

    public ConnectionRepository(OrbitlyDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Connection connection)
    {
        await _context.Connections.AddAsync(connection);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Guid>> GetConnectionsAsync(Guid userId)
    {
        return await _context.Connections
            .Where(c => c.UserId == userId)
            .Select(c => c.ConnectedUserId)
            .ToListAsync();
    }
}