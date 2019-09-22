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
    /// Логика взаимодействия для EditBookScreen.xaml
    /// </summary>
    public partial class EditBookScreen : Window
    {
        DbOperations dbOperations = new DbOperations();
        Book currentBook;
        Book editedBook;

        public EditBookScreen()//когда нет книг
        {
            InitializeComponent();
        }

        public EditBookScreen(User user, Book book)//когда есть пользователь и книги, то передаем
        {
            InitializeComponent();
            if (!dbOperations.CheckAdminRole(user.Login, user.Password))//проверка админа
            {
                Close();
            }
            currentBook = book;//присвоение полей
            title.Text = book.Title;
            author.Text = book.Author;
            publicationDate.Text = book.PublicationDate;
            genre.Text = book.Genre;

            editedBook = new Book(currentBook);//создет копию текущей книги, чтобы потом ее редактировать и отправлять в бд

            GetUsers();
        }

        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            editedBook.Title = title.Text;//изменение книги
            editedBook.Author = author.Text;
            editedBook.PublicationDate = publicationDate.Text;
            editedBook.Genre = genre.Text;
            dbOperations.UpdateBook(currentBook, editedBook);
            Close();
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            editedBook.LibraryCard = (userList.Items[userList.SelectedIndex] as Student).LibraryCard;//показывает, кто взял книгу
        }

        private void GetUsers()
        {
            List<User> users = dbOperations.GetUsers();
            users.ForEach(user =>
            //получает с бд пользователей и показывает всех студентов
            {
                if (user is Student)//если студент, то добавляет его в список пользователей - визуальный элемент
                {
                    userList.Items.Add(user);
                }
            });
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            dbOperations.DeleteBook(currentBook);
            Close();
        }
    }
}
