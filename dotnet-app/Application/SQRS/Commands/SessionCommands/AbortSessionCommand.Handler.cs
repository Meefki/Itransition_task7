using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Session;
using Domain.SeedWork;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.SessionCommands;

public abstract class AbortSessionCommandHandler<T>
    : ICommandHandler<T, Tuple<bool, DomainErrorDetails?>>
    where T : AbortSessionCommand
{
    private readonly ISessionRepository sessionRepository;
    private readonly ILogger<AbortSessionCommandHandler<T>> logger;

    public AbortSessionCommandHandler(
        ISessionRepository sessionRepository,
        ILogger<AbortSessionCommandHandler<T>> logger)
    {
        this.sessionRepository = sessionRepository;
        this.logger = logger;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2254:Template should be a static expression", Justification = "<Pending>")]
    public async Task<Tuple<bool, DomainErrorDetails?>> Handle(T request, CancellationToken cancellationToken)
    {
        DomainErrorDetails? errorDetails = null;
        bool result = true;

        try
        {
            SessionId id = SessionId.Create(request.SessionId);
            Session session = await sessionRepository.GetBy(id);
            session.ChangeState(States.Aborted);
            await sessionRepository.Update(session);
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

        return new(result, errorDetails);
    }
}
