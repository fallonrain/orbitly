namespace Orbitly.Domain.Entities;

public class Connection
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid ConnectedUserId { get; private set; }

    public Connection(Guid userId, Guid connectedUserId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        ConnectedUserId = connectedUserId;
    }
}