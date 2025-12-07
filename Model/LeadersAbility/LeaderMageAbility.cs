using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;

namespace Battle_Clans.Model.Leaders
{
    public class LeaderMageAbility : BaseLeaderAbility
    {
        public override void OnTurnEnd(List<IUnit> myTeam)
        {
            foreach (var unit in myTeam)
            {
                unit.Heal(UnitConfig.Leader.MageAbilityRoundHeal);
            }
        }
    }
}
