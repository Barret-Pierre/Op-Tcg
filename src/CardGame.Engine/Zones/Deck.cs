namespace CardGame.Engine.Zones;

using CardGame.Engine.Cards;

public class Deck
{
    private readonly List<CardInstance> cards = new();

    public int Count => cards.Count;


    public void Add(CardInstance card)
    {
        cards.Add(card);
    }


    public CardInstance Draw()
    {
        if(cards.Count == 0)
        {
            throw new InvalidOperationException("Deck is empty");
        }

        var card = cards[0];

        cards.RemoveAt(0);

        return card;
    }
}