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
    /// Логика взаимодействия для Page_ShowCardBalance.xaml
    /// </summary>
    public partial class Page_ShowCardBalance : Page
    {
        private MainWindow _parentWindow;
        private Account _account;

        public Page_ShowCardBalance(Card card, MainWindow parentWindow)
        {
            InitializeComponent();

            this.DataContext = card;

            _parentWindow = parentWindow;
            _account = Static.CurrentAccount;
        }
    }

}
