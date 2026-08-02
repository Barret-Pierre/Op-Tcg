using CardGame.Engine.Actions;

namespace CardGame.Engine.Phases;

public sealed class MainPhase : Phase
{
    public override void Execute()
    {
    }

    public void ExecuteAction(GameAction action)
    {
        action.Execute();
    }
}