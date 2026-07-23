using CardGame.Engine.Game;
using CardGame.Engine.Players;
using CardGame.Engine.Zones;

namespace CardGame.Tests;

public class GameTests
{
    [Fact]
    public void Game_should_switch_player_turn()
    {
        var player1 = new Player(
            "Luffy",
            new Deck()
        );


        var player2 = new Player(
            "Zoro",
            new Deck()
        );


        var game = new Game(
            player1,
            player2
        );


        game.Start();


        Assert.Equal(
            "Luffy",
            game.State.CurrentPlayer.Name
        );


        game.EndTurn();


        Assert.Equal(
            "Zoro",
            game.State.CurrentPlayer.Name
        );
    }
}