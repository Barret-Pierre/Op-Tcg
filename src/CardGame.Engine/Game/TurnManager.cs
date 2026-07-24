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
        state.ChangePhase(GamePhase.Draw);


        Console.WriteLine();

        Console.WriteLine(
            $"Turn {state.TurnNumber} - {state.CurrentPlayer.Name}"
        );


        DrawPhase();


        MainPhase();
    }

    private void DrawPhase()
    {
        Console.WriteLine("Draw phase");


        // state.CurrentPlayer.DrawCard();


        state.ChangePhase(GamePhase.Main);
    }


    private void MainPhase()
    {
        Console.WriteLine("Main phase");
    }



    public void StartCombat()
    {
        state.ChangePhase(GamePhase.Combat);


        Console.WriteLine(
            "Combat phase"
        );
    }

    public void EndTurn()
    {
        state.ChangePhase(GamePhase.End);


        Console.WriteLine(
            "End phase"
        );


        state.NextPlayer();


        StartTurn();
    }




}