namespace Battle_Clans.Config
{
    public static class UnitConfig
    {
        public static class Knight
        {
            public const int Price = 50;
            public const int MaxHealth = 120;
            public const int Armor = 50;
            public const int Damage = 80;
            public const int GoldReward = 20;
        }

        public static class Archer
        {
            public const int Price = 60;
            public const int MaxHealth = 100;
            public const int Armor = 35;
            public const int Damage = 65;
            public const int GoldReward = 30;
        }

        public static class Mage
        {
            public const int Price = 60;
            public const int MaxHealth = 80;
            public const int Armor = 0;
            public const int Damage = 75;
            public const int GoldReward = 35;
        }

        public static class HorseWarrior
        {
            public const int Price = 70;
            public const int RiderHealth = 100;
            public const int RiderDamage = 80;
            public const int HorseHealth = 50;
            public const int HorseArmor = 30;
            public const int WarriorDamage = 40;
            public const int WarriorArmor = 10;
            public const int GoldReward = 40;
        }

        public static class Leader
        {
            public const double Multiplier = 1.5;
            public const double WarlordAbilityMultiplier = 1.3;
            public const double DefenderAbilityMultiplier = 1.3;
            public const int MageAbilityRoundHeal = 10;
            public const int StrategAbilityActionPoint = 2;
            public const int GoldReward = 60;
        }
    }
}