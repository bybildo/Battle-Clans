using Battle_Clans.Abstract.Classes;
using Battle_Clans.Config;

namespace Battle_Clans.Model.Leaders
{
    public class LeaderStrategAbility : BaseLeaderAbility
    {
        public override int GetActionPoints()
        {
            return UnitConfig.Leader.StrategAbilityActionPoint;
        }
    }
}
