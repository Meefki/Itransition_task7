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

    public MorePlayersThanNeededDomainException(string message = "")
        : base(message)
    {
    }

    public MorePlayersThanNeededDomainException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
