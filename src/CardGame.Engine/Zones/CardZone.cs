using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public abstract class CardZone
{
    protected readonly List<CardInstance> Cards = [];

    public int Count => Cards.Count;

    public bool IsEmpty => Count == 0;

    public event EventHandler<CardZoneChangedEventArgs>? CardAdded;

    public event EventHandler<CardZoneChangedEventArgs>? CardRemoved;

    public virtual void Add(CardInstance card)
    {
        ArgumentNullException.ThrowIfNull(card);

        Cards.Add(card);

        CardAdded?.Invoke(this, new CardZoneChangedEventArgs(card));
    }

    public virtual void Remove(CardInstance card)
    {
        ArgumentNullException.ThrowIfNull(card);

        if (!Cards.Remove(card))
            throw new InvalidOperationException("Card not found in zone.");

        CardRemoved?.Invoke(this, new CardZoneChangedEventArgs(card));
    }

    protected CardInstance RemoveTopCard()
    {
        if (Cards.Count == 0)
            throw new InvalidOperationException("Zone is empty.");

        var card = Cards[^1];

        Cards.RemoveAt(Cards.Count - 1);

        CardRemoved?.Invoke(this, new CardZoneChangedEventArgs(card));

        return card;
    }
}