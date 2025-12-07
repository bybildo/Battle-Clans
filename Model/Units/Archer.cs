using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Enums;
using Battle_Clans.Model.Pattern.Services;

namespace Battle_Clans.Model.Units
{
    public class Archer : Unit
    {
        public Archer() : base(EUnitType.Archer, "Archer", UnitConfig.Archer.MaxHealth, UnitConfig.Archer.Armor, UnitConfig.Archer.Damage, new BackLineTargetingService()) { }

        public override int GoldReward => UnitConfig.Archer.GoldReward;
    }
}
