using CardGame.Engine.Players;
using CardGame.Engine.Actions;

namespace CardGame.Engine.Game;

public class Game
{
    public GameState State { get; }

    public TurnManager TurnManager { get; }

    public Game(
        Player player1,
        Player player2
    )
    {
        State = new GameState();


        State.Players.Add(player1);

        State.Players.Add(player2);


        TurnManager = new TurnManager(State);
    }

    public void Start()
    {
        State.Start();

        TurnManager.StartTurn();
    }

    public void EndTurn()
    {
        TurnManager.EndTurn();
    }

    public void ExecuteAction(IGameAction action)
    {
        action.Execute(State);
    }
}