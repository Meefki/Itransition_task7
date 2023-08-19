using Domain.Shared;

namespace Application.SQRS.Commands.HubCommands;

public abstract record CreateHubCommand(GameTypes GameType, string HubLeaderName);
