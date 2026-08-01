using CardGame.Engine.Players;
using CardGame.Engine.Turns;

namespace CardGame.Engine.Games;

public class Game
{
    public Guid Id { get; } = Guid.NewGuid();

    public IReadOnlyList<Player> Players { get; }

    public GameState State { get; } = new();

    public TurnManager TurnManager { get; }

    public event EventHandler<GameStartEventArgs>? GameStarted;

    public event EventHandler<GameEndEventArgs>? GameEnded;

    public Game(IReadOnlyList<Player> players, TurnManager turnManager)
    {
        if (players.Count != 2)
            throw new ArgumentException("A game requires exactly two players.", nameof(players));

        Players = players;
        TurnManager = turnManager;
    }

    public void Start()
    {
        State.Status = GameStatus.InProgress;

        GameStarted?.Invoke(this, new GameStartEventArgs(Players, Players[0]));
    }

    public void End()
    {
        State.Status = GameStatus.Finished;

        GameEnded?.Invoke(this, new GameEndEventArgs(State.Winner));
    }

}