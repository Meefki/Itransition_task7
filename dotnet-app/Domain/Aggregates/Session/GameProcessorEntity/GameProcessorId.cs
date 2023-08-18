using Domain.SeedWork;

namespace Domain.Aggregates.Session.GameProcessorEntity;

public class GameProcessorId
    : IEntityIdentifier<Guid>
{
    public static GameProcessorId Create(Guid id)
        => new(id);

    private GameProcessorId(Guid value)
        => Value = value;

    public Guid Value { get; init; }
}
