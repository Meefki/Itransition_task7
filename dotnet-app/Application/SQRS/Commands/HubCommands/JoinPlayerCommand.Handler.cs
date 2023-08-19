using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Hub;
using Domain.SeedWork;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.HubCommands;

public abstract class JoinPlayerCommandHandler<T>
    : ICommandHandler<T, Tuple<bool, DomainErrorDetails?>>
    where T : JoinPlayerCommand
{
    private readonly IHubRepository hubRepository;
    private readonly ILogger<JoinPlayerCommandHandler<T>> logger;

    public JoinPlayerCommandHandler(
        IHubRepository hubRepository,
        ILogger<JoinPlayerCommandHandler<T>> logger)
    {
        this.hubRepository = hubRepository;
        this.logger = logger;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2254:Template should be a static expression", Justification = "<Pending>")]
    public virtual async Task<Tuple<bool, DomainErrorDetails?>> Handle(T request, CancellationToken cancellationToken = default)
    {
        DomainErrorDetails? errorDetails = null;
        bool result = true;

        try
        {
            HubId id = HubId.Create(request.HubId);
            Hub hub = await hubRepository.GetBy(id);
            Player player = new(request.PlayerName);
            hub.AddPlayer(player);
            await hubRepository.Update(hub);
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
