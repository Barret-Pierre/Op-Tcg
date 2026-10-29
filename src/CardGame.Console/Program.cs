using CardGame.Console;
using CardGame.Engine.Games;

System.Console.WriteLine("=================");
System.Console.WriteLine(" CARD GAME ENGINE ");
System.Console.WriteLine("=================");
System.Console.WriteLine();

var game = GameSetup.CreateGame();
game.Start();

while (game.State.Status == GameStatus.InProgress)
{
    if (game.TurnManager.CurrentTurn.CurrentPhase is not CardGame.Engine.Phases.MainPhase)
    {
        // phase automatique déjà exécutée par Turn, rien à faire ici
        continue;
    }

    TurnController.RunMainPhase(game);
}

ConsoleRenderer.PrintGameEnd(game.State);