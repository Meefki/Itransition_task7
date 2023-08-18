using Domain.SeedWork;

namespace Domain.Aggregates.Hub;

public class HubId : IEntityIdentifier<Guid>
{
    private HubId(Guid value)
        => Value = value;

    public Guid Value { get; private protected set; }

    public static HubId Create(Guid id)
        => new(id);
}
