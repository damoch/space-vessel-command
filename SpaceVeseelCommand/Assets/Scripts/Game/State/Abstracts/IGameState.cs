using Assets.Scripts.Game.Controllers.Enums;

namespace Assets.Scripts.Game.State.Abstracts
{
    public interface IGameState
    {
        string GetAboutString();
        GamePlayState GamePlayState { get; set; } 
    }
}
