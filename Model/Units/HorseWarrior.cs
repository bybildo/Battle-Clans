using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Enums;
using Battle_Clans.Model.Pattern.HourseWarriorState;
using Battle_Clans.Model.Pattern.Services;


namespace Battle_Clans.Model.Units
{
    public class HorseWarrior : Unit
    {
        private IHorseWarriorState _state;
        private int _armor;

        public HorseWarrior() : base(EUnitType.HorseWarrior ,"Horse Warrior", UnitConfig.HorseWarrior.RiderHealth, 0, 0, new FrontLineTargetingService())
        {
            _armor = UnitConfig.HorseWarrior.WarriorArmor;
            _state = new MountedState();
        }

        public void SetState(IHorseWarriorState newState)
        {
            _state = newState;
        }

        public override int GoldReward => UnitConfig.HorseWarrior.GoldReward;
        public override int Damage => _state.GetDamage();
        public override int Armor => _state.GetArmor();

        public override void Attack()
        {
            if (base._battleMediator == null) throw new Exception("Unit does not have a battle mediator.");
            base._battleMediator.Attack(this, base.TargetingService, Damage);
        }

        public override void TakeDamage(int damage, IUnit attacker)
        {
            _state.TakeDamage(damage, attacker, this);
        }

        public void ApplyDamageToRider(int damage, IUnit attacker)
        {
            int finalDamage = Math.Max(0, damage - _armor);
            base._health -= finalDamage;

            if (base._health <= 0)
            {
                base._health = 0;
                _battleMediator?.OnUnitDied(this);
            }
            else
                _armor = Math.Max(0, _armor - (damage / 10));
        }
    }
}
