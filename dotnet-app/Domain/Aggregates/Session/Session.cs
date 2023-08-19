using Domain.Aggregates.Session.DomainExceptions;
using Domain.Aggregates.Session.GameProcessorEntity;
using Domain.SeedWork;
using Domain.Shared;
using System.Collections.ObjectModel;

namespace Domain.Aggregates.Session;

public class Session : Entity<Guid>, IAggregateRoot
{
    private readonly GameProcessor gameProcessor;

    public Session(
        GameTypes gameType,
        IEnumerable<Player> players,
        GameProcessor gameProcessor)
        : base(SessionId.Create(Guid.NewGuid()))
    {
        this.players = new List<Player>(players);
        State = States.Created;
        GameType = gameType;
        this.gameProcessor = gameProcessor;
    }

    private SessionId id = null!;
    public override EntityIdentifier<Guid> Id
    {
        get => id;
        init => id = (SessionId)value;
    }

    private readonly IList<Player> players;
    public IReadOnlyCollection<Player> Players => new ReadOnlyCollection<Player>(players);

    public States State { get; private set; }
    public void ChangeState(States state, dynamic? param = null)
    {
        if (!ValidateState(state))
            InvalidStateDomainException.Throw(from: State, to: state);

        if (state == States.Started && State == States.Created)
        {
            param ??= new { };
            gameProcessor.Start(param);
        }

        State = state;
    }

    private bool ValidateState(States state)
    {
        if (state == States.Started && (State == States.Suspended ||
                                        State == States.Created) ||
            (state == States.Suspended ||
             state == States.Ended) && State == States.Started ||
            state == States.Aborted && (State == States.Started ||
                                        State == States.Suspended ||
                                        State == States.Created))
            return true;

        return false;
    }

    public GameResult? Process(dynamic processParam)
    {
        GameResult? result = null;
        if (State != States.Suspended && 
            State != States.Aborted &&
            State != States.Ended)
            result = gameProcessor.Process(processParam);

        if (result is not null)
            ChangeState(States.Ended);

        return result;
    }

    public GameTypes GameType { get; init; }
}
