using CardGame.Engine.Actions;
using CardGame.Engine.Players;
using CardGame.Engine.Games;
using CardGame.Engine.Turns;

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
            new List<Player> { player1, player2 },
            new TurnManager()
        );


        game.Start();


        Assert.Equal(
            "Luffy",
            game.State.CurrentPlayer.Name
        );


        game.ExecuteAction(
           new PassAction()
       );


        Assert.Equal(
            "Zoro",
            game.State.CurrentPlayer.Name
        );
    }
}