using BLL;
using DAL;
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

namespace Library.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        DbOperations dbOperations = new DbOperations();

        public RegisterScreen()
        {
            InitializeComponent();//метод, который выполняет отрисовку самого экрана
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != String.Empty && password.Password != String.Empty && FIO.Text != String.Empty)
            {
                if (dbOperations.CheckLogin(login.Text))//проверяет чек логин
                {
                    var selectionWindow = new SelectionWindow(new User(login.Text, password.Password, FIO.Text));
                    //соездает новое окошко
                    selectionWindow.ShowDialog();
                    Close();
                }
                else
                {
                    loginError.Content = "Лоигн уже используется";
                }
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
