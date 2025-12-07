using Battle_Clans.Abstract.Interfaces;

namespace Battle_Clans.Model.Pattern.Services
{
    public class AreaTargetingService : ITargetingService
    {
        private readonly int _targetsCount;

        public AreaTargetingService(int count = 2)
        {
            _targetsCount = count;
        }

        public List<IUnit> SelectTargets(List<IUnit> enemies)
        {
            return enemies.Take(2).ToList();
        }
    }
}
