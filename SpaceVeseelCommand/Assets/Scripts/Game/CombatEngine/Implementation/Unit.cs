using Assets.Scripts.Game.CombatEngine.Abstractions;
using Assets.Scripts.Game.Controllers.Abstractions;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class Unit : MonoBehaviour, IUnit, IMovableEntity
    {
        private ITeam _team;
        private MovementComponent _movementComponent;

        public IGameController GameController => _team.GameController;

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
