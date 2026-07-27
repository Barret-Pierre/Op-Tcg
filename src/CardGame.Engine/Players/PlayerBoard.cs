using CardGame.Engine.Zones;

namespace CardGame.Engine.Players;

public sealed class PlayerBoard
{
    public Deck Deck { get; } = new();

    public Hand Hand { get; } = new();

    public LifeZone LifeZone { get; } = new();

    public LeaderZone LeaderZone { get; } = new();

    public CharacterZone CharacterZone { get; } = new();

    public DiscardZone DiscardZone { get; } = new();

    public DonDeck DonDeck { get; } = new();

    public DonCostZone DonCostZone { get; } = new();
}