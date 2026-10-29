using CardGame.Engine.Actions;

namespace CardGame.Engine.Phases;

public sealed class MainPhase : IPhase
{
    public void Execute()
    {
    }

    public static void ExecuteAction(GameAction action)
    {
        action.Execute();
    }
}