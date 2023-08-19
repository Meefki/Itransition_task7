namespace Domain.SeedWork;

public abstract class EntityIdentifier<T>
{
    public abstract T Value { get; }

    public override string ToString()
    {
        return Value?.ToString() ?? "";
    }
}
