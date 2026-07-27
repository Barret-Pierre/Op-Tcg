using CardGame.Engine.Actions;
using CardGame.Engine.Cards;
using CardGame.Engine.Game;
using CardGame.Engine.Players;
using CardGame.Engine.Zones;


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


// Create decks

var deck1 = new Deck();

deck1.Add(
    new CardInstance(luffy)
);


var deck2 = new Deck();

deck2.Add(
    new CardInstance(zoro)
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
    player1,
    player2
);


game.Start();


while (game.State.Status == GameStatus.Playing)
{
    var player = game.State.CurrentPlayer;


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

            game.ExecuteAction(
                new PlayCardAction(0)
            );

            break;



        case "2":

            game.TurnManager.StartCombat();

            if (player.PlayerBoard.CharacterZone.Count > 0)
            {
                game.ExecuteAction(
                    new AttackAction(0)
                );
            }

            break;



        case "3":

            game.ExecuteAction(
                new EndTurnAction()
            );

            break;
    }
}