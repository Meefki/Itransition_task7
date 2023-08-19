using Domain.SeedWork;

namespace Domain.Aggregates.Session.GameProcessorEntity;

public class GameProcessorId
    : EntityIdentifier<Guid>
{
    public static GameProcessorId Create(Guid id)
        => new(id);

    private GameProcessorId(Guid value)
        => Value = value;

    public override Guid Value { get; }
}
