using CardGame.Engine.Actions;
using CardGame.Engine.Cards;
using CardGame.Engine.Games;
using CardGame.Engine.Players;

namespace CardGame.Sandbox;

internal static class TurnController
{
    public static void RunMainPhase(Game game)
    {
        var player = game.State.CurrentPlayer;
        var opponent = game.Players.First(p => p != player);
        var phaseName = game.TurnManager.CurrentTurn.CurrentPhase.GetType().Name;

        ConsoleRenderer.PrintTurnHeader(game.State.TurnNumber, player.Name, phaseName);
        ConsoleRenderer.PrintBoard($"{player.Name} (vous)", player.PlayerBoard, showHand: true);
        ConsoleRenderer.PrintBoard($"{opponent.Name} (adversaire)", opponent.PlayerBoard, showHand: false);

        Console.WriteLine();
        Console.WriteLine("1 - Jouer une carte");
        Console.WriteLine("2 - Passer");
        Console.WriteLine("3 - Attaquer");
        Console.Write("> ");

        switch (Console.ReadLine())
        {
            case "1":
                HandlePlayCard(game, player);
                break;
            case "2":
                game.ExecuteAction(new PassAction());
                break;
            case "3":
                HandleAttack(game, player, opponent);
                break;
        }
    }

    private static void HandlePlayCard(Game game, Player player)
    {
        Console.Write("Index de la carte à jouer > ");
        if (!int.TryParse(Console.ReadLine(), out var index) ||
            index < 0 || index >= player.PlayerBoard.Hand.Count)
            return;

        var cardToPlay = player.PlayerBoard.Hand.VisibleCards[index];

        try
        {
            game.ExecuteAction(new PlayCardAction(
                player.PlayerBoard.Hand,
                player.PlayerBoard.CharacterZone,
                player.PlayerBoard.DonCostZone,
                cardToPlay));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Action impossible : {ex.Message}");
        }
    }

    private static void HandleAttack(Game game, Player player, Player opponent)
    {
        Console.Write("Index de l'attaquant (-1 pour le Leader) > ");
        if (!int.TryParse(Console.ReadLine(), out var attackerIndex))
            return;

        CardInstance? attacker = null;

        if (attackerIndex == -1)
        {
            attacker = player.PlayerBoard.LeaderZone.Leader;
        }
        else if (attackerIndex >= 0 && attackerIndex < player.PlayerBoard.CharacterZone.VisibleCards.Count)
        {
            attacker = player.PlayerBoard.CharacterZone.VisibleCards[attackerIndex];
        }


        if (attacker is null)
        {
            Console.WriteLine("Attaquant invalide.");
            return;
        }

        Console.WriteLine("Cible : L - Leader adverse, ou index d'un Character adverse Rested");
        Console.Write("> ");
        var targetChoice = Console.ReadLine();

        try
        {
            AttackAction attackAction;

            if (string.Equals(targetChoice, "L", StringComparison.OrdinalIgnoreCase))
            {
                attackAction = new AttackAction(attacker, opponent.PlayerBoard.LeaderZone.Leader, opponent.PlayerBoard.LifeZone);
            }
            else if (int.TryParse(targetChoice, out var targetIndex) &&
                     targetIndex >= 0 && targetIndex < opponent.PlayerBoard.CharacterZone.VisibleCards.Count)
            {
                var defender = opponent.PlayerBoard.CharacterZone.VisibleCards[targetIndex];
                attackAction = new AttackAction(attacker, defender, opponent.PlayerBoard.CharacterZone, opponent.PlayerBoard.DiscardZone);
            }
            else
            {
                Console.WriteLine("Cible invalide.");
                return;
            }

            game.ExecuteAction(attackAction);
            ConsoleRenderer.PrintAttackOutcome(attackAction.Outcome);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Action impossible : {ex.Message}");
        }
    }
}