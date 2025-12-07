using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Model.Pattern.Services;

namespace Battle_Clans.Model.Pattern.Decorators.Shop
{
    public class MageAuraDecorator : UnitDecorator
    {
        private readonly ITargetingService _improvedAreaStrategy;

        public MageAuraDecorator(IUnit unit) : base(unit, Enums.EItemType.MageAura)
        {
            _improvedAreaStrategy = new AreaTargetingService(3);
        }

        public override ITargetingService TargetingService => _improvedAreaStrategy;

        public override string DecoratorName => $"Mage Aura";
    }
}
