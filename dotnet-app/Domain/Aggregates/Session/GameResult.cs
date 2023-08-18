using Domain.SeedWork;
using Domain.Shared;

namespace Domain.Aggregates.Session;

public class GameResult
    : ValueObject
{
    public static GameResult CreateWin(Player player, GameTypes gameType)
        => new(player, gameType, GameResultTypes.Win);

    public static GameResult CreateLose(Player player, GameTypes gameType)
        => new(player, gameType, GameResultTypes.Lose);

    public static GameResult CreateDraw(GameTypes gameType)
        => new(null, gameType, GameResultTypes.Draw);

    private GameResult(Player? player, GameTypes gameType, GameResultTypes gameResultType)
        => (Player, GameType, GameResultType) = (player, gameType, gameResultType);

    public GameResultTypes GameResultType { get; set; }
    public Player? Player { get; init; }
    public GameTypes GameType { get; init; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Player;
        yield return GameType;
    }

    public static bool operator ==(GameResult left, GameResult right)
        => EqualOperator(left, right);

    public static bool operator !=(GameResult left, GameResult right)
        => NotEqualOperator(left, right);

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();
}
