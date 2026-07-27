using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public sealed class CardZoneChangedEventArgs : EventArgs
{
    public CardInstance Card { get; }

    public CardZoneChangedEventArgs(CardInstance card)
    {
        Card = card;
    }
}