using Domain.SeedWork;

namespace Domain.Aggregates.Hub;

public class PlayerId
    : IEntityIdentifier<string>
{
    public static PlayerId Create(string name)
        => new(name);

    private PlayerId(string value)
        => Value = value;

    public string Value { get; init; }
}
