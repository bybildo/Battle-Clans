using Battle_Clans.Abstract.Classes;
using Battle_Clans.Abstract.Interfaces;
using System.Windows;

namespace Battle_Clans.Model.Pattern.Mediator
{
    public class BattleManager : IBattleMediator
    {
        private List<IUnit> _teamA;
        private List<IUnit> _teamB;

        public event Action<IUnit> OnDeathEvent;
        public event Action<bool> OnGameEnded;

        public BattleManager(List<IUnit> teamA, List<IUnit> teamB)
        {
            _teamA = teamA;
            _teamB = teamB;

            teamA.ForEach(unit => unit.SetMediator(this));
            teamB.ForEach(unit => unit.SetMediator(this));
        }

        public BattleManager()
        {
            _teamA = new();
            _teamB = new();
        }

        public void RegisterTeams(List<IUnit> teamA, List<IUnit> teamB)
        {
            _teamA = teamA;
            _teamB = teamB;

            teamA.ForEach(unit => unit.SetMediator(this));
            teamB.ForEach(unit => unit.SetMediator(this));
        }

        public void Attack(IUnit attacker, ITargetingService target, int damage)
        {
            var unitTarget = target.SelectTargets(GetEnemiesOf(attacker));
            foreach (var t in unitTarget)
            {
                t.TakeDamage(damage, attacker);
            }
        }

        public void OnUnitDied(IUnit unit)
        {
            var unitInTeamA = _teamA.FirstOrDefault(u => u.Id == unit.Id);
            if (unitInTeamA != null)
            {
                _teamA.Remove(unitInTeamA);
                OnDeathEvent?.Invoke(unit);

                if (_teamA.Count == 0) OnGameEnded?.Invoke(false);
            }

            var unitInTeamB = _teamB.FirstOrDefault(u => u.Id == unit.Id);
            if (unitInTeamB != null)
            {
                _teamB.Remove(unitInTeamB);
                OnDeathEvent?.Invoke(unit);

                if (_teamB.Count == 0) OnGameEnded?.Invoke(true);
            }
        }

        public int GetOponentTeamSize(IUnit unit)
        {
            if (_teamA.Any(u => u.Id == unit.Id)) return _teamB.Count;
            else if (_teamB.Any(u => u.Id == unit.Id)) return _teamA.Count;

            throw new Exception("Unit does not belong to any registered team.");
        }

        public int GetTeamSize(IUnit unit)
        {
            if (_teamA.Any(u => u.Id == unit.Id)) return _teamA.Count;
            else if (_teamB.Any(u => u.Id == unit.Id)) return _teamB.Count;

            throw new Exception("Unit does not belong to any registered team.");
        }

        public List<IUnit> GetEnemiesOf(IUnit unit)
        {
            if (_teamA.Any(u => u.Id == unit.Id)) return _teamB;
            if (_teamB.Any(u => u.Id == unit.Id)) return _teamA;
            return new List<IUnit>();
        }
    }
}
