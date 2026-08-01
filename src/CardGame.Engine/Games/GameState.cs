using CardGame.Engine.Players;

namespace CardGame.Engine.Games;

public sealed class GameState
{
    public Player? Winner { get; set; }

    public GameStatus Status { get; set; } = GameStatus.WaitingForPlayers;
}