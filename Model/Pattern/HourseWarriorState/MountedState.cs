using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Model.Units;

namespace Battle_Clans.Model.Pattern.HourseWarriorState
{
    public class MountedState : IHorseWarriorState
    {
        private int _horseHealth;
        private int _horseMaxHealth;
        private int _horseArmor;
        private const double RiderHitChance = 0.3;
        private static readonly Random _random = new Random();

        public MountedState()
        {
            _horseMaxHealth = UnitConfig.HorseWarrior.HorseHealth;
            _horseHealth = _horseMaxHealth;
            _horseArmor = UnitConfig.HorseWarrior.HorseArmor;
        }

        public int GetDamage() => UnitConfig.HorseWarrior.RiderDamage;
        public int GetArmor() => _horseArmor;

        public void TakeDamage(int damage, IUnit attacker, HorseWarrior context)
        {
            double chance = _random.NextDouble();

            if (chance < RiderHitChance)
            {
                context.ApplyDamageToRider(damage, attacker);
            }
            else
            {
                int finalDamage = Math.Max(0, damage - GetArmor());
                _horseHealth -= finalDamage;

                if (_horseHealth <= 0)
                {
                    context.SetState(new InfantryState());
                }
                else 
                    _horseArmor = Math.Max(0, _horseArmor - damage / 10);
            }
        }
    }
}
