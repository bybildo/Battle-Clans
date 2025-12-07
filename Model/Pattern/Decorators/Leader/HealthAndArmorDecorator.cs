using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;

namespace Battle_Clans.Model.Pattern.Decorators.Leader
{
    public class HealthAndArmorDecorator : UnitDecorator
    {
        private double _multiplier;

        public HealthAndArmorDecorator(IUnit unit, double multiplier = 1.3) : base(unit)
        {
            _multiplier = multiplier;
        }

        public override string Name => base.Name + " (Leader)";
        public override int MaxHealth => (int)(base.MaxHealth * _multiplier);
        public override int Health => (int)(base.Health * _multiplier);

        public override void TakeDamage(int damage, IUnit attacker)
        {
            int scaledDamage = (int)(damage / _multiplier);

            if (damage > 0 && scaledDamage == 0)
            {
                scaledDamage = 1;
            }

            base.TakeDamage(scaledDamage, attacker);
        }
    }
}
