using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Enums;
using Battle_Clans.Model.Leaders;
using Battle_Clans.Model.Pattern.Decorators.Leader;
using Battle_Clans.Model.Units;

namespace Battle_Clans.Model.Pattern.Factory
{
    public class DefaultLeaderFactory : ILeaderFactory
    {
        public (IUnit Unit, ILeaderAbility Ability) CreateLeader(ELeaderType type)
        {
            IUnit leaderUnit = null;
            ILeaderAbility leaderAbility = null;

            switch (type)
            {
                case ELeaderType.Warlord: 
                    leaderUnit = new HorseWarrior();
                    leaderAbility = new LeaderWarlordAbility();
                    break;

                case ELeaderType.Defender:
                    leaderUnit = new Knight();
                    leaderAbility = new LeaderDefenderAbility();
                    break;

                case ELeaderType.Mage:
                    leaderUnit = new Mage();
                    leaderAbility = new LeaderMageAbility();
                    break;

                case ELeaderType.Strateg:
                    leaderUnit = new Archer();
                    leaderAbility = new LeaderStrategAbility();
                    break;

                default:
                    throw new Exception("Leader type not found");
            }

            leaderUnit = new LeaderMuliplierDecorator(leaderUnit, UnitConfig.Leader.Multiplier);

            return (leaderUnit, leaderAbility);
        }
    }
}
