using Domain.SeedWork;
using Domain.Shared;

namespace Domain.Aggregates.Session.GameProcessorEntity;

public class GameProcessorId
    : EntityIdentifier<GameTypes>
{
    public static GameProcessorId Create(GameTypes id)
        => new(id);

    private GameProcessorId(GameTypes value)
        => Value = value;

    public override GameTypes Value { get; }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(GameProcessorId left, GameProcessorId right)
        => EqualOperator(left, right);

    public static bool operator !=(GameProcessorId left, GameProcessorId right)
        => NotEqualOperator(left, right);
}
