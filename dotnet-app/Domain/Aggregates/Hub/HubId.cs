using Domain.SeedWork;

namespace Domain.Aggregates.Hub;

public class HubId : EntityIdentifier<Guid>
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
}
