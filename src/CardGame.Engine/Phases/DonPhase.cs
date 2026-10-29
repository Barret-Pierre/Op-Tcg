using CardGame.Engine.Players;

namespace CardGame.Engine.Phases;

public sealed class DonPhase : IPhase
{
    private const int DonPerTurn = 2;

    private readonly PlayerBoard _playerBoard;

    public DonPhase(PlayerBoard playerBoard)
    {
        _playerBoard = playerBoard;
    }
    public void Execute()
    {
        for (var i = 0; i < DonPerTurn; i++)
        {
            if (_playerBoard.DonDeck.IsEmpty)
                break;

            var don = _playerBoard.DonDeck.Draw();
            _playerBoard.DonCostZone.Add(don);
        }
    }
}