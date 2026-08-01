namespace CardGame.Engine.Actions;

public abstract class GameAction
{
    public void Execute()
    {
        if (!CanExecute())
            throw new InvalidOperationException("The action cannot be executed.");

        ExecuteCore();
    }

    protected abstract bool CanExecute();

    protected abstract void ExecuteCore();
}