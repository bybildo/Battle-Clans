namespace Battle_Clans.Abstract.Interfaces
{
    public interface IBattleMediator
    {
        void Attack(IUnit attacker, ITargetingService target, int damage);
        event Action<IUnit> OnDeathEvent;
        event Action<bool> OnGameEnded;
        void OnUnitDied(IUnit unit);
        int GetOponentTeamSize(IUnit unit);
        int GetTeamSize(IUnit unit);
        List<IUnit> GetEnemiesOf(IUnit unit);
    }
}
