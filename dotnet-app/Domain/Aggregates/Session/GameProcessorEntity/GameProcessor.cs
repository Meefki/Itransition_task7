using Domain.Aggregates.Hub;
using Domain.SeedWork;

namespace Domain.Aggregates.Session.GameProcessorEntity;

public abstract class GameProcessor : Entity<Guid>
{
    protected GameProcessor(EntityIdentifier<Guid> id)
        : base(id)
    {
    }

    private readonly GameProcessorId id = null!;
    public override EntityIdentifier<Guid> Id
    {
        get => id;
        init => id = (GameProcessorId)value;
    }

    public abstract int PlayersCount { get; init; }

    public abstract void Start(dynamic startParam);
    public abstract GameResult? Process(dynamic processParam);
}
