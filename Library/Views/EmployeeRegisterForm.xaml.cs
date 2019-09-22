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
    /// Логика взаимодействия для EmployeeRegisterForm.xaml
    /// </summary>
    public partial class EmployeeRegisterForm : Window
    {
        DbOperations dbOperations = new DbOperations();
        User user;

        public EmployeeRegisterForm(User user)//конструктор окна регистрации работников
        {
            InitializeComponent();
            this.user = user;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (badgeNumber.Text != String.Empty && post.Text != String.Empty)
            {
                Employee employee = dbOperations.AddEmployee(new Employee(user, badgeNumber.Text, post.Text));
                //работник добавляется в таблицу работников
                MainWindow mainWindow = new MainWindow(employee);
                mainWindow.Show();
                Close();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
