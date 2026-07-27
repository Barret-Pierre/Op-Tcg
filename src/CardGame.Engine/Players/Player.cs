using CardGame.Engine.Cards;
using CardGame.Engine.Zones;

namespace CardGame.Engine.Players;

public class Player
{
    public Guid Id { get; } = Guid.NewGuid();

    public string Name { get; }

    public PlayerBoard PlayerBoard { get; }

    public Player(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
        PlayerBoard = new PlayerBoard();
    }

}