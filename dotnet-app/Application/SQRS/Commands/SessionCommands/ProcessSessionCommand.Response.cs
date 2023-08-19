using Domain.Aggregates.Session;

namespace Application.SQRS.Commands.SessionCommands;

public class ProcessSessionCommandResponse
{
    public ProcessSessionCommandResponse(States state, GameResult? gameResult)
    {
        State = state;
        GameResult = gameResult;
    }

    public States State { get; }
    public GameResult? GameResult { get; }
}
