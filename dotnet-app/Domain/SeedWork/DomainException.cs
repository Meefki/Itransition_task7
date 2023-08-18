﻿namespace Domain.SeedWork;

public class DomainException<T> : Exception
    where T : DomainException<T>
{
    public static string MessageText { get; protected set; } = "";

    protected static void ThrowEx(string message = "")
    {
        throw (Activator.CreateInstance(typeof(T), new object[] { message }) as T) ??
            new DomainException<T>(message);
    }

    public DomainException(string message = "")
        : base(message)
    {
    }
}