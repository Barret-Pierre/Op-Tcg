using CardGame.Engine.Players;

namespace CardGame.Engine.Games;

public sealed class GameEndEventArgs : EventArgs
{
    public Player? Winner { get; }

    public GameEndEventArgs(Player? winner)
    {
        Winner = winner;
    }
}