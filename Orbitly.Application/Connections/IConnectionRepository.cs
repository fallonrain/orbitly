using Orbitly.Domain.Entities;

namespace Orbitly.Application.Connections;

public interface IConnectionRepository
{
    Task AddAsync(Connection connection);
    Task<List<Guid>> GetConnectionsAsync(Guid userId);
}