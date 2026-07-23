namespace CardGame.Engine.Cards;
public class CardInstance
{
    public Guid InstanceId { get; } = Guid.NewGuid();

    public CardDefinition Definition { get; }

    public bool IsPlayed { get; private set; }

    public CardInstance(CardDefinition definition)
    {
        Definition = definition;
    }

    public void Play()
    {
        IsPlayed = true;
    }
}