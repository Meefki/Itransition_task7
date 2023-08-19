using Domain.SeedWork;

namespace Domain.Aggregates.Session.DomainExceptions;

public class InvalidStateDomainException
    : DomainException<InvalidStateDomainException>
{
    static InvalidStateDomainException()
    {
        MessageText = "Cannot change state from {0} to {0}";
    }

    public static void Throw(States from, States to)
    {
        string message = string.Format(MessageText, from.Name, to.Name);
        ThrowEx(message);
    }

    public InvalidStateDomainException(string message = "")
        : base(message)
    {
    }

    public InvalidStateDomainException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
