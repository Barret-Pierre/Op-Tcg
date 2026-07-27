using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public sealed class LeaderZone : CardZone
{
    public CardInstance Leader => Cards.Single();

    public override void Add(CardInstance card)
    {
        if (!IsEmpty)
            throw new InvalidOperationException("Leader zone can only contain one card.");

        base.Add(card);
    }
}