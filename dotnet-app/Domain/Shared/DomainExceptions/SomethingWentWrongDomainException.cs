using Domain.SeedWork;

namespace Domain.Shared.DomainExceptions;

public sealed class SomethingWentWrongDomainException
    : DomainException<SomethingWentWrongDomainException>
{
    static SomethingWentWrongDomainException()
    {
        MessageText = "Wrong amount of players was defined";
    }

    public static void Throw(Exception? innerException = null)
    {
        ThrowEx(innerException: innerException);
    }

    public SomethingWentWrongDomainException(string message = "")
        : base(message)
    {
    }

    public SomethingWentWrongDomainException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
