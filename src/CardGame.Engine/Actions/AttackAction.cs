using CardGame.Engine.Game;

namespace CardGame.Engine.Actions;

public class AttackAction : IGameAction
{
    private readonly int attackerIndex;


    public AttackAction(int attackerIndex)
    {
        this.attackerIndex = attackerIndex;
    }


    public void Execute(GameState state)
    {
        var attackerPlayer = state.CurrentPlayer;


        var attacker = attackerPlayer.Board.Cards[attackerIndex];


        var opponent = state.Players
            .First(x => x != attackerPlayer);


        opponent.TakeDamage(
            attacker.Definition.Power
        );
    }
}