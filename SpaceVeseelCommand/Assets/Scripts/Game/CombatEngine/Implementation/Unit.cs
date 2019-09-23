using Assets.Scripts.Game.CombatEngine.Abstractions;
using Assets.Scripts.Game.CombatEngine.Enums;
using Assets.Scripts.Game.Controllers.Abstractions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class Unit : MonoBehaviour, IUnit, IMovableEntity
    {
        private ITeam _team;
        private MovementComponent _movementComponent;
        private Stack<IOrder> _ordersStack;
        private IOrder _currentOrder;

        public IGameController GameController => _team.GameController;

        private void Awake()
        {
            if (_ordersStack == null)
            {
                _ordersStack = new Stack<IOrder>();
            }
            _movementComponent = GetComponent<MovementComponent>();

            if(_movementComponent != null)
            {
                _movementComponent.SetParentEntity(this);
            }
        }

        public void OnMoveComponentTargetReached()
        {
            if(_currentOrder.OrderType == OrderType.MoveToLocation)
            {
                Destroy(((Order)_currentOrder).gameObject);
                _currentOrder = null;
                if(_ordersStack.Count > 0)
                {
                    ReceiveOrder(_ordersStack.Pop());
                }
            }
        }

        public void SetUpTeam(ITeam team)
        {
            _team = team;
        }

        public void ReceiveOrder(IOrder order)
        {
            if(_currentOrder == null && _ordersStack.Count == 0)
            {
                _currentOrder = order;
                StartOrderExecution();
            }
            else
            {
                _ordersStack.Push(order);
            }
        }

        private void StartOrderExecution()
        {
            switch (_currentOrder.OrderType)
            {
                case OrderType.MoveToLocation:
                    _movementComponent.SetMovementTarget(_currentOrder.Target);
                    break;
            }
        }
    }
}
