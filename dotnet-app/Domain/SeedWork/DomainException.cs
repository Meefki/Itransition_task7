namespace Domain.SeedWork;

public class DomainException<T> 
    : DomainException
    where T : DomainException<T>
{
    public static string MessageText { get; protected set; } = "";

    protected static void ThrowEx(string message = "", Exception? innerException = null)
    {
        object[] objectParams = innerException is null ?
            objectParams = new object[] { message } :
            objectParams = new object[] { message, innerException };

        throw (Activator.CreateInstance(typeof(T), objectParams) as T) ?? (innerException is null ?
            new DomainException<T>(message) :
            new DomainException<T>(message, innerException));
    }

    public DomainException(string message = "")
        : base(message)
    {
    }

    public DomainException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}

public abstract class DomainException 
    : Exception
{
    public DomainException(string message = "")
        : base(message)
    {
    }

    public DomainException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
