using Battle_Clans.Abstract.Interfaces;

namespace Battle_Clans.Model.Pattern.Services
{
    public class BackLineTargetingService : ITargetingService
    {
        public List<IUnit> SelectTargets(List<IUnit> enemies)
        {
            var target = enemies.LastOrDefault();

            if (target != null)
                return new List<IUnit> { target };

            return new List<IUnit>();

        }
    }
}
