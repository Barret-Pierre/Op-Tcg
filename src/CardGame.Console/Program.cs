using CardGame.Engine.Actions;
using CardGame.Engine.Cards;
using CardGame.Engine.Games;
using CardGame.Engine.Players;
using CardGame.Engine.Turns;


Console.WriteLine("=================");
Console.WriteLine(" CARD GAME ENGINE ");
Console.WriteLine("=================");
Console.WriteLine();



// Create cards

var luffy = new CharacterCardDefinition(
    id: "1",
    name: "Luffy",
    cost: 2,
    power: 4000
);

var zoro = new CharacterCardDefinition(
    id: "2",
    name: "Zoro",
    cost: 3,
    power: 5000
);

// Create player

var player1 = new Player(
    "Luffy"
);

player1.PlayerBoard.Deck.Add(new CardInstance(luffy));


var player2 = new Player(
    "Zoro"
);

player2.PlayerBoard.Deck.Add(new CardInstance(zoro));



// Création game

var game = new Game(
    new List<Player> { player1, player2 },
    new TurnManager()
);


game.Start();


while (game.State.Status == GameStatus.InProgress)
{
    var player = game.State.CurrentPlayer;
    var opponent = game.Players.First(p => p != player);


    Console.WriteLine();
    Console.WriteLine("================");
    Console.WriteLine(
        $"Turn {game.State.TurnNumber}"
    );
    Console.WriteLine(
        $"{player.Name}'s turn"
    );

    Console.WriteLine("================");


    Console.WriteLine();

    Console.WriteLine("Hand:");

    for (int i = 0; i < player.PlayerBoard.Hand.Count; i++)
    {
        Console.WriteLine(
            $"{i} - {player.PlayerBoard.Hand.VisibleCards[i].Definition.Name}"
        );
    }


    Console.WriteLine();

    Console.WriteLine("1 - Play card");

    Console.WriteLine("2 - Attack");

    Console.WriteLine("3 - End turn");


    Console.Write("> ");


    var choice = Console.ReadLine();


    switch (choice)
    {
        case "1":
            var cardToPlay = player.PlayerBoard.Hand.VisibleCards[0];
            game.ExecuteAction(new PlayCardAction(
                player.PlayerBoard.Hand,
                player.PlayerBoard.CharacterZone,
                player.PlayerBoard.DonCostZone,
                cardToPlay));
            break;

        case "2":
            var attacker = player.PlayerBoard.CharacterZone.VisibleCards[0];
            game.ExecuteAction(new AttackAction(attacker, opponent.PlayerBoard.LifeZone));
            break;

        case "3":
            game.ExecuteAction(new PassAction());
            break;
    }
}