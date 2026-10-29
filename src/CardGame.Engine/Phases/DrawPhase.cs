using CardGame.Engine.Players;

namespace CardGame.Engine.Phases;

public sealed class DrawPhase : IPhase
{
    private readonly PlayerBoard _playerBoard;

    public DrawPhase(PlayerBoard playerBoard)
    {
        _playerBoard = playerBoard;
    }

    public void Execute()
    {
        var card = _playerBoard.Deck.Draw();

        _playerBoard.Hand.Add(card);
    }
}