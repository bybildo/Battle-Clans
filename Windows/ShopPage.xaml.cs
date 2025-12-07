using Battle_Clans.Abstract.Interfaces;
using Battle_Clans.Config;
using Battle_Clans.Enums;
using Battle_Clans.Model.Pattern.Decorators.Shop;
using Battle_Clans.Model.Pattern.Singleton;
using Battle_Clans.Model.Units;
using System.Windows;
using System.Windows.Controls;

namespace Battle_Clans.Windows
{
    public partial class ShopPage : Page
    {
        public event Action GoToBattle;

        private EItemType? _pendingItemType = null;

        public ShopPage()
        {
            InitializeComponent();
            ArmyListBox.ItemsSource = GameSession.Instance.Army;
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            GoldText.Text = $"Золото: {GameSession.Instance.Gold}";
        }

        private void OnBuyUnitClick(object sender, RoutedEventArgs e)
        {
            if (GameSession.Instance.Army.Count >= 5)
            {
                MessageBox.Show("Армія переповнена! Максимум 5 воїнів.");
                return;
            }

            Button btn = sender as Button;
            string unitTag = btn.Tag.ToString();

            IUnit newUnit = null;
            int price = 0;

            switch (unitTag)
            {
                case "Knight": newUnit = new Knight(); price = UnitConfig.Knight.Price; break;
                case "Archer": newUnit = new Archer(); price = UnitConfig.Archer.Price; break;
                case "Mage": newUnit = new Mage(); price = UnitConfig.Mage.Price; break;
                case "HorseWarrior": newUnit = new HorseWarrior(); price = UnitConfig.HorseWarrior.Price; break;
            }

            if (GameSession.Instance.Gold >= price)
            {
                GameSession.Instance.Gold -= price;
                GameSession.Instance.Army.Add(newUnit);

                if (_pendingItemType.HasValue)
                    FilterArmyList(_pendingItemType.Value);

                UpdateUI();
                FilterArmyList(EItemType.FirePower);
            }
            else
            {
                MessageBox.Show("Не вистачає золота!");
            }

        }

        private void OnSelectItemClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string itemTag = btn.Tag.ToString();

            if (Enum.TryParse(itemTag, out EItemType itemType))
            {
                _pendingItemType = itemType;

                var info = DecoratorConfig.GetInfo[itemType];
                SelectedDecoratorText.Text = $"Обрано: {itemTag} ({info.Price}g)";
                InstructionText.Text = $"Крок 2: Оберіть, кому дати {itemTag}:";
                InstructionText.Foreground = System.Windows.Media.Brushes.DarkRed;

                FilterArmyList(itemType);
            }
        }

        private void OnCancelSelectionClick(object sender, RoutedEventArgs e)
        {
            ResetSelection();
        }

        private void ResetSelection()
        {
            _pendingItemType = null;
            SelectedDecoratorText.Text = "Обрано: Нічого";
            InstructionText.Text = "Ваша армія:";
            InstructionText.Foreground = System.Windows.Media.Brushes.Black;

            ArmyListBox.ItemsSource = GameSession.Instance.Army;
        }

        private void FilterArmyList(EItemType itemType)
        {
            var info = DecoratorConfig.GetInfo[itemType];

            var filteredList = GameSession.Instance.Army
                .Where(u => info.AllowedTypes.Contains(u.Type))
                .ToList();

            ArmyListBox.ItemsSource = filteredList;
        }

        private void OnUnitSelected(object sender, SelectionChangedEventArgs e)
        {
            IUnit selectedUnit = ArmyListBox.SelectedItem as IUnit;
            if (selectedUnit == null) return;

            if (_pendingItemType == null)
            {
                ArmyListBox.SelectedItem = null;
                return;
            }

            TryBuyDecorator(selectedUnit, _pendingItemType.Value);

            ArmyListBox.SelectedItem = null;
        }

        private void TryBuyDecorator(IUnit unit, EItemType itemType)
        {
            var info = DecoratorConfig.GetInfo[itemType];

            if (GameSession.Instance.Gold < info.Price)
            {
                MessageBox.Show($"Треба {info.Price} золота!");
                return;
            }

            if (!info.AllowedTypes.Contains(unit.Type))
            {
                MessageBox.Show("Цей юніт не може носити цей предмет!");
                return;
            }

            GameSession.Instance.Gold -= info.Price;
            ApplyDecoratorToArmy(unit, itemType);
            UpdateUI();

            FilterArmyList(itemType);
        }

        private void ApplyDecoratorToArmy(IUnit oldUnit, EItemType itemType)
        {
            int index = GameSession.Instance.Army.IndexOf(oldUnit);
            if (index == -1) return;

            IUnit wrappedUnit = null;

            switch (itemType)
            {
                case EItemType.FirePower: wrappedUnit = new FirePowerDecorator(oldUnit); break;
                case EItemType.HeavyShield: wrappedUnit = new HeavyShieldDecorator(oldUnit); break;
                case EItemType.MageAura: wrappedUnit = new MageAuraDecorator(oldUnit); break;
                case EItemType.Vampirism: wrappedUnit = new VampirismDecorator(oldUnit); break;
            }

            if (wrappedUnit != null)
            {
                GameSession.Instance.Army[index] = wrappedUnit;
            }
        }

        private void OnNextBattleClick(object sender, RoutedEventArgs e)
        {
            GoToBattle?.Invoke();
        }
    }
}