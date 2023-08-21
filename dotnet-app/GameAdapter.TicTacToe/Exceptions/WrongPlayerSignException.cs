using Domain.SeedWork;
using GameAdapter.TicTacToe.Parameters;

namespace GameAdapter.TicTacToe.Exceptions;

internal class WrongPlayerSignException
    : DomainException<PositionOccupiedException>
{
    static WrongPlayerSignException()
    {
        MessageText = "Wrong player sign";
    }

    public static void Throw()
    {
        string message = MessageText;
        ThrowEx(message);
    }

    public WrongPlayerSignException(string message = "")
        : base(message)
    {
    }

    public WrongPlayerSignException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
