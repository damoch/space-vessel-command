namespace Assets.Scripts.Game.CombatEngine.Abstractions
{
    public interface IUnit
    {
        void SetUpTeam(ITeam team);
        void ReceiveOrder(IOrder order);
    }
}
