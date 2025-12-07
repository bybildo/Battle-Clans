using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Enums;
using Battle_Clans.Model.Pattern.Factory;
using Battle_Clans.Model.Pattern.Singleton;
using Battle_Clans.Windows;    
using System.Windows;
using System.Windows.Controls;

namespace Battle_Clans
{
    public partial class MainWindow : Window
    {
        private ILeaderFactory _leaderFactory = new DefaultLeaderFactory();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLeaderSelected(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string leaderTag = clickedButton.Tag.ToString();
            
            if (Enum.TryParse(leaderTag, out ELeaderType selectedLeader))
                StartBattle(selectedLeader);
            else
                MessageBox.Show($"Помилка: Лідер типу '{leaderTag}' не знайдений в ELeaderType.");
        }

        private void StartBattle(ELeaderType leaderType)
        {
            var selectedLeader = _leaderFactory.CreateLeader(leaderType);
            GameSession.Instance.Army.Add(selectedLeader.Unit);
            GameSession.Instance.CurrentLevel = 1;
            GameSession.Instance.LeaderAbility = selectedLeader.Ability;
            MenuPanel.Visibility = Visibility.Collapsed;
            
            LoadBattlePage();
        }

        private void LoadBattlePage()
        {
            BattlePage battlePage = new BattlePage();

            battlePage.BattleEnded += OnBattleEnded;
            MainFrame.Navigate(battlePage);
        }

        private void LoadShopPage()
        {
            ShopPage shopPage = new ShopPage();
            shopPage.GoToBattle += OnShopClosed;

            MainFrame.Navigate(shopPage);
        }

        private void OnBattleEnded(bool isWin)
        {
            if (isWin)
            {
                MessageBox.Show($"Перемога! Рівень {GameSession.Instance.CurrentLevel} пройдено.");
                GameSession.Instance.Gold += 50;
                LoadShopPage();
            }
            else
            {
                MessageBox.Show("Поразка! Ваш лідер загинув.");
                MainFrame.Content = null;
                MenuPanel.Visibility = Visibility.Visible;
            }
        }

        private void OnShopClosed()
        {
            GameSession.Instance.CurrentLevel++;
            LoadBattlePage();
        }
    }
}