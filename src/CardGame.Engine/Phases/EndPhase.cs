using CardGame.Engine.Players;
using CardGame.Engine.Cards;

namespace CardGame.Engine.Phases;

public sealed class EndPhase : Phase
{
    private const int HandLimit = 10;
    private readonly PlayerBoard _playerBoard;
    private readonly Func<IReadOnlyList<CardInstance>, CardInstance> _chooseCardToDiscard;

    public EndPhase(PlayerBoard playerBoard, Func<IReadOnlyList<CardInstance>, CardInstance> chooseCardToDiscard)
    {
        _playerBoard = playerBoard;
        _chooseCardToDiscard = chooseCardToDiscard;
    }

    public override void Execute()
    {
        while (_playerBoard.Hand.VisibleCards.Count > HandLimit)
        {
            var card = _chooseCardToDiscard(_playerBoard.Hand.VisibleCards);

            _playerBoard.Hand.Remove(card);
            _playerBoard.DiscardZone.Add(card);
        }
    }
}