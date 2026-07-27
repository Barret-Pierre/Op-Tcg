using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public sealed class DamageTakenEventArgs : EventArgs
{
    public CardInstance Card { get; }

    public DamageTakenEventArgs(CardInstance card)
    {
        Card = card;
    }
}