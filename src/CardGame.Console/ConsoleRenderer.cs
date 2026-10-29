using CardGame.Engine.Actions;
using CardGame.Engine.Cards;
using CardGame.Engine.Games;
using CardGame.Engine.Players;

namespace CardGame.Console;

internal static class ConsoleRenderer
{
    public static string FormatCard(CardInstance card) => card.Definition switch
    {
        CharacterCardDefinition c => $"{c.Name} (Cost: {c.Cost} / Power: {c.Power})",
        LeaderCardDefinition l => $"{l.Name} (Power: {l.Power})",
        _ => card.Definition.Name
    };

    public static void PrintTurnHeader(int turnNumber, string playerName, string phaseName)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("================");
        System.Console.WriteLine($"Turn {turnNumber} - {playerName} - {phaseName}");
        System.Console.WriteLine("================");
    }

    public static void PrintBoard(string label, PlayerBoard board, bool showHand)
    {
        var leader = board.LeaderZone.Leader;
        System.Console.WriteLine($"--- {label} ---");
        System.Console.WriteLine($"Leader: {FormatCard(leader)} [{leader.CardStatus}]");
        System.Console.WriteLine($"Life: {board.LifeZone.Count}");

        System.Console.WriteLine("Characters:");
        if (board.CharacterZone.VisibleCards.Count == 0)
            System.Console.WriteLine("  (vide)");
        for (int i = 0; i < board.CharacterZone.VisibleCards.Count; i++)
        {
            var c = board.CharacterZone.VisibleCards[i];
            System.Console.WriteLine($"  {i} - {FormatCard(c)} [{c.CardStatus}]");
        }

        var activeDon = board.DonCostZone.VisibleCards.Count(d => d.CardStatus == CardStatus.Active);
        var totalDon = board.DonCostZone.VisibleCards.Count;
        System.Console.WriteLine($"Don: {activeDon}/{totalDon} actifs");

        if (showHand)
        {
            System.Console.WriteLine("Hand:");
            for (int i = 0; i < board.Hand.Count; i++)
                System.Console.WriteLine($"  {i} - {FormatCard(board.Hand.VisibleCards[i])}");
        }

        System.Console.WriteLine();
    }

    public static void PrintAttackOutcome(AttackOutcome outcome) => System.Console.WriteLine(outcome switch
    {
        AttackOutcome.CharacterDefeated => ">> K.O. ! Le défenseur part au discard.",
        AttackOutcome.CharacterSurvived => ">> Le défenseur résiste, rien ne se passe.",
        AttackOutcome.LifeLost => ">> Touché ! Une carte Vie est retirée.",
        AttackOutcome.LeaderResisted => ">> Le Leader résiste, aucune vie perdue.",
        _ => ">> Résultat inconnu."
    });

    public static void PrintGameEnd(GameState state) =>
        System.Console.WriteLine($"Partie terminée ! Vainqueur : {state.Winner?.Name}");
}