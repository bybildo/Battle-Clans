using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Model.Pattern.Factory;
using Battle_Clans.Model.Pattern.Mediator;
using Battle_Clans.Model.Pattern.Singleton;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace Battle_Clans.Windows
{
    public partial class BattlePage : Page
    {
        private IEnemyFactory _enemyFactory = new NormalEnemyFactory();
        private BattleManager _battleManager;
        public event Action<bool> BattleEnded;

        public List<IUnit> PlayerTeam { get; set; }
        public List<IUnit> EnemyTeam { get; set; }

        public BattlePage()
        {
            InitializeComponent();

            PlayerTeam = GameSession.Instance.Army;
            EnemyTeam = _enemyFactory.CreateEnemyForLevel(GameSession.Instance.CurrentLevel);

            _battleManager = new BattleManager(PlayerTeam, EnemyTeam);
            SubscribeToMediator(_battleManager);

            OnStartRound();
            this.DataContext = this;
            CollectionViewSource.GetDefaultView(PlayerTeam).Refresh();
            CollectionViewSource.GetDefaultView(EnemyTeam).Refresh();
        }

        private bool _isBusy = false;
        private async void OnPlayerUnitClick(object sender, RoutedEventArgs e)
        {
            if (_isBusy) return;

            _isBusy = true;
            Button btn = sender as Button;

            IUnit selectedUnit = btn.Tag as IUnit;

            selectedUnit.Attack();

            try
            {
                await EnemyTurn();
            }
            catch (Exception ex) { }
            await Task.Delay(100);
            OnEndStep();
            _isBusy = false;
        }

        private void OnEnemyUnitClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            IUnit targetEnemy = btn.Tag as IUnit;

            if (targetEnemy != null)
            {
                MessageBox.Show($"Ви обрали ціль: {targetEnemy.Name}");
            }
        }

        private void SubscribeToMediator(IBattleMediator mediator)
        {
            mediator.OnDeathEvent += OnUnitDied;
            mediator.OnGameEnded += (result) => BattleEnded?.Invoke(result);
        }

        private void OnUnitDied(IUnit deadUnit)
        {
            CollectionViewSource.GetDefaultView(PlayerTeam).Refresh();
            CollectionViewSource.GetDefaultView(EnemyTeam).Refresh();

            GameSession.Instance.Gold += deadUnit.GoldReward;
        }

        private void OnStartRound()
        {
            if (GameSession.Instance.LeaderAbility != null)
            {
                GameSession.Instance.LeaderAbility.ApplyPassiveEffects(PlayerTeam);
                CollectionViewSource.GetDefaultView(PlayerTeam).Refresh();
            }
        }

        private void OnEndStep()
        {
            if (GameSession.Instance.LeaderAbility != null)
            {
                GameSession.Instance.LeaderAbility.OnTurnEnd(PlayerTeam);
                CollectionViewSource.GetDefaultView(PlayerTeam).Refresh();
            }
        }

        private async Task EnemyTurn()
        {
            await Task.Delay(500);

            Random rnd = new Random();
            int randomIndex = rnd.Next(0, PlayerTeam.Count - 1);
            IUnit randomEnemy = EnemyTeam[randomIndex];
            randomEnemy.Attack();
        }
    }
}
