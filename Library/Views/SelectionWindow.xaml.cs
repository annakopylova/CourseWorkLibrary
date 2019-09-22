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
    /// Логика взаимодействия для SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window//позволяет несколько классов положить в один файл
    {
        User user;

        public SelectionWindow(User user)//окно выбора
        {
            InitializeComponent();
            this.user = user;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StudentBtn_Click(object sender, RoutedEventArgs e)//если студент, то открывается форма регистрации студента
        {
            StudentRegiserForm studentRegiserForm = new StudentRegiserForm(user);
            studentRegiserForm.Show();
        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRegisterForm employeeRegisterForm = new EmployeeRegisterForm(user);
            employeeRegisterForm.Show();
        }
    }
}
