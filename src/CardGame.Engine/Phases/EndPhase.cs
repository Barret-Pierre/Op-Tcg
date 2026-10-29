using CardGame.Engine.Players;
using CardGame.Engine.Cards;

namespace CardGame.Engine.Phases;

public sealed class EndPhase : IPhase
{
    private const int HandLimit = 10;
    private readonly PlayerBoard _playerBoard;

    public EndPhase(PlayerBoard playerBoard)
    {
        _playerBoard = playerBoard;
    }

    public void Execute()
    {
        while (_playerBoard.Hand.VisibleCards.Count > HandLimit)
        {
            var card = _playerBoard.Hand.VisibleCards[^1];

            _playerBoard.Hand.Remove(card);
            _playerBoard.DiscardZone.Add(card);
        }
    }
}