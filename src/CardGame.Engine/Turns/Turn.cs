using CardGame.Engine.Phases;
using CardGame.Engine.Players;
using CardGame.Engine.Actions;

namespace CardGame.Engine.Turns;

public sealed class Turn
{
    private readonly List<IPhase> _phases;

    private int _currentPhaseIndex;

    public Player ActivePlayer { get; }

    public IPhase CurrentPhase => _phases[_currentPhaseIndex];

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
        AdvanceUntilMain();
    }

    public void NextPhase()
    {
        if (_currentPhaseIndex >= _phases.Count - 1)
            return;

        _currentPhaseIndex++;
        PhaseChanged?.Invoke(this, new PhaseChangedEventArgs(CurrentPhase));

        if (CurrentPhase is MainPhase)
        {
            // TODO : A supprimer, garde la cohérence avec l'ancienne version, mais pas nécessaire
            CurrentPhase.Execute(); // no-op, mais garde la cohérence
            return;
        }

        CurrentPhase.Execute();

        if (CurrentPhase is not MainPhase and not EndPhase)
            NextPhase();
    }

    public void ExecuteAction(GameAction action)
    {
        if (CurrentPhase is not MainPhase)
            throw new InvalidOperationException("Actions can only be executed during the main phase.");

        if (action is PassAction)
        {
            NextPhase(); // passe à EndPhase
            return;
        }

        MainPhase.ExecuteAction(action);
    }

    private void AdvanceUntilMain()
    {
        CurrentPhase.Execute();

        while (CurrentPhase is not MainPhase)
            NextPhase();
    }
}