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


// First draw

Console.WriteLine($"{player1.Name} draws a card");
player1.DrawCard();


Console.WriteLine($"{player2.Name} draws a card");
player2.DrawCard();
Console.WriteLine();


// Play card

Console.WriteLine(
    $"{player1.Name} plays {player1.Hand.Cards[0].Definition.Name}"
);

game.ExecuteAction(
    new PlayCardAction(0)
);

Console.WriteLine();

Console.WriteLine(
    $"{player1.Name} attacks!"
);


// Attack

game.ExecuteAction(
    new AttackAction(0)
);


Console.WriteLine(
    $"{player2.Name} HP : {player2.Health}"
);


// End turn

game.ExecuteAction(
    new EndTurnAction()
);