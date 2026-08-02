using CardGame.Engine.Phases;

namespace CardGame.Engine.Turns;

public sealed class PhaseChangedEventArgs : EventArgs
{
    public PhaseChangedEventArgs(Phase phase)
    {
        Phase = phase;
    }

    public Phase Phase { get; }
}