using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Model.Pattern.Decorators.Shop;
using Battle_Clans.Model.Units;

namespace Battle_Clans.Model.Pattern.Factory
{
    public class NormalEnemyFactory : IEnemyFactory
    {
        ILeaderFactory _leaderFactory = new DefaultLeaderFactory();

        public List<IUnit> CreateEnemyForLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return new List<IUnit>
                        {
                            new Knight()
                        };
                case 2:
                    return new List<IUnit>
                        {
                           new Knight(),
                           new Archer()
                        };
                case 3:
                    return new List<IUnit>
                        {
                            new FirePowerDecorator(new Knight()),
                            new Archer()
                        };
                default:
                    {
                        var leader = _leaderFactory.CreateLeader(Enums.ELeaderType.Strateg);
                        return new List<IUnit>
                        {
                            new FirePowerDecorator(new Knight()),
                            new Mage(),
                            leader.Unit
                        };
                    }
            }
        }
    }
}

