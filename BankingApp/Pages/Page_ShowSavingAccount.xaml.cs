using BankingApp.Etities.Classes;
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
    /// Логика взаимодействия для Page_ShowSavingAccount.xaml
    /// </summary>
    public partial class Page_ShowSavingAccount : Page
    {
        private MainWindow _parentWindow;
        private AccountManagement _account;
        public Page_ShowSavingAccount(MainWindow parentWindow, AccountManagement account)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _account = account;

            UpdateData();
        }

        public void UpdateData()
        {   
            if (Text_SavingBalance != null)
                Text_SavingBalance.Text = _account.SavingBalance.ToString("N2") + " ₽";
        }

    }
}

