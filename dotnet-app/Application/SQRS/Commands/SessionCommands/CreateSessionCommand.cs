using Domain.Shared;

namespace Application.SQRS.Commands.SessionCommands;

public abstract record CreateSessionCommand(GameTypes GameType, IEnumerable<string> PlayerNames);
