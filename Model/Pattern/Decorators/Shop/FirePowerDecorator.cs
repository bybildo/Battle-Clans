using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;

namespace Battle_Clans.Model.Pattern.Decorators.Shop
{
    public class FirePowerDecorator : UnitDecorator
    {
        private const int DamageBonus = DecoratorConfig.FirePowerDamage;

        public FirePowerDecorator(IUnit unit) : base(unit, Enums.EItemType.FirePower) { }

        public override int Damage => _wrappedUnit.Damage + DamageBonus;

        public override string DecoratorName => $"Fire Power";
    }
}
