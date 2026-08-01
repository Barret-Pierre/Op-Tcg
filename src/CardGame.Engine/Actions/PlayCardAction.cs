using CardGame.Engine.Cards;
using CardGame.Engine.Zones;

namespace CardGame.Engine.Actions;

public sealed class PlayCardAction : Action
{
    private readonly Hand _hand;
    private readonly CharacterZone _characterZone;
    private readonly DonCostZone _donCostZone;
    private readonly CardInstance _card;

    public PlayCardAction(Hand hand, CharacterZone characterZone, DonCostZone donCostZone, CardInstance card)
    {
        _hand = hand;
        _characterZone = characterZone;
        _donCostZone = donCostZone;
        _card = card;
    }

    protected override bool CanExecute()
    {
        if (_card.Definition is not CharacterCardDefinition character)
            return false;

        var activeDonCount = _donCostZone.VisibleCards.Count(don => don.CardStatus == CardStatus.Active);

        return activeDonCount >= character.Cost;
    }

    protected override void ExecuteCore()
    {
        var character = (CharacterCardDefinition)_card.Definition;

        var donToRest = _donCostZone.VisibleCards
            .Where(don => don.CardStatus == CardStatus.Active)
            .Take(character.Cost);

        foreach (var don in donToRest)
            don.Rest();

        _hand.Remove(_card);
        _characterZone.Add(_card);
    }
}