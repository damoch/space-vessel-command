using Assets.Scripts.Game.State.Abstracts;

namespace Assets.Scripts.Game.Controllers.Abstractions
{
    public interface IGameController
    {
        IGameState GameState { get; set; }
        void Initialize();
        void EnterCommandState();
        void EnterGameState();
    }
}
