using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Hub;
using Domain.SeedWork;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.HubCommands;

public abstract class CreateHubCommandHandler<T>
    : ICommandHandler<T, Tuple<bool, string, DomainErrorDetails?>>
    where T : CreateHubCommand
{
    private readonly IHubRepository hubRepository;
    private readonly IGameFactory gameFactory;
    private readonly ILogger<CreateHubCommandHandler<T>> logger;

    public CreateHubCommandHandler(
        IHubRepository hubRepository,
        IGameFactory gameFactory,
        ILogger<CreateHubCommandHandler<T>> logger)
    {
        this.hubRepository = hubRepository;
        this.gameFactory = gameFactory;
        this.logger = logger;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2254:Template should be a static expression", Justification = "<Pending>")]
    public virtual async Task<Tuple<bool, string, DomainErrorDetails?>> Handle(T request, CancellationToken cancellationToken = default)
    {
        DomainErrorDetails? errorDetails = null;
        string hubId = "";
        bool result = true;

        try
        {
            Player hubLeader = new(request.HubLeaderName, true);
            Hub hub = new(gameFactory, request.GameType, hubLeader);
            await hubRepository.Create(hub);

            hubId = hub.Id.Value.ToString();
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

        return new(result, hubId, errorDetails);
    }
}
