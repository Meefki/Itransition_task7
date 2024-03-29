﻿using Domain.SeedWork;

namespace Domain.Aggregates.Session;

public sealed class SessionId 
    : EntityIdentifier<Guid>
{
    private SessionId(Guid value)
        => Value = value;

    public override Guid Value { get; }

    public static SessionId Create(Guid id)
        => new(id);

    public static SessionId Create(string stringId)
    {
        Guid id = Guid.Parse(stringId);
        return Create(id);
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(SessionId left, SessionId right)
        => EqualOperator(left, right);

    public static bool operator !=(SessionId left, SessionId right)
        => NotEqualOperator(left, right);
}
