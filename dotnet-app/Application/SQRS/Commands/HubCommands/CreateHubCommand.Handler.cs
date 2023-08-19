using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Hub;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.HubCommands;

public abstract class CreateHubCommandHandler<TRequest>
    : CommandHandler<TRequest, string>
    where TRequest : CreateHubCommand
{
    private readonly IHubRepository hubRepository;
    private readonly IGameFactory gameFactory;

    public CreateHubCommandHandler(
        IHubRepository hubRepository,
        IGameFactory gameFactory,
        ILogger<CreateHubCommandHandler<TRequest>> logger)
        : base(logger)
    {
        this.hubRepository = hubRepository;
        this.gameFactory = gameFactory;
    }

    protected override async Task<string> Action(TRequest request, CancellationToken cancellationToken)
    {
        Player hubLeader = new(request.HubLeaderName, true);
        Hub hub = new(gameFactory, request.GameType, hubLeader);
        await hubRepository.Create(hub);

        string hubId = hub.Id.Value.ToString();
        return hubId;
    }
}
