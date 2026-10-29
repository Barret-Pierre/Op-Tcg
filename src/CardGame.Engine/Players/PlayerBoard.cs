using CardGame.Engine.Zones;
using CardGame.Engine.Cards;

namespace CardGame.Engine.Players;

public sealed class PlayerBoard
{
    private const int StartingHandSize = 5;

    public Deck Deck { get; } = new();

    public Hand Hand { get; } = new();

    public LifeZone LifeZone { get; } = new();

    public LeaderZone LeaderZone { get; } = new();

    public CharacterZone CharacterZone { get; } = new();

    public DiscardZone DiscardZone { get; } = new();

    public DonDeck DonDeck { get; } = new();

    public DonCostZone DonCostZone { get; } = new();

    public void SetupStartingBoard(LeaderCardDefinition leader, IEnumerable<CardDefinition> deckCards, IEnumerable<DonCardDefinition> donDeckCards)
    {
        LeaderZone.Add(new CardInstance(leader));

        foreach (var cardDefinition in deckCards)
            Deck.Add(new CardInstance(cardDefinition));

        foreach (var donCard in donDeckCards)
            DonDeck.Add(new CardInstance(donCard));

        Deck.Shuffle();

        for (int i = 0; i < leader.Life; i++)
            LifeZone.Add(Deck.Draw());

        for (int i = 0; i < StartingHandSize; i++)
            Hand.Add(Deck.Draw());
    }
}