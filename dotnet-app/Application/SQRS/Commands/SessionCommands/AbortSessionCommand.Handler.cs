using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Session;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.SessionCommands;

public abstract class AbortSessionCommandHandler<TRequest>
    : CommandHandler<TRequest>
    where TRequest : AbortSessionCommand
{
    private readonly ISessionRepository sessionRepository;

    public AbortSessionCommandHandler(
        ISessionRepository sessionRepository,
        ILogger<AbortSessionCommandHandler<TRequest>> logger)
        : base(logger)
    {
        this.sessionRepository = sessionRepository;
    }

    protected override async Task Action(TRequest request, CancellationToken cancellationToken)
    {
        SessionId id = SessionId.Create(request.SessionId);
        Session session = await sessionRepository.GetBy(id);
        session.ChangeState(States.Aborted);
        await sessionRepository.Update(session);
    }
}
