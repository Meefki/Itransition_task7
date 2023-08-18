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


}
