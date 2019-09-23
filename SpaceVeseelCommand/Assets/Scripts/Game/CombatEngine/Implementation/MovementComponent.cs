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
                transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);


                if (Vector2.Distance(transform.position, _currentTarget) <= _minimalDistance)
                {
                    TragetReached();
                }
            }
        }

        public bool SetMovementTarget(Vector2 target)
        {
            _currentTarget = target;
            _targetReached = false;
            Debug.Log("New target");
            return false;
        }

        public void TragetReached()
        {
            _targetReached = true;
            _movableEntity.OnMoveComponentTargetReached();
        }

        public void SetParentEntity(IMovableEntity entity)
        {
            _movableEntity = entity;
        }
    }
}
