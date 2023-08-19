namespace Application.SQRS.Commands.HubCommands;

public abstract record ExpelPlayerCommand(string HubId, string PlayerName);
