using Domain.Aggregates.Session.GameProcessorEntity;
using Domain.SeedWork;

namespace GameAdapter.TicTacToe.Exceptions;

internal class WrongNextMoveParameterTypeException
    : DomainException<WrongNextMoveParameterTypeException>
{
    static WrongNextMoveParameterTypeException()
    {
        MessageText = "Wrong type of next move parameters of the Game Processor: {0}";
    }

    public static void Throw(GameProcessor gameProcessor)
    {
        string message = string.Format(MessageText, gameProcessor.GetType().Name);
        ThrowEx(message);
    }

    public WrongNextMoveParameterTypeException(string message = "")
        : base(message)
    {
    }

    public WrongNextMoveParameterTypeException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
