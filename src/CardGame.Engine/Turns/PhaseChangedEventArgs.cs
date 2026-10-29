using CardGame.Engine.Phases;

namespace CardGame.Engine.Turns;

public sealed class PhaseChangedEventArgs : EventArgs
{
    public PhaseChangedEventArgs(IPhase phase)
    {
        Phase = phase;
    }

    public IPhase Phase { get; }
}