using Domain.Aggregates.Session;
using Domain.Aggregates.Session.GameProcessorEntity;
using Domain.Shared;

namespace Application.Services.SessionServices;

public interface ISessionService
{
    Task<Session> Create(GameTypes gameType, IEnumerable<Player> players, IGameProcessorFactory gameProcessorFactory);
    Task Start(string sessionId, dynamic startParam);
    Task<Tuple<States, GameResult?>> Process(string sessionId, dynamic processParam);
    Task Suspend(string sessionId);
    Task Abort(string sessionId);
}
