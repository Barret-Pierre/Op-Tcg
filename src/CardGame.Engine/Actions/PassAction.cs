namespace CardGame.Engine.Actions;

public sealed class PassAction : Action
{
    protected override bool CanExecute()
    {
        return true;
    }

    protected override void ExecuteCore()
    {
    }
}