using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Session;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.SessionCommands;

public abstract class SuspendSessionCommandHandler<TRequest>
    : CommandHandler<TRequest>
    where TRequest : SuspendSessionCommand
{
    private readonly ISessionRepository sessionRepository;

    public SuspendSessionCommandHandler(
        ISessionRepository sessionRepository,
        ILogger<SuspendSessionCommandHandler<TRequest>> logger)
        : base(logger)
    {
        this.sessionRepository = sessionRepository;
    }

    protected override async Task Action(TRequest request, CancellationToken cancellationToken)
    {
        SessionId id = SessionId.Create(request.SessionId);
        Session session = await sessionRepository.GetBy(id);
        session.ChangeState(States.Suspended);
        await sessionRepository.Update(session);
    }
}
