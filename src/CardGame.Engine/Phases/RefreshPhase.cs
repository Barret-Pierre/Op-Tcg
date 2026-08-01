using CardGame.Engine.Players;

namespace CardGame.Engine.Phases;

public sealed class RefreshPhase : Phase
{
    private readonly PlayerBoard _playerBoard;

    public RefreshPhase(PlayerBoard playerBoard)
    {
        _playerBoard = playerBoard;
    }
    public override void Execute()
    {
        _playerBoard.LeaderZone.Leader.Activate();

        foreach (var character in _playerBoard.CharacterZone.VisibleCards)
            character.Activate();

        foreach (var don in _playerBoard.DonCostZone.VisibleCards)
            don.Activate();
    }
}