using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Session;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.SessionCommands;

public abstract class StartSessionCommandHandler<TRequest>
    : CommandHandler<TRequest>
    where TRequest : StartSessionCommand
{
    private readonly ISessionRepository sessionRepository;

    public StartSessionCommandHandler(
        ISessionRepository sessionRepository,
        ILogger<StartSessionCommandHandler<TRequest>> logger)
        : base(logger)
    {
        this.sessionRepository = sessionRepository;
    }

    protected override async Task Action(TRequest request, CancellationToken cancellationToken)
    {
        SessionId id = SessionId.Create(request.SessionId);
        Session session = await sessionRepository.GetBy(id);
        session.ChangeState(States.Started, request.StartParam);
        await sessionRepository.Update(session);
    }
}
