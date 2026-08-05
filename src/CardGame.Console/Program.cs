using CardGame.Engine.Actions;
using CardGame.Engine.Cards;
using CardGame.Engine.Games;
using CardGame.Engine.Players;
using CardGame.Engine.Turns;

Console.WriteLine("=================");
Console.WriteLine(" CARD GAME ENGINE ");
Console.WriteLine("=================");
Console.WriteLine();

static string FormatCard(CardInstance card)
{
    return card.Definition switch
    {
        CharacterCardDefinition c => $"{c.Name} (Cost: {c.Cost} / Power: {c.Power})",
        LeaderCardDefinition l => $"{l.Name} (Power: {l.Power})",
        _ => card.Definition.Name
    };
}

static void PrintBoard(string label, PlayerBoard board, bool showHand)
{
    var leader = board.LeaderZone.Leader;
    Console.WriteLine($"--- {label} ---");
    Console.WriteLine($"Leader: {FormatCard(leader)} [{leader.CardStatus}]");
    Console.WriteLine($"Life: {board.LifeZone.Count}");

    Console.WriteLine("Characters:");
    if (board.CharacterZone.VisibleCards.Count == 0)
        Console.WriteLine("  (vide)");
    for (int i = 0; i < board.CharacterZone.VisibleCards.Count; i++)
    {
        var c = board.CharacterZone.VisibleCards[i];
        Console.WriteLine($"  {i} - {FormatCard(c)} [{c.CardStatus}]");
    }

    var activeDon = board.DonCostZone.VisibleCards.Count(d => d.CardStatus == CardStatus.Active);
    var totalDon = board.DonCostZone.VisibleCards.Count;
    Console.WriteLine($"Don: {activeDon}/{totalDon} actifs");

    if (showHand)
    {
        Console.WriteLine("Hand:");
        for (int i = 0; i < board.Hand.Count; i++)
            Console.WriteLine($"  {i} - {FormatCard(board.Hand.VisibleCards[i])}");
    }

    Console.WriteLine();
}


// Create leaders
var luffyLeader = new LeaderCardDefinition(
    id: "ST21-001",
    name: "Monkey D. Luffy",
    life: 5,
    power: 5000
);

var zoroLeader = new LeaderCardDefinition(
    id: "OP12-020",
    name: "Roronoa Zoro",
    life: 5,
    power: 5000
);
// Create character cards

var nami = new CharacterCardDefinition(
    id: "OP01-016",
    name: "Nami",
    cost: 1,
    power: 2000
);

var choper = new CharacterCardDefinition(
    id: "ST21-008",
    name: "Tony-TonyChoper",
    cost: 4,
    power: 6000
);

var koshiro = new CharacterCardDefinition(
    id: "OP12-027",
    name: "Koshiro",
    cost: 2,
    power: 1000
);

var arlong = new CharacterCardDefinition(
    id: "OP06-023",
    name: "Arlong",
    cost: 4,
    power: 6000
);

var donCard = new DonCardDefinition(
    id: "DON",
    name: "Don!!"
);

// Create player

var player1 = new Player("Luffy");
player1.PlayerBoard.LeaderZone.Add(new CardInstance(luffyLeader));
for (int i = 0; i < 25; i++)
{
    player1.PlayerBoard.Deck.Add(new CardInstance(nami));
    player1.PlayerBoard.Deck.Add(new CardInstance(choper));
}
for (int i = 0; i < 10; i++)
    player1.PlayerBoard.DonDeck.Add(new CardInstance(donCard));
player1.PlayerBoard.Deck.Shuffle();
FillLifeZone(player1.PlayerBoard);
for (int i = 0; i < 4; i++)
    player1.PlayerBoard.Hand.Add(player1.PlayerBoard.Deck.Draw());



var player2 = new Player("Zoro");
player2.PlayerBoard.LeaderZone.Add(new CardInstance(zoroLeader));
for (int i = 0; i < 25; i++)
{
    player2.PlayerBoard.Deck.Add(new CardInstance(koshiro));
    player2.PlayerBoard.Deck.Add(new CardInstance(arlong));
}
for (int i = 0; i < 10; i++)
    player2.PlayerBoard.DonDeck.Add(new CardInstance(donCard));

player2.PlayerBoard.Deck.Shuffle();
FillLifeZone(player2.PlayerBoard);
for (int i = 0; i < 4; i++)
    player2.PlayerBoard.Hand.Add(player2.PlayerBoard.Deck.Draw());

static void FillLifeZone(PlayerBoard board)
{
    var leader = (LeaderCardDefinition)board.LeaderZone.Leader.Definition;

    for (int i = 0; i < leader.Life; i++)
        board.LifeZone.Add(board.Deck.Draw());
}

// Création game
var game = new Game(
    new List<Player> { player1, player2 },
    new TurnManager()
);


game.Start();


while (game.State.Status == GameStatus.InProgress)
{
    var player = game.State.CurrentPlayer;
    var phaseName = game.TurnManager.CurrentTurn.CurrentPhase.GetType().Name;
    var opponent = game.Players.First(p => p != player);



    Console.WriteLine();
    Console.WriteLine("================");
    Console.WriteLine($"Turn {game.State.TurnNumber} - {player.Name} - {phaseName}");
    Console.WriteLine("================");


    if (game.TurnManager.CurrentTurn.CurrentPhase is not CardGame.Engine.Phases.MainPhase)
    {
        // phase automatique déjà exécutée par Turn, rien à faire ici
        continue;
    }

    PrintBoard($"{player.Name} (vous)", player.PlayerBoard, showHand: true);
    PrintBoard($"{opponent.Name} (adversaire)", opponent.PlayerBoard, showHand: false);


    Console.WriteLine();
    Console.WriteLine("1 - Jouer une carte");
    Console.WriteLine("2 - Passer");
    Console.WriteLine("3 - Attaquer");
    Console.Write("> ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Index de la carte à jouer > ");
            if (int.TryParse(Console.ReadLine(), out var index) &&
                index >= 0 && index < player.PlayerBoard.Hand.Count)
            {
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
            break;

        case "2":
            game.ExecuteAction(new PassAction());
            break;
        case "3":
            Console.Write("Index de l'attaquant (-1 pour le Leader) > ");
            if (!int.TryParse(Console.ReadLine(), out var attackerIndex))
                break;

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
                break;
            }

            Console.WriteLine("Cible : L - Leader adverse, ou index d'un Character adverse Rested");
            Console.Write("> ");
            var targetChoice = Console.ReadLine();

            try
            {
                if (string.Equals(targetChoice, "L", StringComparison.OrdinalIgnoreCase))
                {
                    game.ExecuteAction(new AttackAction(attacker, opponent.PlayerBoard.LeaderZone.Leader, opponent.PlayerBoard.LifeZone));
                }
                else if (int.TryParse(targetChoice, out var targetIndex) &&
                         targetIndex >= 0 && targetIndex < opponent.PlayerBoard.CharacterZone.VisibleCards.Count)
                {
                    var defender = opponent.PlayerBoard.CharacterZone.VisibleCards[targetIndex];
                    game.ExecuteAction(new AttackAction(
                        attacker,
                        defender,
                        opponent.PlayerBoard.CharacterZone,
                        opponent.PlayerBoard.DiscardZone));
                }
                else
                {
                    Console.WriteLine("Cible invalide.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Action impossible : {ex.Message}");
            }
            break;
    }
    if (game.State.Status == GameStatus.Finished)
        Console.WriteLine($"Partie terminée ! Vainqueur : {game.State.Winner?.Name}");
}