using Domain.SeedWork;

namespace Domain.Aggregates.Hub.DomainExceptions;

public class WrongPlayersCountDomainExeption
    : DomainException<WrongPlayersCountDomainExeption>
{
    static WrongPlayersCountDomainExeption()
    {
        MessageText = "Wrong amount of players was defined";
    }

    public static void Throw()
    {
        ThrowEx();
    }

    public WrongPlayersCountDomainExeption(string message = "")
        : base(message)
    {
    }

    public WrongPlayersCountDomainExeption(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
