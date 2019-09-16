using Assets.Scripts.Game.CombatEngine.Abstractions;
using Assets.Scripts.Game.Controllers.Abstractions;
using Assets.Scripts.Game.Controllers.Implementations;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class Unit : MonoBehaviour, IUnit, IMovableEntity
    {
        [SerializeField]
        private GameController _gameController;


        private ITeam _team;
        private MovementComponent _movementComponent;

        public IGameController GameController => _gameController;

        private void Start()
        {
            _movementComponent = GetComponent<MovementComponent>();
            if(_movementComponent != null)
            {
                _movementComponent.SetParentEntity(this);
            }
        }

        public void OnTargetReached()
        {
            
        }

        public void SetUpTeam(ITeam team)
        {
            _team = team;
        }
    }
}
