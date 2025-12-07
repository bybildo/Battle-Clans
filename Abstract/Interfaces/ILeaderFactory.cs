using Battle_Clans.Enums;

namespace Battle_Clans.Abstract.Interfaces
{
    public interface ILeaderFactory
    {
        (IUnit Unit, ILeaderAbility Ability) CreateLeader(ELeaderType leaderType);
    }
}