using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public sealed class DonDeck : CardZone
{
    public CardInstance Draw()
    {
        return RemoveTopCard();
    }
}