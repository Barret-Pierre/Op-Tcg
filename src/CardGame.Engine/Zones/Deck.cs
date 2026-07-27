using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public sealed class Deck : CardZone
{
    private readonly Random _random = Random.Shared;

    public CardInstance Draw()
    {
        return RemoveTopCard();
    }

    public void Shuffle()
    {
        for (int i = Cards.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);

            (Cards[i], Cards[j]) = (Cards[j], Cards[i]);
        }
    }
}