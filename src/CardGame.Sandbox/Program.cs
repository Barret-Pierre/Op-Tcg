using CardGame.Sandbox;
using CardGame.Engine.Games;

Console.WriteLine("=================");
Console.WriteLine(" CARD GAME ENGINE ");
Console.WriteLine("=================");
Console.WriteLine();

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