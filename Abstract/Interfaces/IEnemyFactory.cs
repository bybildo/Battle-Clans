namespace Battle_Clans.Abstract.Interfaces
{
    public interface IEnemyFactory
    {
        List<IUnit> CreateEnemyForLevel(int level);
    }
}
