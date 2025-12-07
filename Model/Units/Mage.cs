using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Enums;
using Battle_Clans.Model.Pattern.Services;

namespace Battle_Clans.Model.Units
{
    class Mage : Unit
    {
        public Mage() : base(EUnitType.Mage, "Mage", UnitConfig.Mage.MaxHealth, UnitConfig.Mage.Armor, UnitConfig.Mage.Damage, new AreaTargetingService()) { }

        public override int GoldReward => UnitConfig.Mage.GoldReward;
    }
}
