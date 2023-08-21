using Domain.Aggregates.Session;
using Domain.Aggregates.Session.GameProcessorEntity;
using Domain.Shared;
using GameAdapter.TicTacToe.Exceptions;
using GameAdapter.TicTacToe.Parameters;

namespace GameAdapter.TicTacToe;

public sealed class TicTacToeGameProcessor
    : GameProcessor
{
    private Player player1 = null!;
    private Player player2 = null!;

    private PlayerSigns player1Sign;
    private PlayerSigns player2Sign;

    private Player playerMove = null!;

    private const int FIELD_SIZE = 3;
    private PlayerSigns[,] field;

    public TicTacToeGameProcessor(GameTypes gameType)
        : base(GameProcessorId.Create(gameType))
    {
        PlayersCount = 2;
        field = new PlayerSigns[FIELD_SIZE, FIELD_SIZE];
    }

    public override int PlayersCount { get; init; }

    public override GameResult? Process(dynamic processParam)
    {
        if (processParam is not NextMoveParam)
            WrongNextMoveParameterTypeException.Throw(this);

        GameResult? gameResult = NextMove((NextMoveParam)processParam);

        return gameResult;
    }

    private GameResult? NextMove(NextMoveParam nextMove)
    {
        if (field[nextMove.RowNumber, nextMove.ColNumber] != PlayerSigns.None)
            PositionOccupiedException.Throw(nextMove.RowNumber, nextMove.ColNumber);
        if (playerMove! != nextMove.Player)
            WrongPlayerMoveException.Throw(nextMove.Player.Name);

        PlayerSigns playerMoveSign = nextMove.Player == player1 ? player1Sign : player2Sign;
        field[nextMove.RowNumber, nextMove.ColNumber] = playerMoveSign;

        bool isWin = CheckWin(playerMoveSign);

        if (isWin)
        {
            GameResult gameResult = GameResult.CreateWin(playerMove, Id.Value);
            return gameResult;
        }

        playerMove = nextMove.Player == player1 ? player1 : player2;
        return null;
    }

    private bool CheckWin(PlayerSigns sign)
    {
        for (int i = 0; i < FIELD_SIZE; i++)
        {
            if (CheckLine(i, 0, 0, 1, sign)) return true;
            if (CheckLine(0, i, 1, 0, sign)) return true;
        }

        if (CheckLine(0, 0, 1, 1, sign)) return true;
        if (CheckLine(0, FIELD_SIZE - 1, 1, -1, sign)) return true;

        return false;
    }

    private bool CheckLine(int startX, int startY, int dx, int dy, PlayerSigns sign)
    {
        for (int i = 0; i < FIELD_SIZE; i++)
        {
            if (field[startX + i * dx, startY + i * dy] != sign)
                return false;
        }

        return true;
    }

    public override void Start(dynamic startParam)
    {
        if (startParam is not StartParam)
            WrongStartParameterTypeException.Throw(this);

        Start((StartParam)startParam);
    }

    private void Start(StartParam startParam)
    {
        player1 = startParam.Player1;
        player2 = startParam.Player2;
        playerMove = player1;
        
        if (startParam.Player1Sign == startParam.Player2Sign ||
            startParam.Player1Sign == PlayerSigns.None ||
            startParam.Player2Sign == PlayerSigns.None)
            WrongPlayerSignException.Throw();

        player1Sign = startParam.Player1Sign;
        player2Sign = startParam.Player2Sign;
    }

    #region Disposing

    private bool isDisposed = false;

    protected override void Dispose(bool disposing)
    {
        if (isDisposed)
            return;

        if (disposing)
        {
            player1 = null!; 
            player2 = null!;

            playerMove = null!;
            field = null!;
        }

        isDisposed = true; 
    }

    #endregion
}
