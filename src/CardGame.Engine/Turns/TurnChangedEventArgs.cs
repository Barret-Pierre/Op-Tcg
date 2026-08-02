namespace CardGame.Engine.Turns;

public sealed class TurnChangedEventArgs : EventArgs
{
    public TurnChangedEventArgs(Turn turn)
    {
        Turn = turn;
    }

    public Turn Turn { get; }
}