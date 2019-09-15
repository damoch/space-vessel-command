using Assets.Scripts.Game.CombatEngine.Abstractions;
using Assets.Scripts.Game.CombatEngine.Enums;
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

        public TeamCode TeamCode { get => _teamCode; set => _teamCode = value; }
        public string TeamName { get => _teamName; set => _teamName = value; }
        public ITeam[] AlliedTeams { get => _alliedTeams; }
    }
}
