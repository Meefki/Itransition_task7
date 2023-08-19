using Application.Repositories;
using Application.SeedWork;
using Domain.Aggregates.Hub;
using Microsoft.Extensions.Logging;

namespace Application.SQRS.Commands.HubCommands;

public abstract class JoinPlayerCommandHandler<TRequest>
    : CommandHandler<TRequest>
    where TRequest : JoinPlayerCommand
{
    private readonly IHubRepository hubRepository;

    public JoinPlayerCommandHandler(
        IHubRepository hubRepository,
        ILogger<JoinPlayerCommandHandler<TRequest>> logger)
        : base(logger)
    {
        this.hubRepository = hubRepository;
    }

    protected override async Task Action(TRequest request, CancellationToken cancellationToken)
    {
        HubId id = HubId.Create(request.HubId);
        Hub hub = await hubRepository.GetBy(id);
        Player player = new(request.PlayerName);
        hub.AddPlayer(player);
        await hubRepository.Update(hub);
    }
}
