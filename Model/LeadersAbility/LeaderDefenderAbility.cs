using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Model.Pattern.Decorators.Leader;

namespace Battle_Clans.Model.Leaders
{
    public class LeaderDefenderAbility : BaseLeaderAbility
    {
        public override void ApplyPassiveEffects(List<IUnit> myTeam)
        {
            for (int i = 0; i < myTeam.Count; i++)
            {
                if (base.HasDecorator<HealthAndArmorDecorator>(myTeam[i]))
                {
                    break;
                }

                myTeam[i] = new HealthAndArmorDecorator(myTeam[i], UnitConfig.Leader.DefenderAbilityMultiplier);
            }
        }
    }
}
