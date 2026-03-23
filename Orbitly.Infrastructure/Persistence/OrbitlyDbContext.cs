using Microsoft.EntityFrameworkCore;
using Orbitly.Domain.Entities;

namespace Orbitly.Infrastructure.Persistence;

public class OrbitlyDbContext : DbContext
{
    public OrbitlyDbContext(DbContextOptions<OrbitlyDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
}