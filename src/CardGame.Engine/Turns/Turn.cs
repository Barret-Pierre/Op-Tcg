using CardGame.Engine.Phases;
using CardGame.Engine.Players;
using CardGame.Engine.Actions;

namespace CardGame.Engine.Turns;

public sealed class Turn
{
    private readonly List<Phase> _phases;

    private int _currentPhaseIndex;

    public Player ActivePlayer { get; }

    public Phase CurrentPhase => _phases[_currentPhaseIndex];

    public event EventHandler<PhaseChangedEventArgs>? PhaseChanged;

    public Turn(Player activePlayer)
    {
        ActivePlayer = activePlayer;

        _phases =
        [
            new RefreshPhase(activePlayer.PlayerBoard),
            new DrawPhase(activePlayer.PlayerBoard),
            new DonPhase(activePlayer.PlayerBoard),
            new MainPhase(),
            new EndPhase(activePlayer.PlayerBoard)
        ];

        _currentPhaseIndex = 0;
    }

    public void Start()
    {
        CurrentPhase.Execute();
    }

    public void NextPhase()
    {
        if (_currentPhaseIndex >= _phases.Count - 1)
            return;

        _currentPhaseIndex++;

        PhaseChanged?.Invoke(this, new PhaseChangedEventArgs(CurrentPhase));

        CurrentPhase.Execute();
    }

    public void ExecuteAction(GameAction action)
    {
        if (CurrentPhase is not MainPhase mainPhase)
            throw new InvalidOperationException("Actions can only be executed during the main phase.");

        if (action is PassAction)
        {
            NextPhase(); // passe à EndPhase
            return;
        }

        mainPhase.ExecuteAction(action);
    }
}