using Assets.Scripts.Game.CombatEngine.Enums;
using Assets.Scripts.Game.Controllers.Abstractions;

namespace Assets.Scripts.Game.CombatEngine.Abstractions
{
    public interface ITeam
    {
        TeamCode TeamCode { get; set; }
        string TeamName { get; set; }
        ITeam[] AlliedTeams { get;  }
        void OnUnitDeath(IUnit unit);
        bool UnitBelongsToTeam(IUnit unit);
        IGameController GameController { get; }
    }
}
