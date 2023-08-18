using Domain.SeedWork;

namespace Domain.Aggregates.Session;

public class SessionId : IEntityIdentifier<Guid>
{
    private SessionId(Guid value)
        => Value = value;

    public Guid Value { get; init; }

    public static SessionId Create(Guid id)
        => new(id);
}
