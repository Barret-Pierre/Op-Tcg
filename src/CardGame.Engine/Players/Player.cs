using CardGame.Engine.Cards;
using CardGame.Engine.Zones;

namespace CardGame.Engine.Players;

public class Player
{
    public string Name { get; }

    public int Health { get; private set; } = 20;

    public Deck Deck { get; }

    public Hand Hand { get; } = new();

    public Board Board { get; } = new();

    public DiscardPile DiscardPile { get; } = new();

    public Player(string name, Deck deck)
    {
        Name = name;
        Deck = deck;
    }


    public void DrawCard()
    {
        Hand.Add(Deck.Draw());
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
    }

}