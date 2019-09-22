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
    /// Логика взаимодействия для AddBookScreen.xaml
    /// </summary>
    public partial class AddBookScreen : Window
    {
        DbOperations dbOperations = new DbOperations();

        public AddBookScreen(User user)//конструктор
        {
            InitializeComponent();//создает компоненты
            if (!dbOperations.CheckAdminRole(user.Login, user.Password))//проверяет, является ли пользователь админом
            {
                Close();
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if (title.Text != String.Empty && author.Text != String.Empty && publicationDate.Text != String.Empty && genre.Text != String.Empty)
                //берем текст из поля названивание и сравниваем, не пустые ли поля
            {
                dbOperations.AddBook(new Book(title.Text, author.Text, publicationDate.Text, genre.Text));
                    //если поле не пустое, то мы создаем книгу
                Close();//и закрываем элемент
            }
        }
    }
}
