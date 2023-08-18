using Domain.SeedWork;

namespace Domain.Aggregates.Hub.DomainExceptions;

public class NameTooShortDomainException 
    : DomainException<NameTooShortDomainException>
{
    static NameTooShortDomainException()
    {
        MessageText = "Name too short";
    }

    public static void Throw()
    {
        ThrowEx();
    }
}
