using CardGame.Engine.Cards;
using CardGame.Engine.Zones;

namespace CardGame.Engine.Actions;

public sealed class AttackAction : GameAction
{
    private readonly CardInstance _attacker;
    private readonly CardInstance? _defenderCharacter;
    private readonly CharacterZone? _defenderCharacterZone;
    private readonly DiscardZone? _defenderDiscardZone;
    private readonly LifeZone? _defenderLifeZone;

    // Attaque d'un Character adverse
    public AttackAction(CardInstance attacker, CardInstance defenderCharacter, CharacterZone defenderCharacterZone, DiscardZone defenderDiscardZone)
    {
        _attacker = attacker;
        _defenderCharacter = defenderCharacter;
        _defenderCharacterZone = defenderCharacterZone;
        _defenderDiscardZone = defenderDiscardZone;
    }

    // Attaque du Leader adverse
    public AttackAction(CardInstance attacker, LifeZone defenderLifeZone)
    {
        _attacker = attacker;
        _defenderLifeZone = defenderLifeZone;
    }

    protected override bool CanExecute()
    {
        if (_attacker.CardStatus != CardStatus.Active)
            return false;

        // On ne peut attaquer un Character que s'il est Rested
        if (_defenderCharacter is not null && _defenderCharacter.CardStatus != CardStatus.Rested)
            return false;

        return true;
    }

    protected override void ExecuteCore()
    {
        _attacker.Rest();

        var attackerPower = GetPower(_attacker.Definition);

        if (_defenderCharacter is not null)
        {
            var defenderPower = GetPower(_defenderCharacter.Definition);

            if (attackerPower >= defenderPower)
            {
                _defenderCharacterZone!.Remove(_defenderCharacter);
                _defenderDiscardZone!.Add(_defenderCharacter);
            }
        }
        else
        {
            _defenderLifeZone!.TakeDamage();
        }
    }

    private static int GetPower(CardDefinition definition) => definition switch
    {
        LeaderCardDefinition leader => leader.Power,
        CharacterCardDefinition character => character.Power,
        _ => throw new InvalidOperationException("This card cannot attack or be attacked.")
    };
}