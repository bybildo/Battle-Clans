using Battle_Clans.Abstract.Interfaces;

namespace Battle_Clans.Abstract.Classes
{
    public abstract class BaseLeaderAbility : ILeaderAbility
    {
        public virtual void ApplyPassiveEffects(List<IUnit> myTeam) { }
        public virtual void OnTurnEnd(List<IUnit> myTeam) { }
        public virtual int GetActionPoints() => 1;

        protected bool HasDecorator<T>(IUnit unit) where T : class
        {
            if (unit is T) return true;

            if (unit is UnitDecorator decorator)
            {
                return HasDecorator<T>(decorator.GetWrappedUnit);
            }

            return false;
        }
    }
}
