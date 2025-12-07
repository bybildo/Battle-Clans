using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Model.Pattern.Memento;

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

        public GameMemento SaveState()
        {
            return new GameMemento(Gold, CurrentLevel, Army, LeaderAbility);
        }

        public void LoadState(GameMemento memento)
        {
            if (memento == null) return;

            this.Gold = memento.Gold;
            this.CurrentLevel = memento.CurrentLevel;
            this.LeaderAbility = memento.LeaderAbility;

            this.Army = new List<IUnit>();
            foreach (var unit in memento.ArmySnapshot)
            {
                this.Army.Add((IUnit)unit.Clone());
            }
        }
    }
}
