using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public sealed class DonCostZone : CardZone
{
    public IReadOnlyList<CardInstance> VisibleCards => Cards;
}