namespace Application.SQRS.Commands.HubCommands;

public abstract record JoinPlayerCommand(string HubId, string PlayerName);
