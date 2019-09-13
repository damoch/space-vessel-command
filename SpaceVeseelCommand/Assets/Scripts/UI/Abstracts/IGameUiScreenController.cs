using Assets.Scripts.Game.Controllers.Enums;

namespace Assets.Scripts.UI.Abstracts
{
    interface IGameUiScreenController
    {
        void OnGameplayPhaseChange(GamePlayState _gameState);
        void ChangeGameplayPhaseButtonClick();
    }
}
