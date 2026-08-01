using CardGame.Engine.Players;

namespace CardGame.Engine.Games;

public sealed class GameStartEventArgs : EventArgs
{
    public IReadOnlyList<Player> Players { get; }

    public Player FirstPlayer { get; }

    public GameStartEventArgs(IReadOnlyList<Player> players, Player firstPlayer)
    {
        Players = players;
        FirstPlayer = firstPlayer;
    }
}