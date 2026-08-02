using CardGame.Engine.Players;
using CardGame.Engine.Actions;

namespace CardGame.Engine.Turns;

public class TurnManager
{
    public Turn CurrentTurn { get; private set; } = null!;

    public event EventHandler<TurnChangedEventArgs>? TurnChanged;

    public void StartTurn(Player player)
    {
        CurrentTurn = new Turn(player);

        TurnChanged?.Invoke(this, new TurnChangedEventArgs(CurrentTurn));

        CurrentTurn.Start();
    }

    public void NextTurn(Player nextPlayer)
    {
        StartTurn(nextPlayer);
    }

    public void ExecuteAction(GameAction action)
    {
        CurrentTurn.ExecuteAction(action);
    }
}