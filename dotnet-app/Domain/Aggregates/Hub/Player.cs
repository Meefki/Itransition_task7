using Domain.Aggregates.Hub.DomainExceptions;
using Domain.SeedWork;

namespace Domain.Aggregates.Hub;

public sealed class Player
    : Entity<Guid>
{
    public Player(PlayerId id, string name, bool isLeader = false)
        : base(id)
    {
        if (name.Length < 3)
            NameTooShortDomainException.Throw();

        Name = name;
        IsLeader = isLeader;
    }

    private PlayerId id = null!;
    public override EntityIdentifier<Guid> Id 
    {
        get => id;
        init => id = (PlayerId)value; 
    }
    public string Name { get; init; }

    public bool IsLeader { get; private set; }

    public void ChangeLeadership(bool isLeader)
    {
        IsLeader = isLeader;
    }
}
