using Domain.SeedWork;

namespace Domain.Aggregates.Session;

public class SessionId : EntityIdentifier<Guid>
{
    private SessionId(Guid value)
        => Value = value;

    public override Guid Value { get; }

    public static SessionId Create(Guid id)
        => new(id);

    public static SessionId Create(string stringId)
    {
        Guid id = Guid.Parse(stringId);
        return Create(id);
    }
}
