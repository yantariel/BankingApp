using BankingApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для Page_ExternalTransfer.xaml
    /// </summary>
    public partial class Page_ExternalTransfer : Page
    {
        private MainWindow _parentWindow;
        private Account _accountManagement;
        private TransferManagement _transferManagement;

        public Page_ExternalTransfer(MainWindow parentWindow, TransferManagement transferManagement)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _accountManagement = Static.CurrentAccount;
            _transferManagement = transferManagement;

            // Подписываемся на событие Checked радио-кнопок
            RadioButton_Phone.Checked += RadioButton_Checked;
            RadioButton_Card.Checked += RadioButton_Checked;

            PhonePanel.Visibility = Visibility.Visible;
            CardPanel.Visibility = Visibility.Collapsed;

            UpdateBalanceDisplay();
        }

        private void UpdateBalanceDisplay()
        {
            Text_Balance.Text = _accountManagement.AccountBalance.ToString("N2") + " ₽";
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioButton_Phone.IsChecked == true)
            {
                PhonePanel.Visibility = Visibility.Visible;
                CardPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                PhonePanel.Visibility = Visibility.Collapsed;
                CardPanel.Visibility = Visibility.Visible;
            }
        }

        private void ButtonClick_CommitExternalTransfer(object sender, RoutedEventArgs e)
        {
            string amountText = Text_TransferAmmount.Text;
            float amount = 0;

            if (float.TryParse(amountText, out amount) == false)
            {
                MessageBox.Show("Введите корректную сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string recipient; //перевод по карте или телефону
            TransferType type;

            if (RadioButton_Phone.IsChecked == true)
            {
                recipient = Text_PhoneNumber.Text;
                type = TransferType.Phone;
            }
            else
            {
                recipient = Text_CardNumber.Text;
                type = TransferType.Card;
            }

            TransferResult result = _transferManagement.ProcessTransfer(recipient, amount, type);

            if (result.Success == true)
            {
                MessageBox.Show(result.Message, "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);

                UpdateBalanceDisplay();

                Page_Menu menuPage = new Page_Menu(_parentWindow);
                _parentWindow.Refresh(menuPage);

                Text_TransferAmmount.Text = "";

                if (RadioButton_Phone.IsChecked == true)
                {
                    Text_PhoneNumber.Text = "Номер телефона";
                }
                else
                {
                    Text_CardNumber.Text = "Номер карты";
                }
            }
            else
            {
                MessageBox.Show(result.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
