using Domain.Aggregates.Hub;
using Domain.Shared;

namespace Application.Services.HubServices;

public interface IHubService
{
    Hub Create(int requiredPlayersCount, GameTypes gameTypes, Player hubLeader);
    void JoinPlayer(Hub hub, Player player);
}
