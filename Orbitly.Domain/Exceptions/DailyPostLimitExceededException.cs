namespace Orbitly.Domain.Exceptions;

public sealed class DailyPostLimitExceededException : DomainException
{
    public DailyPostLimitExceededException()
        : base("User already posted today.")
    {
    }
}