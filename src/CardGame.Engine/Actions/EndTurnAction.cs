using CardGame.Engine.Game;

namespace CardGame.Engine.Actions;

public class EndTurnAction : IGameAction
{
    public void Execute(GameState state)
    {
        state.NextPlayer();
    }
}