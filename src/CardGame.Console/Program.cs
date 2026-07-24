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

var luffy = new CardDefinition
{
    Id = 1,
    Name = "Luffy",
    Cost = 5,
    Power = 7000
};


var zoro = new CardDefinition
{
    Id = 2,
    Name = "Zoro",
    Cost = 3,
    Power = 5000
};



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
    "Luffy",
    deck1
);


var player2 = new Player(
    "Zoro",
    deck2
);



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

    for (int i = 0; i < player.Hand.Count; i++)
    {
        Console.WriteLine(
            $"{i} - {player.Hand.Cards[i].Definition.Name}"
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

            if (player.Board.Count > 0)
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