using Domain.SeedWork;

namespace Domain.Shared;

public sealed class GameTypes
    : Enumeration
{
    public GameTypes(int id, string name) : base(id, name)
    {
    }
}
