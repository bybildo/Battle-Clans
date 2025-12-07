using Battle_Clans.Model.Units;

namespace Battle_Clans.Abstract.Interfaces
{
    public interface IHorseWarriorState
    {
        int GetDamage();
        int GetArmor();

        void TakeDamage(int damage, IUnit attacker, HorseWarrior context);
    }
}
