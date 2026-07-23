using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public abstract class Zone
{
    protected readonly List<CardInstance> cards = new();

    public IReadOnlyList<CardInstance> Cards => cards;

    public int Count => cards.Count;

    public virtual void Add(CardInstance card)
    {
        cards.Add(card);
    }

    public virtual void Remove(CardInstance card)
    {
        cards.Remove(card);
    }
}