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
        private MainWindow _parentWindow;
        private Account _account;

        public Page_Menu(MainWindow parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _account = Static.CurrentAccount;

            UpdateBalanceDisplay();
        }

        public void UpdateBalanceDisplay()
        {
            MenuCardBalance.Text = _account.CardBalanceView;
            MenuSavingBalance.Text = _account.SavingBalanceView;
        }

        private void ButtonClick_ShowBalance(object sender, RoutedEventArgs e)
        {
            //_parentWindow.Refresh(new Page_ShowBalance(_parentWindow));
            _parentWindow.Refresh(new Page_ShowCardBalance(_parentWindow));
        }

        private void ButtonClick_ShowSavingAccount(object sender, RoutedEventArgs e)
        {
            _parentWindow.Refresh(new Page_ShowSavingAccount(_parentWindow));
        }

        private void ButtonClick_ExternalTransfer(object sender, RoutedEventArgs e)
        {
            TransactionHistory history = _parentWindow.GetTransactionHistory(); 
            TransferManagement transfer = _parentWindow.GetTransferManagement();

            _parentWindow.Refresh(new Page_ExternalTransfer(_parentWindow, transfer));
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
