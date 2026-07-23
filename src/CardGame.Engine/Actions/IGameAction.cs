using CardGame.Engine.Game;

namespace CardGame.Engine.Actions;

public interface IGameAction
{
    void Execute(GameState state);
}