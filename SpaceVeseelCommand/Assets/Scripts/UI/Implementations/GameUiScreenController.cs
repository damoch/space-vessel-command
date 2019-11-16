using Assets.Scripts.Game.CombatEngine.Implementation;
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

        [SerializeField]
        private HumanPlayer _humanPlayer;

        [SerializeField]
        private InputField _commandInputField;

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

        public void OnCommandFieldEnterPressed()
        {
            _humanPlayer.DecodeAndSendOrderToTeam(_commandInputField.text);
        }

        public void OnGameplayPhaseChange(GamePlayState gameState)
        {
            switch (gameState)
            {
                case GamePlayState.CommandPhase:
                    _gameStateText.text = $"{_gameStatePrefix} Command";
                    _changeStateButtonText.text = $"{_changeStateButtonPrefix} Action";
                    _commandInputField.text = string.Empty;
                    _commandInputField.gameObject.SetActive(true);
                    break;
                case GamePlayState.GamePhase:
                    _gameStateText.text = $"{_gameStatePrefix} Action";
                    _changeStateButtonText.text = $"{_changeStateButtonPrefix} Command";
                    _commandInputField.text = string.Empty;
                    _commandInputField.gameObject.SetActive(false);
                    break;
            }

            //_changeStateButtonText.text = $"{_changeStateButtonPrefix} {(gameState == GamePlayState.CommandPhase ? GamePlayState.GamePhase : GamePlayState.CommandPhase)}";
        }

    }
}
