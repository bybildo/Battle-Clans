using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;

namespace Battle_Clans.Model.Pattern.Decorators.Leader
{
    public class LeaderMuliplierDecorator : UnitDecorator
    {
        private double _multiplier;

        public LeaderMuliplierDecorator(IUnit unit, double multiplier) : base(unit)
        {
            _multiplier = multiplier;
        }

        public override string Name => base.Name + " (Leader)";
        public override int MaxHealth => (int)(base.MaxHealth * _multiplier);
        public override int Health => (int)(base.Health * _multiplier);
        public override int Damage => (int)(base.Damage * _multiplier);
        public override int GoldReward => base.GoldReward * UnitConfig.Leader.GoldReward;
            

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
