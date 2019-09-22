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
    /// Логика взаимодействия для StudentRegiserForm.xaml
    /// </summary>
    public partial class StudentRegiserForm : Window
    {
        DbOperations dbOperations = new DbOperations();
        User user;

        public StudentRegiserForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (faculty.Text != String.Empty && course.Text != String.Empty && group.Text != String.Empty
                && registrationPacket.Text != String.Empty)
            {
                Student student = dbOperations.AddStudent(new Student(user, group.Text, int.Parse(course.Text),
                    faculty.Text, int.Parse(registrationPacket.Text)));
                MainWindow mainWindow = new MainWindow(student);
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
