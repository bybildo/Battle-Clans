using Battle_Clans.Enums;

namespace Battle_Clans.Abstract.Interfaces
{
    public interface IUnit
    {
        Guid Id { get; }
        EUnitType Type { get; }
        string Name { get; }
        int Health { get; }
        int MaxHealth { get; }
        int Armor { get; }
        int Damage { get; }
        string Description { get; }
        int GoldReward { get; }
        IBattleMediator GetMediator { get; }
        ITargetingService TargetingService { get; }

        void Heal(int amount);
        void Attack();
        void TakeDamage(int damage, IUnit attacker);
        void SetMediator(IBattleMediator mediator);
        object Clone();
    }
}
