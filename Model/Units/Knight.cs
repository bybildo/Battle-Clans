using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Enums;
using Battle_Clans.Model.Pattern.Services;

namespace Battle_Clans.Model.Units
{
    public class Knight : Unit
    {
        public Knight() : base(EUnitType.Knight, "Knight", UnitConfig.Knight.MaxHealth, UnitConfig.Knight.Armor, UnitConfig.Knight.Damage, new FrontLineTargetingService()) { }

        public override int GoldReward => UnitConfig.Knight.GoldReward;
    }
}
