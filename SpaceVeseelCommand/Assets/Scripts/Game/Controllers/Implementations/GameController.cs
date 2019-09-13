using Assets.Scripts.Game.Controllers.Abstractions;
using Assets.Scripts.Game.Controllers.Enums;
using Assets.Scripts.Game.State.Abstracts;
using Assets.Scripts.Game.State.Implementations;
using Assets.Scripts.UI.Implementations;
using UnityEngine;

namespace Assets.Scripts.Game.Controllers.Implementations
{ 
    public class GameController : MonoBehaviour, IGameController
    {
        [SerializeField]
        private GameUiScreenController _gameUiScreenController; 
        public IGameState GameState { get;  set; }

        private float _normalTimeScale;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            GameState = new GameState();
            Debug.Log(GameState.GetAboutString());
            _gameUiScreenController.OnGameplayPhaseChange(GameState.GamePlayState);
        }

        public void EnterCommandState()
        {
            if(GameState.GamePlayState == GamePlayState.CommandPhase)
            {
                return;
            }
            _normalTimeScale = Time.timeScale;
            Time.timeScale = 0;
            GameState.GamePlayState = GamePlayState.CommandPhase;
            _gameUiScreenController.OnGameplayPhaseChange(GameState.GamePlayState);
        }

        public void EnterGameState()
        {
            if (GameState.GamePlayState == GamePlayState.GamePhase)
            {
                return;
            }
            Time.timeScale = _normalTimeScale;
            GameState.GamePlayState = GamePlayState.GamePhase;
            _gameUiScreenController.OnGameplayPhaseChange(GameState.GamePlayState);
        }
    }
    
}
