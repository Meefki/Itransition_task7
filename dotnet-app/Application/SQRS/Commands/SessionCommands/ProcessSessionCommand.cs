namespace Application.SQRS.Commands.SessionCommands;

public abstract record ProcessSessionCommand(string SessionId, dynamic ProcessParam);
