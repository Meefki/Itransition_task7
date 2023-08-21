using Domain.Aggregates.Session;

namespace GameAdapter.TicTacToe.Parameters;

public sealed record NextMoveParam(Player Player, int RowNumber, int ColNumber);
