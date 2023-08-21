using Domain.Aggregates.Hub;
using Domain.SeedWork;
using Domain.Shared;

namespace GameAdapter.TicTacToe;

public sealed class TicTacToeGame
    : Game
{
    public TicTacToeGame()
        : base(new(Enumeration.GetAll<GameTypes>().Count() + 1, "TicTacToe"))
    {
    }

    public override int PlayersCount => 2;
}
