using CardGame.Engine.Cards;
using CardGame.Engine.Players;
using CardGame.Engine.Zones;

namespace CardGame.Tests;

public class CardTests
{
    [Fact]
    public void Player_can_draw_card()
    {
        var luffy = new CardDefinition
        {
            Id = 1,
            Name = "Luffy",
            Cost = 5,
            Power = 7000
        };


        var deck = new Deck();

        deck.Add(
            new CardInstance(luffy)
        );


        var player = new Player(
            "Player 1",
            deck
        );


        player.DrawCard();


        Assert.Equal(1, player.Hand.Count);

        Assert.Equal(
            "Luffy",
            player.Hand.Cards[0].Definition.Name
        );
    }
}