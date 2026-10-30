using CardGame.Engine.Actions;
using CardGame.Engine.Cards;
using CardGame.Engine.Games;
using CardGame.Engine.Players;
using CardGame.Engine.Turns;

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
            "Luffy"
        );


        var player2 = new Player(
            "Zoro"
        );


        player1.PlayerBoard.Hand.Add(
            new CardInstance(card)
        );


        var game = new Game(
            new List<Player> { player1, player2 },
            new TurnManager()
        );



        game.Start();


        game.ExecuteAction(
            new PlayCardAction(
                player1.PlayerBoard.Hand,
                player1.PlayerBoard.CharacterZone,
                player1.PlayerBoard.DonCostZone,
                player1.PlayerBoard.Hand.VisibleCards[0]
            )
        );


        Assert.Empty(player1.PlayerBoard.Hand.VisibleCards);

        Assert.Single(player1.PlayerBoard.CharacterZone.VisibleCards);
    }
}