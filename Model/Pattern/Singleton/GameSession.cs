using Battle_Clans.Abstract.Interfaces;

namespace Battle_Clans.Model.Pattern.Singleton
{
    public class GameSession
    {
        private static GameSession _instance;
        public List<IUnit> Army { get; set; }
        public ILeaderAbility LeaderAbility { get; set; }
        public int Gold { get; set; }
        public int CurrentLevel { get; set; }

        public static GameSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameSession();
                }
                return _instance;
            }
        }

        private GameSession()
        {
            Gold = 0;
            CurrentLevel = 1;
            Army = new List<IUnit>();
        }

        public void AddGold(int amount)
        {
            Gold += amount;
        }
    }
}
