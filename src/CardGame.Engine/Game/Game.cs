using CardGame.Engine.Players;
using CardGame.Engine.Actions;

namespace CardGame.Engine.Game;

public class Game
{
    private const int StartingHandSize = 1;

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

        foreach (var player in State.Players)
        {
            for (int i = 0; i < StartingHandSize; i++)
            {
                player.DrawCard();
            }
        }

        TurnManager.StartTurn();
    }

    public void ExecuteAction(IGameAction action)
    {
        action.Execute(State);

        CheckVictory();

        if (action is EndTurnAction)
        {
            TurnManager.StartTurn();
        }
    }

    private void CheckVictory()
    {
        foreach (var player in State.Players)
        {
            if (player.Health <= 0)
            {
                var winner = State.Players
                    .First(x => x != player);


                State.SetWinner(winner);

                Console.WriteLine();

                Console.WriteLine(
                    $"{winner.Name} wins!"
                );
            }
        }
    }
}