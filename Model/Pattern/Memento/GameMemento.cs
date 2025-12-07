using Battle_Clans.Abstract.Interfaces;

namespace Battle_Clans.Model.Pattern.Memento
{
    public class GameMemento
    {
        public int Gold { get; private set; }
        public int CurrentLevel { get; private set; }
        public List<IUnit> ArmySnapshot { get; private set; }
        public ILeaderAbility LeaderAbility { get; private set; }

        public GameMemento(int gold, int level, List<IUnit> army, ILeaderAbility ability)
        {
            Gold = gold;
            CurrentLevel = level;
            LeaderAbility = ability;

            ArmySnapshot = new List<IUnit>();
            foreach (var unit in army)
            {
                ArmySnapshot.Add((IUnit)unit.Clone());
            }
        }
    }
}
