using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Session;
using Domain.Aggregates.Session.GameProcessorEntity;
using Domain.SeedWork;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.SessionCommands;

public abstract class CreateSessionCommandHandler<T>
    : ICommandHandler<T, Tuple<bool, string, DomainErrorDetails?>>
    where T : CreateSessionCommand
{
    private readonly ISessionRepository sessionRepository;
    private readonly IGameProcessorFactory gameProcessorFactory;
    private readonly ILogger<CreateSessionCommandHandler<T>> logger;

    public CreateSessionCommandHandler(
        ISessionRepository sessionRepository,
        IGameProcessorFactory gameProcessorFactory,
        ILogger<CreateSessionCommandHandler<T>> logger)
    {
        this.sessionRepository = sessionRepository;
        this.gameProcessorFactory = gameProcessorFactory;
        this.logger = logger;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2254:Template should be a static expression", Justification = "<Pending>")]
    public async Task<Tuple<bool, string, DomainErrorDetails?>> Handle(T request, CancellationToken cancellationToken)
    {
        DomainErrorDetails? errorDetails = null;
        string sessionId = "";
        bool result = true;

        try
        {
            GameProcessor gameProcessor = gameProcessorFactory.Create(request.GameType);
            List<Player> players = request.PlayerNames.Select(x => new Player(x)).ToList();
            Session session = new(request.GameType, players, gameProcessor);
            await sessionRepository.Create(session);

            sessionId = session.Id.Value.ToString();
        }
        catch (DomainException ex)
        {
            errorDetails = new(ex, ex.Message);
            result = false;
            logger.LogError(ex, message: ex.Message);
        }
        catch (Exception ex)
        {
            result = false;
            logger.LogCritical(ex, message: ex.Message);
        }

        return new(result, sessionId, errorDetails);
    }
}
