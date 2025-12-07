using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Enums;

namespace Battle_Clans.Abstract.Classes
{
    public abstract class UnitDecorator : IUnit
    {
        protected IUnit _wrappedUnit;
        public EItemType ItemType { get; protected set; }
        public IUnit GetWrappedUnit => _wrappedUnit;

        public UnitDecorator(IUnit unit, EItemType itemType = EItemType.None)
        {
            _wrappedUnit = unit;
            ItemType = itemType;
        }

        public virtual Guid Id => _wrappedUnit.Id;
        public EUnitType Type => _wrappedUnit.Type;
        public virtual string Name => _wrappedUnit.Name;
        public virtual int Health => _wrappedUnit.Health;
        public virtual int MaxHealth => _wrappedUnit.MaxHealth;
        public virtual int Armor => _wrappedUnit.Armor;
        public virtual int Damage => _wrappedUnit.Damage;
        public virtual string Description => "";
        public virtual void Heal(int amount) => _wrappedUnit.Heal(amount);
        public virtual IBattleMediator GetMediator => _wrappedUnit.GetMediator;
        public virtual int GoldReward => _wrappedUnit.GoldReward;

        public virtual void Attack() => _wrappedUnit.Attack();
        public virtual void SetMediator(IBattleMediator mediator) => _wrappedUnit.SetMediator(mediator);
        public virtual void TakeDamage(int damage, IUnit attacker) => _wrappedUnit.TakeDamage(damage, attacker);
        public virtual ITargetingService TargetingService => _wrappedUnit.TargetingService;
        public virtual string DecoratorName => "";
        public object Clone()
        {
            var clone = (UnitDecorator)this.MemberwiseClone();
            clone._wrappedUnit = (IUnit)_wrappedUnit.Clone();
            return clone;
        }
    }
}
