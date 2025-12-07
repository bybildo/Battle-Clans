namespace Battle_Clans.Abstract.Interfaces
{
    public interface ITargetingService
    {
        List<IUnit> SelectTargets(List<IUnit> enemies);
    }
}
