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
using System.Windows.Shapes;
using BLL;
using DAL;
using Library.Views;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        DbOperations db = new DbOperations();

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != String.Empty && password.Password != String.Empty)
                //проверяет не пустое ли поле с логиным и паролем
            {
                User user = db.GetUser(login.Text, password.Password);//ищет пользователя в базе
                if (user != null)//если пользователь есть, то закрываем
                {
                    Hide();
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    Close();
                }
                else//если пользователя нет
                {
                    error.Content = "Неправильный логин или пароль";
                }
            }
        }

        private void RegisterUser_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen registerScreen = new RegisterScreen();//открывает новый экран
            registerScreen.Owner = this;
            registerScreen.Show();
        }
    }
}
