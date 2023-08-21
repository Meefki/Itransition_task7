using Domain.SeedWork;
using Domain.Shared;

namespace Domain.Aggregates.Hub;

public abstract class Game
    : ValueObject
{
    public Game(GameTypes gameType)
    {
        GameType = gameType;
    }

    public abstract int PlayersCount { get; }
    public GameTypes GameType { get; init; }
    

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PlayersCount;
        yield return GameType;
    }

    public static bool operator== (Game left, Game right)
        => EqualOperator(left, right);

    public static bool operator!= (Game left, Game right)
        => NotEqualOperator(left, right);

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();
}
