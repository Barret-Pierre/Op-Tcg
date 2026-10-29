using CardGame.Engine.Cards;
using CardGame.Engine.Games;
using CardGame.Engine.Players;
using CardGame.Engine.Turns;

namespace CardGame.Console;

internal static class GameSetup
{
    private const int DonDeckSize = 10;

    public static Game CreateGame()
    {
        var player1 = CreateLuffyPlayer();
        var player2 = CreateZoroPlayer();

        return new Game(new List<Player> { player1, player2 }, new TurnManager());
    }

    private static Player CreateLuffyPlayer()
    {
        var luffyLeader = new LeaderCardDefinition(id: "ST21-001", name: "Monkey D. Luffy", life: 5, power: 5000);
        var nami = new CharacterCardDefinition(id: "OP01-016", name: "Nami", cost: 1, power: 2000);
        var choper = new CharacterCardDefinition(id: "ST21-008", name: "Tony-TonyChoper", cost: 4, power: 6000);
        var donCard = new DonCardDefinition(id: "DON", name: "Don!!");

        var deckCards = Enumerable.Repeat((CardDefinition)nami, 25)
            .Concat(Enumerable.Repeat(choper, 25));
        var donDeckCards = Enumerable.Repeat(donCard, DonDeckSize);

        var player = new Player("Luffy");
        player.PlayerBoard.SetupStartingBoard(luffyLeader, deckCards, donDeckCards);

        return player;
    }

    private static Player CreateZoroPlayer()
    {
        var zoroLeader = new LeaderCardDefinition(id: "OP12-020", name: "Roronoa Zoro", life: 5, power: 5000);
        var koshiro = new CharacterCardDefinition(id: "OP12-027", name: "Koshiro", cost: 2, power: 1000);
        var arlong = new CharacterCardDefinition(id: "OP06-023", name: "Arlong", cost: 4, power: 6000);
        var donCard = new DonCardDefinition(id: "DON", name: "Don!!");

        var deckCards = Enumerable.Repeat((CardDefinition)koshiro, 25)
            .Concat(Enumerable.Repeat(arlong, 25));
        var donDeckCards = Enumerable.Repeat(donCard, DonDeckSize);

        var player = new Player("Zoro");
        player.PlayerBoard.SetupStartingBoard(zoroLeader, deckCards, donDeckCards);

        return player;
    }
}