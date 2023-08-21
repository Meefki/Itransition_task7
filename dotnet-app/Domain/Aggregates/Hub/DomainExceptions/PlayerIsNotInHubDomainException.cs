using Domain.SeedWork;

namespace Domain.Aggregates.Hub.DomainExceptions;

public sealed class PlayerIsNotInHubDomainException
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

    public PlayerIsNotInHubDomainException(string message = "")
        : base(message)
    {
    }

    public PlayerIsNotInHubDomainException(string message = "", Exception? innerException = null)
        : base(message: message, innerException: innerException)
    {
    }
}
