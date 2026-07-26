namespace CardGame.Engine.Cards;

public abstract class CardDefinition
{
    public string Id { get; }

    public string Name { get; }

    protected CardDefinition(string id, string name)
    {
        Id = id;
        Name = name;
    }
}