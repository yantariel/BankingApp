using BankingApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
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
        Authentification _authentification;

        public Page_EnterPincode(MainWindow parentWindow)
        {
            InitializeComponent();
            //DataContext = this;

            _code = string.Empty;
            _parentWindow = parentWindow;
            _authentification = new Authentification();
        }

        private void ButtonClick_CheckPincode(object sender, RoutedEventArgs e) //проверка введенного пинкода
        {
            string pincode = TB_pincode.Text;

            if (_authentification.TryCheckPin(pincode, out string error))
            {
                MessageBox.Show("Добро пожаловать!");

                _parentWindow.Refresh(new Page_Menu(_parentWindow)); // вызов следующего окошка (с балансом и тд)
            }
            else
            {
                MessageBox.Show(error);
            }
        }
        private void TB_pincode_PreviewTextInput(object sender, TextCompositionEventArgs e) //запрещает ввод не цифр
        {
            Regex regex = new Regex("[^0-9]+"); //правило: все, что не является цифрой
            e.Handled = regex.IsMatch(e.Text); //e.Text то, что пользователь только что ввел
            //regex.IsMatch(e.Text) проверяет, подходит ли введенный текст под правило (возвращает True/False)
            //e.Handled = false - разрешает вводить символы
        }

        private void TB_pincode_TextChanged(object sender, TextChangedEventArgs e) //управляет видимостью плейсхолдера
        {
            if (string.IsNullOrEmpty(TB_pincode.Text))
            {
                PlaceholderText.Visibility = Visibility.Visible; //показываем многоточие, если в плейсхолдере нет текста
            }
            else
            {
                PlaceholderText.Visibility = Visibility.Collapsed; //скрываем многоточие, если в плейсхолдере текст
            }
        }
    }
}
