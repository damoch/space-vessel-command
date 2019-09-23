using Assets.Scripts.Game.CombatEngine.Abstractions;
using Assets.Scripts.Game.CombatEngine.Enums;
using Assets.Scripts.Game.Controllers.Abstractions;
using Assets.Scripts.Game.Controllers.Implementations;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game.CombatEngine.Implementation
{
    public class Team : MonoBehaviour, ITeam
    {
        [SerializeField]
        private TeamCode _teamCode;

        [SerializeField]
        private string _teamName;

        [SerializeField]
        private Team[] _alliedTeams;

        [SerializeField]
        private List<Unit> _units;

        [SerializeField]
        private GameController _gameController;

        [SerializeField]
        private Order[] _testOrder;

        public TeamCode TeamCode { get => _teamCode; set => _teamCode = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public ITeam[] AlliedTeams { get => _alliedTeams; }
        public IGameController GameController => _gameController;

        private void Start()
        {
            Initialize();
            SendOrderToUnit();
        }

        private void Initialize()
        {
            foreach (var unit in _units)
            {
                unit.SetUpTeam(this);
            }
        }

        public void OnUnitDeath(IUnit unit)
        {
            Debug.Log("unit lost");
        }

        public bool UnitBelongsToTeam(IUnit unit)
        {
           return _units.Contains((Unit)unit);
        }

        public bool ParseOrder()
        {
            return SendOrderToUnit();
        }

        private bool SendOrderToUnit()
        {
            //order test code
            _units[0].ReceiveOrder(_testOrder[1]);
            _units[0].ReceiveOrder(_testOrder[0]);
            return true;
        }
    }
}
