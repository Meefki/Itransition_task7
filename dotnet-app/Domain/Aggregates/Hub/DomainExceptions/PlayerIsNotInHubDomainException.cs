using Domain.SeedWork;

namespace Domain.Aggregates.Hub.DomainExceptions;

public class PlayerIsNotInHubDomainException
    : DomainException<PlayerIsNotInHubDomainException>
{
    static PlayerIsNotInHubDomainException()
    {
        MessageText = "Player {0} is not in hub {1}";
    }

    public static void Throw(HubId hubId, Player player)
    {
        ThrowEx(string.Format(MessageText, player.Name, hubId.Value));
    }
}
