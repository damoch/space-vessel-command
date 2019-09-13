using Assets.Scripts.Game.Controllers.Enums;
using Assets.Scripts.Game.Controllers.Implementations;
using Assets.Scripts.UI.Abstracts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Implementations
{
    public class GameUiScreenController : MonoBehaviour, IGameUiScreenController
    {
        [SerializeField]
        private Text _gameStateText;

        [SerializeField]
        private Text _changeStateButtonText;

        [SerializeField]
        private string _gameStatePrefix;

        [SerializeField]
        private string _changeStateButtonPrefix;

        [SerializeField]
        private GameController _gameController;

        public void ChangeGameplayPhaseButtonClick()
        {
            if(_gameController.GameState.GamePlayState == GamePlayState.GamePhase)
            {
                _gameController.EnterCommandState();
            }
            else
            {
                _gameController.EnterGameState();
            }
        }

        public void OnGameplayPhaseChange(GamePlayState _gameState)
        {
            _gameStateText.text = $"{_gameStatePrefix} {_gameState}";
            _changeStateButtonText.text = $"{_changeStateButtonPrefix} {(_gameState == GamePlayState.CommandPhase ? GamePlayState.GamePhase : GamePlayState.CommandPhase)}";
        }
    }
}
