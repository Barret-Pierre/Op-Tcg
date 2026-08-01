namespace CardGame.Engine.Actions;

public sealed class PassAction : GameAction
{
    protected override bool CanExecute()
    {
        return true;
    }

    protected override void ExecuteCore()
    {
    }
}