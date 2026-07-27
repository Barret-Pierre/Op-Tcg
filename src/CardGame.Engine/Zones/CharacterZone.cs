using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public sealed class CharacterZone : CardZone
{
    public IReadOnlyList<CardInstance> VisibleCards => Cards;
}