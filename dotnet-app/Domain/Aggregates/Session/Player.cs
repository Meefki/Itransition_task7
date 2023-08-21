using Domain.Aggregates.Hub.DomainExceptions;
using Domain.SeedWork;

namespace Domain.Aggregates.Session;

public sealed class Player
    : Entity<Guid>
{
    public Player(
        PlayerId id, 
        string name)
        : base(id)
    {
        if (name.Length < 3)
            NameTooShortDomainException.Throw();

        Name = name;
    }

    private readonly PlayerId id = null!;
    public override EntityIdentifier<Guid> Id
    {
        get => id;
        init => id = (PlayerId)value;
    }

    public string Name { get; init; }
}
