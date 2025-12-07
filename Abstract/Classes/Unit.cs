using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Enums;
using System.ComponentModel;
using System.Windows;

namespace Battle_Clans.Abstract.Classes
{
    public abstract class Unit : IUnit, INotifyPropertyChanged
    {
        private Guid _id;
        protected ITargetingService _targetingService;
        private readonly EUnitType _unitType;
        protected string _name;
        protected int _health;
        protected int _maxHealth;
        protected int _armor;
        protected int _damage;
        protected IBattleMediator _battleMediator;

        public Unit(EUnitType unitType, string name, int health, int armor, int damage, ITargetingService targetingService, IBattleMediator mediator = null)
        {
            _unitType = unitType;
            _id = Guid.NewGuid();
            _name = name;
            _health = health;
            _maxHealth = health;
            _armor = armor;
            _damage = damage;
            _targetingService = targetingService;
            _battleMediator = mediator;
        }

        public Guid Id => _id;
        public EUnitType Type => _unitType;
        public string Name => _name;
        public int Health => _health;
        public int MaxHealth => _maxHealth;
        public virtual int Armor => _armor;
        public virtual int Damage => _damage;        
        public virtual IBattleMediator GetMediator => _battleMediator;

        public virtual string Description => "";
        public virtual int GoldReward => 0;
        public virtual ITargetingService TargetingService => _targetingService;

        public void SetMediator(IBattleMediator mediator)
        {
            _battleMediator = mediator;
        }

        public virtual void Attack()
        {
            if (_battleMediator == null) throw new Exception("Unit does not have a battle mediator.");
            _battleMediator.Attack(this, _targetingService, _damage);
        }

        public void Heal(int amount)
        {
            if (_health <= 0) return;

            _health = Math.Min(_health + amount, MaxHealth);
        }

        public virtual void TakeDamage(int damage, IUnit attacker)
        {
            int armorReduction = Math.Max(0, damage - Armor);

            _health -= armorReduction;

            if (_health <= 0)
            {
                _health = 0;
                if (_battleMediator == null) throw new Exception("Unit does not have a battle mediator.");
                _battleMediator.OnUnitDied(this);
            }
            else
                _armor = Math.Max(0, _armor - (damage / 10));

            OnPropertyChanged(nameof(Health));
            OnPropertyChanged(nameof(Armor));
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
