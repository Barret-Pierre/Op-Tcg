using CardGame.Engine.Players;

namespace CardGame.Engine.Game;

public class GameState
{
    public List<Player> Players { get; } = new();


    public int CurrentPlayerIndex { get; private set; }


    public int TurnNumber { get; private set; }


    public bool IsStarted { get; private set; }


    public Player CurrentPlayer
    {
        get
        {
            return Players[CurrentPlayerIndex];
        }
    }

    public void Start()
    {
        if (Players.Count < 2)
        {
            throw new InvalidOperationException(
                "A game requires at least 2 players"
            );
        }


        TurnNumber = 1;

        CurrentPlayerIndex = 0;

        IsStarted = true;
    }



    public void NextPlayer()
    {
        CurrentPlayerIndex++;

        TurnNumber++;

        if (CurrentPlayerIndex >= Players.Count)
        {
            CurrentPlayerIndex = 0;
        }
    }
}