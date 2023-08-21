using Domain.SeedWork;

namespace Domain.Aggregates.Hub;

public sealed class HubId 
    : EntityIdentifier<Guid>
{
    private HubId(Guid value)
        => Value = value;

    public override Guid Value { get; }

    public static HubId Create(Guid id)
        => new(id);

    public static HubId Create(string stringId)
    {
        Guid id = Guid.Parse(stringId);
        return Create(id);
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(HubId left, HubId right)
        => EqualOperator(left, right);

    public static bool operator !=(HubId left, HubId right)
        => NotEqualOperator(left, right);
}
