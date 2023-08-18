using Domain.Aggregates.Hub.DomainExceptions;
using Domain.SeedWork;

namespace Domain.Aggregates.Session;

public class Player
    : ValueObject
{
    public Player(string name)
    {
        if (name.Length < 3)
            NameTooShortDomainException.Throw();

        Name = name;
    }

    public string Name { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
    }

    public static bool operator== (Player left, Player right)
        => EqualOperator(left, right);

    public static bool operator!= (Player left, Player right)
        => NotEqualOperator(left, right);

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();
}
