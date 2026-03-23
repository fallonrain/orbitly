namespace Orbitly.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string StarId { get; private set; } = string.Empty;
    public string Alias { get; private set; } = string.Empty;
    public string Bio { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    private User() { } // EF

    public User(string alias, string bio)
    {
        Id = Guid.NewGuid();
        StarId = GenerateStarId();
        Alias = alias;
        Bio = bio;
        CreatedAt = DateTime.UtcNow;
    }

    private string GenerateStarId()
    {
        var random = new Random();
        return $"Star-{random.Next(1000, 9999)}";
    }
}