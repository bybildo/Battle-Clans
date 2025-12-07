namespace Battle_Clans.Abstract.Interfaces
{
    public interface ILeaderAbility
    {
        // Викликається на початку бою
        void ApplyPassiveEffects(List<IUnit> myTeam);

        // Викликається в кінці кожного ходу
        void OnTurnEnd(List<IUnit> myTeam);

        // Повертає кількість дій за хід
        int GetActionPoints();
    }
}
