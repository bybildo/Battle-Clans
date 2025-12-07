using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Model.Units;

namespace Battle_Clans.Model.Pattern.HourseWarriorState
{
    public class InfantryState : IHorseWarriorState
    {
        public int GetDamage() => UnitConfig.HorseWarrior.WarriorDamage;
        public int GetArmor() => UnitConfig.HorseWarrior.WarriorArmor;

        public void TakeDamage(int damage, IUnit attacker, HorseWarrior context)
        {
            context.ApplyDamageToRider(damage, attacker);
        }
    }
}
