using Assets.Scripts.Game.CombatEngine.Enums;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Abstractions
{
    public interface IOrder
    {
        OrderType OrderType { get; set; }
        Vector2 Target { get; set; }
    }
}
