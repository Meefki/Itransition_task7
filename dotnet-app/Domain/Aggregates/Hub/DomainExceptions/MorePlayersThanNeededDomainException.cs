using Domain.SeedWork;

namespace Domain.Aggregates.Hub.DomainExceptions;

public class MorePlayersThanNeededDomainException
    : DomainException<MorePlayersThanNeededDomainException>
{
    static MorePlayersThanNeededDomainException()
    {
        MessageText = "Hub has more players then needed for selected game";
    }

    public static void Throw()
    {
        ThrowEx();
    }
}
