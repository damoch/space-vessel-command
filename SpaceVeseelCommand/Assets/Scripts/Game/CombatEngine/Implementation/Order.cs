using Assets.Scripts.Game.CombatEngine.Abstractions;
using Assets.Scripts.Game.CombatEngine.Enums;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class Order : MonoBehaviour, IOrder
    {
        [SerializeField]
        private OrderType _orderType;

        [SerializeField]
        private Vector2 _target;

        public OrderType OrderType { get => _orderType; set => _orderType = value; }
        public Vector2 Target { get => _target; set => _target = value; }
    }
}
