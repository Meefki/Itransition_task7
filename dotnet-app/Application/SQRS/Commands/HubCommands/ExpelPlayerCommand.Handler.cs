using Application.SeedWork;
using Application.Repositories;
using Domain.Aggregates.Hub;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.HubCommands;

public abstract class ExpelPlayerCommandHandler<TRequest>
    : CommandHandler<TRequest>
    where TRequest : ExpelPlayerCommand
{
    private readonly IHubRepository hubRepository;

    public ExpelPlayerCommandHandler(
        IHubRepository hubRepository,
        ILogger<ExpelPlayerCommandHandler<TRequest>> logger)
        : base(logger)
    {
        this.hubRepository = hubRepository;
    }

    protected override async Task Action(TRequest request, CancellationToken cancellationToken)
    {
        HubId id = HubId.Create(request.HubId);
        Hub hub = await hubRepository.GetBy(id);
        Player player = hub.Players.First(x => x.Name == request.PlayerName);
        hub.RemovePlayer(player);
        await hubRepository.Update(hub);
    }
}
