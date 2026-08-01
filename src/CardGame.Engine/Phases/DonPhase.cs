using CardGame.Engine.Players;

namespace CardGame.Engine.Phases;

public sealed class DonPhase : Phase
{
    private const int DonPerTurn = 2;

    private readonly PlayerBoard _playerBoard;

    public DonPhase(PlayerBoard playerBoard)
    {
        _playerBoard = playerBoard;
    }
    public override void Execute()
    {
        for (var i = 0; i < DonPerTurn; i++)
        {
            var don = _playerBoard.DonDeck.Draw();

            _playerBoard.DonCostZone.Add(don);
        }
    }
}