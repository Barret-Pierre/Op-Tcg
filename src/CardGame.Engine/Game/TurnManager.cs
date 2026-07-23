namespace CardGame.Engine.Game;

public class TurnManager
{
    private readonly GameState state;


    public TurnManager(GameState state)
    {
        this.state = state;
    }



    public void StartTurn()
    {
        Console.WriteLine(
            $"Turn {state.TurnNumber} - {state.CurrentPlayer.Name}"
        );
    }



    public void EndTurn()
    {
        state.NextPlayer();

        StartTurn();
    }
}