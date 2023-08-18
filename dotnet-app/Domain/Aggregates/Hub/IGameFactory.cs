using Domain.Shared;

namespace Domain.Aggregates.Hub;

public interface IGameFactory
{
    Game Create(GameTypes gameType);
}
