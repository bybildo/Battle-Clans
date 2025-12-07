using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;

namespace Battle_Clans.Model.Pattern.Decorators.Shop
{
    public class HeavyShieldDecorator : UnitDecorator
    {   
        const int ArmorBonus = DecoratorConfig.HeavyShieldArmor;

        public override int Armor => _wrappedUnit.Armor + ArmorBonus;

        public HeavyShieldDecorator(IUnit unit) : base(unit, Enums.EItemType.HeavyShield) { }

        public override void TakeDamage(int damage, IUnit attacker)
        {
            int reducedDamage = Math.Max(0, damage - ArmorBonus);

            base.TakeDamage(reducedDamage, attacker);
        }

        public override string DecoratorName => $"Heavy Shield";
    }
}
