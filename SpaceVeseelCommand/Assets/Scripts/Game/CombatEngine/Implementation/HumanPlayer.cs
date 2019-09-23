using Assets.Scripts.Game.CombatEngine.Abstractions;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class HumanPlayer : MonoBehaviour, IPlayer
    {
        [SerializeField]
        private Team _team;

        private void Update()
        {

        }
    }
}
