using Domain.Aggregates.Session;

namespace GameAdapter.TicTacToe.Parameters;

public sealed record StartParam(Player Player1, Player Player2, PlayerSigns Player1Sign, PlayerSigns Player2Sign);
