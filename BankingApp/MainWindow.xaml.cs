using BankingApp.Classes;
using BankingApp.Pages;
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

namespace BankingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TransactionHistory _transactionHistory;
        private TransferManagement _transferManagement;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Static.Initialize();

            _transactionHistory = new TransactionHistory();
            _transferManagement = new TransferManagement(Static.CurrentAccount, _transactionHistory);

            Proxy.Content = new Page_EnterPincode(this);

        }

        public void Refresh(Page page)
        {
            if (page != null)
            {
                Proxy.Content = page;
            }
        }

        public TransactionHistory GetTransactionHistory()
        {
            return _transactionHistory;
        }
        public TransferManagement GetTransferManagement()
        {
            return _transferManagement;
        }

    }
}