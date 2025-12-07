using Battle_Clans.Enums;

namespace Battle_Clans.Config
{
    public static class DecoratorConfig
    {
        public const int FirePowerDamage = 30;
        public const int HeavyShieldArmor = 30;
        public const double VampirismProcent = 1.2;

        public static readonly Dictionary<EItemType, DecoratorInfo> GetInfo = new()
        {
            { EItemType.FirePower, new DecoratorInfo { Price = 50, AllowedTypes = new List<EUnitType> { EUnitType.Archer, EUnitType.Mage, EUnitType.HorseWarrior, EUnitType.Knight} } },
            { EItemType.HeavyShield, new DecoratorInfo { Price = 40, AllowedTypes = new List<EUnitType> { EUnitType.Knight, EUnitType.HorseWarrior } } },
            { EItemType.MageAura, new DecoratorInfo { Price = 70, AllowedTypes = new List<EUnitType> { EUnitType.Mage } } },
            { EItemType.Vampirism, new DecoratorInfo { Price = 60, AllowedTypes = new List<EUnitType> { EUnitType.Knight, EUnitType.Archer } } }
        };
    }
    
    public class DecoratorInfo
    {
        public int Price { get; set; }
        public List<EUnitType> AllowedTypes { get; set; }
    }
}
