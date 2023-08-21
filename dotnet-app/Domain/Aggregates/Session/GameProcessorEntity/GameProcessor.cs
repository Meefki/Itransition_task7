using Domain.SeedWork;
using Domain.Shared;

namespace Domain.Aggregates.Session.GameProcessorEntity;

public abstract class GameProcessor 
    : Entity<GameTypes>, IDisposable
{
    protected GameProcessor(GameProcessorId id)
        : base(id)
    {
    }

    private readonly GameProcessorId id = null!;
    public override EntityIdentifier<GameTypes> Id
    {
        get => id;
        init => id = (GameProcessorId)value;
    }

    public abstract int PlayersCount { get; init; }

    public abstract void Start(dynamic startParam);
    public abstract GameResult? Process(dynamic processParam);

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected abstract void Dispose(bool disposing);
}
