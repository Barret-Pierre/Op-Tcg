namespace CardGame.Engine.Cards;

public class CardDefinition
{
    public int Id { get; init; }

    public string Name { get; set; } = string.Empty;

    public int Cost { get; set; }

    public int Power { get; init; }
}