using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Session;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.SessionCommands;

public abstract class ProcessSessionCommandHandler<TRequest>
    : CommandHandler<TRequest, ProcessSessionCommandResponse?>
    where TRequest : ProcessSessionCommand
{
    private readonly ISessionRepository sessionRepository;

    public ProcessSessionCommandHandler(
        ISessionRepository sessionRepository,
        ILogger<ProcessSessionCommandHandler<TRequest>> logger)
        : base(logger)
    {
        this.sessionRepository = sessionRepository;
    }

    protected override async Task<ProcessSessionCommandResponse?> Action(TRequest request, CancellationToken cancellationToken)
    {
        SessionId id = SessionId.Create(request.SessionId);
        Session session = await sessionRepository.GetBy(id);
        GameResult? gameResult = session.Process(request.ProcessParam);
        await sessionRepository.Update(session);

        return new(session.State, gameResult);
    }
}
