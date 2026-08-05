using CardGame.Engine.Cards;
using CardGame.Engine.Players;
using CardGame.Engine.Zones;

namespace CardGame.Tests;

public class CardTests
{
    [Fact]
    public void Player_can_draw_card()
    {
        var luffy = new CharacterCardDefinition(
            id: "1",
            name: "Luffy",
            cost: 5,
            power: 7000
        );

        var player = new Player(
            "Player 1"
        );

        player.PlayerBoard.Deck.Add(
            new CardInstance(luffy)
        );


        var drawnCard = player.PlayerBoard.Deck.Draw();
        player.PlayerBoard.Hand.Add(
            drawnCard
        );


        Assert.Single(player.PlayerBoard.Hand.VisibleCards);

        Assert.Equal(
            "Luffy",
            player.PlayerBoard.Hand.VisibleCards[0].Definition.Name
        );
    }
}