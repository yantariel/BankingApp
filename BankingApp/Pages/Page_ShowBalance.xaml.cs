using BankingApp.Classes;
using System.Windows;
using System.Windows.Controls;

namespace BankingApp.Pages
{
    public partial class Page_ShowBalance : Page
    {
        private MainWindow _parentWindow;
        private Account _account;

        /// <summary>
        /// ОБЪЕДЕНИТЬ С Page_ShowSavingAccount
        /// </summary>
        /// <param name="parentWindow"></param>
        public Page_ShowBalance(MainWindow parentWindow)
        {
            InitializeComponent();

            _parentWindow = parentWindow;
            _account = Static.CurrentAccount;

            UpdateData();
        }

        public void UpdateData()
        {
            Text_CardBalance.Text = _account.CardBalanceView;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.Proxy.Content = new Page_Menu(_parentWindow);
        }
    }
}
