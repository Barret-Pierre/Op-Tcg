namespace CardGame.Engine.Cards;

public sealed class LeaderCardDefinition : CardDefinition
{
    public int Life { get; }

    public int Power { get; }

    public LeaderCardDefinition(string id,
        string name,
        int life,
        int power)
        : base(id, name)
    {
        Life = life;
        Power = power;
    }
}