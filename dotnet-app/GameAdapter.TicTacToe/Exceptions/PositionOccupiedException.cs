using Domain.SeedWork;
using GameAdapter.TicTacToe.Parameters;

namespace GameAdapter.TicTacToe.Exceptions;

internal class PositionOccupiedException
    : DomainException<PositionOccupiedException>
{
    static PositionOccupiedException()
    {
        MessageText = "Position already occupied: {0}:{1}";
    }

    public static void Throw(int row, int col)
    {
        string message = string.Format(MessageText, row, col);
        ThrowEx(message);
    }

    public PositionOccupiedException(string message = "")
        : base(message)
    {
    }

    public PositionOccupiedException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
