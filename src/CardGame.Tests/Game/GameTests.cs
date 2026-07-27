using CardGame.Engine.Actions;
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
            "Luffy"
        );


        var player2 = new Player(
            "Zoro"
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


        game.ExecuteAction(
           new EndTurnAction()
       );


        Assert.Equal(
            "Zoro",
            game.State.CurrentPlayer.Name
        );
    }
}