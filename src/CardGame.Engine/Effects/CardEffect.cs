namespace CardGame.Engine.Effects;

using CardGame.Engine.Enums;

public class CardEffect
{
    public TriggerType Trigger { get; set; }

    public EffectType Type { get; set; }

    public int Value { get; set; }
}