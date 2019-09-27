using Assets.Scripts.Game.CombatEngine.Abstractions;
using Assets.Scripts.Game.CombatEngine.Enums;
using Assets.Scripts.Game.Controllers.Abstractions;
using Assets.Scripts.Game.Controllers.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private GameObject _orderInWorldObject;

        public TeamCode TeamCode { get => _teamCode; set => _teamCode = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public ITeam[] AlliedTeams { get => _alliedTeams; }
        public IGameController GameController => _gameController;

        public GameObject OrderInWorldObject { get => _orderInWorldObject; set => _orderInWorldObject = value; }

        private void Start()
        {
            Initialize();
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

        public bool SendOrderToUnit(IOrder order, string unitName)
        {
            var unit = _units.First(x => x.CodeName == unitName);
            unit.ReceiveOrder(order);
            return true;
        }
    }
}
