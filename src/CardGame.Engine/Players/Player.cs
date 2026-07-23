using CardGame.Engine.Cards;
using CardGame.Engine.Zones;

namespace CardGame.Engine.Players;

public class Player
{
    public string Name { get; }

    public Deck Deck { get; }

    public List<CardInstance> Hand { get; } = new();


    public Player(string name, Deck deck)
    {
        Name = name;
        Deck = deck;
    }


    public void DrawCard()
    {
        var card = Deck.Draw();

        Hand.Add(card);
    }
}