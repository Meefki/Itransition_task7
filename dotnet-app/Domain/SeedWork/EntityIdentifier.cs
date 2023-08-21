namespace Domain.SeedWork;

public abstract class EntityIdentifier<T>
    : ValueObject
{
    public abstract T Value { get; }

    public override string ToString()
    {
        return Value?.ToString() ?? "";
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}
