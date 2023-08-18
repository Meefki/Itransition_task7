using Domain.Shared;

namespace Domain.Aggregates.Session.GameProcessorEntity;

public interface IGameProcessorFactory
{
    GameProcessor Create(GameTypes gameType);
}
