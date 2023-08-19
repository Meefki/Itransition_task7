using Domain.SeedWork;

namespace Domain.Aggregates.Hub;

public class PlayerId
    : EntityIdentifier<string>
{
    public static PlayerId Create(string name)
        => new(name);

    private PlayerId(string value)
        => Value = value;

    public override string Value { get; }
}
