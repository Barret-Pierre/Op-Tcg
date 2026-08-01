using CardGame.Engine.Actions;

namespace CardGame.Engine.Phases;

public sealed class MainPhase : Phase
{
    private readonly Func<GameAction?> _getNextAction;

    public MainPhase(Func<GameAction?> getNextAction)
    {
        _getNextAction = getNextAction;
    }
    public override void Execute()
    {
        while (true)
        {
            var action = _getNextAction();

            if (action is null || action is PassAction)
                break;

            action.Execute();
        }
    }
}