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
    /// Логика взаимодействия для Page_EnterPincode.xaml
    /// </summary>
    public partial class Page_EnterPincode : Page
    {
        private string _code;
        private MainWindow _parentWindow;

        public Page_EnterPincode(MainWindow parentWindow)
        {
            InitializeComponent();
            //DataContext = this;

            _code = string.Empty;
            _parentWindow = parentWindow;
        }

        private void ButtonClick_CheckPincode(object sender, RoutedEventArgs e)
        {
            // считывание пароля введенного пользователем 
            string pincode = TB_pincode.Text;

            Authentification authentification = new Authentification(); //новый экземпляр класса Authentification
            bool isPinValid = authentification.CheckPin(pincode);

            if (isPinValid) //ксли pincode true
            {
                MessageBox.Show("Добро пожаловать!");
                // вызов следующего окошка (с балансом и тд)
                AccountManagement account = _parentWindow.GetAccount();
                _parentWindow.Refresh(new Page_Menu(_parentWindow, account));
            }
            else
            {
                if (authentification.IsBlocked())
                {
                    MessageBox.Show("Неверный pin-код!");
                    MessageBox.Show($"Оставшееся число попыток: {authentification.GetRemainingAttempts()}");
                }
                else
                {
                    MessageBox.Show("Число попыток ввода пин-кода превышено");
                }
                // можно сделать зеленый блок красным или написать текстом некорректный пинкод
            }
        }
    }
}
