using Domain.SeedWork;

namespace Domain.Aggregates.Session;

public class States
    : Enumeration
{
    public static States Created => new(1, nameof(Created));
    public static States Started => new(2, nameof(Started));
    public static States Suspended => new(3, nameof(Suspended));
    public static States Ended => new(4, nameof(Ended));
    public static States Aborted => new(5, nameof(Aborted));

    public States(int id, string name) : base(id, name)
    { }
}
