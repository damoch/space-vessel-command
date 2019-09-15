using Assets.Scripts.Game.CombatEngine.Abstractions;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class MovementComponent : MonoBehaviour, IMovementComponent
    {
        [SerializeField]
        Vector2 _currentTarget;

        [SerializeField]
        float _speed;

        [SerializeField]
        float _minimalDistance;

        private bool _targetReached;
        private IMovableEntity _movableEntity;

        public Vector2 CurrentTarget { get => _currentTarget; }

        private void Start()
        {
            _targetReached = false;
        }

        private void Update()
        {
            if(!_targetReached && _movableEntity.GameController.GameState.GamePlayState == Controllers.Enums.GamePlayState.GamePhase)
            {
                transform.Translate(_currentTarget * _speed * Time.deltaTime);


                if (Vector2.Distance(transform.position, _currentTarget) <= _minimalDistance)
                {
                    TragetReached();
                }
            }
        }

        public bool SetMovementTarget(Vector2 target)
        {
            Debug.Log("New target");
            return false;
        }

        public void TragetReached()
        {
            _targetReached = true;
            Debug.Log("Target reached");
        }

        public void SetParentEntity(IMovableEntity entity)
        {
            _movableEntity = entity;
        }
    }
}
