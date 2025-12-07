using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;

namespace Battle_Clans.Model.Pattern.Decorators.Shop
{
    public class VampirismDecorator : UnitDecorator
    {
        private const double VampirismProcent = DecoratorConfig.VampirismProcent;

        public VampirismDecorator(IUnit unit) : base(unit, Enums.EItemType.Vampirism) { }

        public override void Attack()
        {
            base.Attack();
            this.Heal((int)(base.Damage * VampirismProcent));
        }

        public override string DecoratorName => $"Vampirism";

    }
}
