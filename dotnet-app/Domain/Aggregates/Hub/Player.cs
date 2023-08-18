using Domain.Aggregates.Hub.DomainExceptions;
using Domain.SeedWork;
using System.Globalization;

namespace Domain.Aggregates.Hub;

public class Player
    : Entity<string>
{
    //public static Player CreateLeader(string name)
    //    => new(name, true);

    //public static Player Create(string name)
    //    => new(name, false);

    public Player(string name, bool isLeader = false)
        : base(PlayerId.Create(name))
    {
        if (name.Length < 3)
            NameTooShortDomainException.Throw();

        IsLeader = isLeader;
    }

    private PlayerId name = null!;
    public override IEntityIdentifier<string> Id 
    {
        get => name;
        init => name = (PlayerId)value; 
    }
    public string Name => name.Value;

    public bool IsLeader { get; private set; }

    public void ChangeLeadership(bool isLeader)
    {
        IsLeader = isLeader;
    }
}
