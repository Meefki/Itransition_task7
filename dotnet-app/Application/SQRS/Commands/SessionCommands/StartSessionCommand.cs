namespace Application.SQRS.Commands.SessionCommands;

public abstract record StartSessionCommand(string SessionId, dynamic StartParam);