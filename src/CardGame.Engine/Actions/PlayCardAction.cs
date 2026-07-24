using CardGame.Engine.Cards;
using CardGame.Engine.Game;

namespace CardGame.Engine.Actions;

public class PlayCardAction : IGameAction
{
    private readonly int cardIndex;


    public PlayCardAction(int cardIndex)
    {
        this.cardIndex = cardIndex;
    }


    public void Execute(GameState state)
    {
        if (state.CurrentPhase != GamePhase.Main)
        {
            throw new InvalidOperationException(
                "Cards can only be played during main phase"
            );
        }

        var player = state.CurrentPlayer;


        if (cardIndex < 0 || cardIndex >= player.Hand.Count)
        {
            throw new InvalidOperationException(
                "Invalid card index"
            );
        }


        var card = player.Hand.Cards[cardIndex];


        player.Hand.Remove(card);


        player.Board.Add(card);


        card.Play();
    }
}