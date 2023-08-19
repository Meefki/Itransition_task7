namespace Domain.SeedWork;

public class DomainErrorDetails
{
    public DomainErrorDetails(DomainException ex, string message)
    {
        Ex = ex;
        Message = message;
    }

    public DomainException Ex { get; init; }
    public string Message { get; init; }
}
