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
    /// Логика взаимодействия для Page_Menu.xaml
    /// </summary>
    public partial class Page_Menu : Page
    {
        private string _menu;
        private MainWindow _parentWindow;
        private AccountManagement _account;

        public Page_Menu(MainWindow parentWindow, AccountManagement account)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _account = account;

            UpdateBalanceDisplay();
        }

        public void UpdateBalanceDisplay()
        {
            if (MenuCardBalance != null)
                MenuCardBalance.Text = _account.CardBalance.ToString("N2") + " ₽";

            if (MenuSavingsBalance != null)
                MenuSavingsBalance.Text = _account.SavingBalance.ToString("N2") + " ₽";
        }

        private void ButtonClick_ShowBalance(object sender, RoutedEventArgs e)
        {
            _parentWindow.Refresh(new Page_ShowBalance(_parentWindow, _account));
        }

        private void ButtonClick_ShowSavingAccount(object sender, RoutedEventArgs e)
        {
            _parentWindow.Refresh(new Page_ShowSavingAccount(_parentWindow, _account));
        }

        private void ButtonClick_ExternalTransfer(object sender, RoutedEventArgs e)
        {
            AccountManagement account = _parentWindow.GetAccount();
            TransactionHistory history = _parentWindow.GetTransactionHistory(); 
            TransferManagement transfer = _parentWindow.GetTransferManagement();

            _parentWindow.Refresh(new Page_ExternalTransfer(_parentWindow, account, transfer));
        }

        private void ButtonClick_InternalTransfer(object sender, RoutedEventArgs e)
        {
            _parentWindow.Refresh(new Page_InternalTransfer(_parentWindow, _account)); 
        }

        private void ButtonClick_Loan(object sender, RoutedEventArgs e)
        {
            _parentWindow.Refresh(new Page_Loan());
        }

        private void ButtonClick_Bonus(object sender, RoutedEventArgs e)
        {
            _parentWindow.Refresh(new Page_Bonus());
        }
    }
}
