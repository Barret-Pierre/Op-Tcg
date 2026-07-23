namespace CardGame.Engine.Zones;

using CardGame.Engine.Cards;

public class Deck : Zone
{

    public CardInstance Draw()
    {
        if (cards.Count == 0)
            throw new InvalidOperationException("Deck is empty");

        var card = cards[0];

        cards.RemoveAt(0);

        return card;
    }

    public void Shuffle()
    {
        var random = new Random();

        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);

            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }
}
