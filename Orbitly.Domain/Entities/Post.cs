namespace Orbitly.Domain.Entities;

public class Post
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }

    private Post() { }

    public Post(Guid userId, string content)
    {
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Post content cannot be empty");

        if (content.Length > 500)
            throw new ArgumentException("Post cannot exceed 500 characters");

        Id = Guid.NewGuid();
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }
}