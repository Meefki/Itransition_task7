using Domain.SeedWork;

namespace GameAdapter.TicTacToe.Exceptions;

internal class WrongPlayerMoveException
    : DomainException<WrongPlayerMoveException>
{
    static WrongPlayerMoveException()
    {
        MessageText = "Wront player {0} turn";
    }

    public static void Throw(string playerName)
    {
        string message = string.Format(MessageText, playerName);
        ThrowEx(message);
    }

    public WrongPlayerMoveException(string message = "")
        : base(message)
    {
    }

    public WrongPlayerMoveException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
