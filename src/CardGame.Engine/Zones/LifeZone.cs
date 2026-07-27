using CardGame.Engine.Cards;

namespace CardGame.Engine.Zones;

public sealed class LifeZone : CardZone
{
    public event EventHandler<DamageTakenEventArgs>? DamageTaken;

    public CardInstance TakeDamage()
    {
        var card = RemoveTopCard();
        DamageTaken?.Invoke(this, new DamageTakenEventArgs(card));
        return card;
    }
}