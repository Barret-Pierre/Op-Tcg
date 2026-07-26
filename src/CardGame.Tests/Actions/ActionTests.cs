using CardGame.Engine.Actions;
using CardGame.Engine.Cards;
using CardGame.Engine.Game;
using CardGame.Engine.Players;
using CardGame.Engine.Zones;

namespace CardGame.Tests;

public class ActionTests
{
    [Fact]
    public void Player_can_play_card_using_action()
    {
        var card = new CharacterCardDefinition(
            id: "1",
            name: "Luffy",
            cost: 5,
            power: 7000
        );


        var player1 = new Player(
            "Luffy",
            new Deck()
        );


        var player2 = new Player(
            "Zoro",
            new Deck()
        );


        player1.Hand.Add(
            new CardInstance(card)
        );


        var game = new Game(
            player1,
            player2
        );


        game.Start();


        game.ExecuteAction(
            new PlayCardAction(0)
        );


        Assert.Empty(player1.Hand.Cards);

        Assert.Single(player1.Board.Cards);
    }
}