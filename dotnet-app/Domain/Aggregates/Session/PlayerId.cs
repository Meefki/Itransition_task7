using Domain.SeedWork;

namespace Domain.Aggregates.Session;

public sealed class PlayerId
    : EntityIdentifier<Guid>
{
    private PlayerId(Guid value)
    {
        Value = value;
    }

    public override Guid Value { get; }

    public static PlayerId Create(Guid id)
        => new(id);

    public static PlayerId Create(string stringId)
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

    public static bool operator ==(PlayerId left, PlayerId right)
        => EqualOperator(left, right);

    public static bool operator !=(PlayerId left, PlayerId right)
        => NotEqualOperator(left, right);
}
