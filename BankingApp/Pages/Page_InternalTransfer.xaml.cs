using BankingApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankingApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_InternalTransfer.xaml
    /// </summary>
    public partial class Page_InternalTransfer : Page
    {
        private MainWindow _parentWindow;
        private Account _account;

        public Page_InternalTransfer(MainWindow parentWindow, Account account)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _account = account;

            UpdateBalanceDisplay();
        }

        private void UpdateBalanceDisplay()
        {
            Text_CardBalance.Text = _account.CardBalance.ToString("N2") + " ₽";
        }

        private void ButtonClick_CommitInternalTransfer(object sender, RoutedEventArgs e)
        {
            string amountText = Text_TransferAmount.Text;

            bool isNumber = float.TryParse(amountText, out float amount);

            if (isNumber == false)
            {
                MessageBox.Show("Введите корректную сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Нельзя перевести отрицательную сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //через fromItem можем получить текст выбранного пункта
            ComboBoxItem fromItem = Combo_FromAccount.SelectedItem as ComboBoxItem; //as ComboBoxItem превращает выбранный пункт в объект типа ComboBoxItem
            ComboBoxItem toItem = Combo_ToAccount.SelectedItem as ComboBoxItem;  //ComboBoxItem fromItem - переменная туда сохр выбранный пункт

            string fromAccount = "";
            string toAccount = "";

            if (fromItem != null) //пользователь что-то выбрал
            {
                fromAccount = fromItem.Content.ToString();
            }

            if (toItem != null)
            {
                toAccount = toItem.Content.ToString();
            }

            if (fromAccount == toAccount)
            {
                MessageBox.Show("Выберите разные счета для перевода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool success = false;
            string message = "";

            if (fromAccount.Contains("Карта") && toAccount.Contains("Накопительный"))
            {
                if (_account.CardBalance >= amount)
                {
                    float newCardBalance = _account.CardBalance - amount;
                    float newSavingBalance = _account.SavingBalance + amount;

                    _account.UpdateCardBalance(newCardBalance);
                    _account.UpdateSavingBalance(newSavingBalance);

                    success = true;
                    message = "Переведено " + amount.ToString("N2") + " ₽ на накопительный счет";
                }
                else
                {
                    message = "Недостаточно средств на карте";
                }
            }
            else if (fromAccount.Contains("Накопительный") && toAccount.Contains("Карта"))
            {
                if (_account.SavingBalance >= amount)
                {
                    message = "Вы не можете выводить деньги с накопительного счета по условиям договора";
                }
                else
                {
                    message = "Недостаточно средств на накопительном счете";
                }
            }
            else
            {
                message = "Выберите корректные счета для перевода";
            }

            if (success == true)
            {
                MessageBox.Show(message, "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                UpdateBalanceDisplay();

                Page_Menu menuPage = new Page_Menu(_parentWindow);
                _parentWindow.Refresh(menuPage);

                Text_TransferAmount.Text = "";
            }
            else
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

