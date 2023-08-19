using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Session;
using Domain.Aggregates.Session.GameProcessorEntity;
using Domain.SeedWork;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.SessionCommands;

public abstract class CreateSessionCommandHandler<TRequest>
    : CommandHandler<TRequest, string>
    where TRequest : CreateSessionCommand
{
    private readonly ISessionRepository sessionRepository;
    private readonly IGameProcessorFactory gameProcessorFactory;

    public CreateSessionCommandHandler(
        ISessionRepository sessionRepository,
        IGameProcessorFactory gameProcessorFactory,
        ILogger<CreateSessionCommandHandler<TRequest>> logger)
        : base(logger)
    {
        this.sessionRepository = sessionRepository;
        this.gameProcessorFactory = gameProcessorFactory;
    }

    protected override async Task<string> Action(TRequest request, CancellationToken cancellationToken)
    {
        GameProcessor gameProcessor = gameProcessorFactory.Create(request.GameType);
        List<Player> players = request.PlayerNames.Select(x => new Player(x)).ToList();
        Session session = new(request.GameType, players, gameProcessor);
        await sessionRepository.Create(session);

        string sessionId = session.Id.Value.ToString();
        return sessionId;
    }
}
