using Domain.Aggregates.Session.GameProcessorEntity;
using Domain.SeedWork;

namespace GameAdapter.TicTacToe.Exceptions;

public class WrongStartParameterTypeException
    : DomainException<WrongStartParameterTypeException>
{
    static WrongStartParameterTypeException()
    {
        MessageText = "Wrong type of start parameters of the Game Processor: {0}";
    }

    public static void Throw(GameProcessor gameProcessor)
    {
        string message = string.Format(MessageText, gameProcessor.GetType().Name);
        ThrowEx(message);
    }

    public WrongStartParameterTypeException(string message = "")
        : base(message)
    {
    }

    public WrongStartParameterTypeException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
