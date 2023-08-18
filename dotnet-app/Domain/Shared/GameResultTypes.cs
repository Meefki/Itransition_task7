using Domain.SeedWork;

namespace Domain.Shared;

public class GameResultTypes
    : Enumeration
{
    public static GameResultTypes Draw => new(1, nameof(Draw));
    public static GameResultTypes Win => new(2, nameof(Win));
    public static GameResultTypes Lose => new(3, nameof(Lose));

    public GameResultTypes(int id, string name) : base(id, name)
    {
    }
}
