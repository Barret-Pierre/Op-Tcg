namespace CardGame.Engine.Cards;

public sealed class CharacterCardDefinition : CardDefinition
{
    public int Cost { get; }

    public int Power { get; }

    public CharacterCardDefinition(string id,
        string name,
        int cost,
        int power)
        : base(id, name)
    {
        Cost = cost;
        Power = power;
    }
}