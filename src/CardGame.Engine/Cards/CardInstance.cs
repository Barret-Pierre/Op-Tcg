namespace CardGame.Engine.Cards;

public class CardInstance
{
    public Guid Id { get; } = Guid.NewGuid();

    public CardDefinition Definition { get; }

    public CardStatus CardStatus { get; private set; } = CardStatus.Active;

    public CardInstance(CardDefinition definition)
    {
        Definition = definition;
    }

    public void Rest()
    {
        CardStatus = CardStatus.Rested;
    }

    public void Activate()
    {
        CardStatus = CardStatus.Active;
    }
}