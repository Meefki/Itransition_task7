using Domain.SeedWork;

namespace Domain.Shared;

public class GameTypes
    : Enumeration
{
    public static GameTypes TicTacToe => new(1, nameof(TicTacToe));

    public GameTypes(int id, string name) : base(id, name)
    {
    }
}
