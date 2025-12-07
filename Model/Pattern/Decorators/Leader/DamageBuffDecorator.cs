using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;

namespace Battle_Clans.Model.Pattern.Decorators.Leader
{
    public class DamageBuffDecorator : UnitDecorator
    {
        private double _multiplier;

        public DamageBuffDecorator(IUnit unit, double multiplier = 1.3) : base(unit)
        {
            _multiplier = multiplier;
        }

        public override void TakeDamage(int damage, IUnit attacker)
        {
            int scaledDamage = (int)(damage * _multiplier);
            base.TakeDamage(scaledDamage, attacker);
        }
    }
}