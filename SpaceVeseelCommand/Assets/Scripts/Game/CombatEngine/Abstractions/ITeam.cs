using Assets.Scripts.Game.CombatEngine.Enums;

namespace Assets.Scripts.Game.CombatEngine.Abstractions
{
    public interface ITeam
    {
        TeamCode TeamCode { get; set; }
        string TeamName { get; set; }
        ITeam[] AlliedTeams { get;  }
        void OnUnitDeath(IUnit unit);
    }
}
