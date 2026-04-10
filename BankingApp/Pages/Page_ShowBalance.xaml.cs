using BankingApp.Etities.Classes;
using System.Windows;
using System.Windows.Controls;

namespace BankingApp.Pages
{
    public partial class Page_ShowBalance : Page
    {
        private MainWindow _parentWindow;
        private AccountManagement _account;

        public Page_ShowBalance(MainWindow parentWindow, AccountManagement account)
        {
            InitializeComponent();

            _parentWindow = parentWindow;
            _account = account;

            UpdateData();
        }

        public void UpdateData()
        {
            if (Text_CardBalance != null)
                Text_CardBalance.Text = _account.CardBalance.ToString("N2") + " ₽";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.Proxy.Content = new Page_Menu(_parentWindow, _account);
        }
    }
}
