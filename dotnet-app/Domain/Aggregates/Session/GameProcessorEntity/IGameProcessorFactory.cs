namespace Domain.Aggregates.Session.GameProcessorEntity;

public interface IGameProcessorFactory
{
    GameProcessor Create(string gameName);
}
