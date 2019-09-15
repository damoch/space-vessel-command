using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Abstractions
{
    public interface IMovementComponent
    {
        Vector2 CurrentTarget { get; }
        bool SetMovementTarget(Vector2 target);
        void TragetReached();
        void SetParentEntity(IMovableEntity entity);
    }
}
