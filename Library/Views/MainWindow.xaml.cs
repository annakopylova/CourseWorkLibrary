using BLL;
using DAL;
using Library.Views;
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

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbOperations dbOperations = new DbOperations();
        List<Book> books = new List<Book>();
        User user;

        public MainWindow(User user)//конструктор окна читательского билета
        {
            InitializeComponent();
            this.user = user;
            if (user.Admin)
            {
                adminBtn.Visibility = Visibility.Visible; //если пользователь админ, то кнопка админ панель видима }
                btnAddBook.Visibility = Visibility.Visible;
            }
            else
            {
                btnAddBook.Visibility = Visibility.Hidden;
                adminBtn.Visibility = Visibility.Hidden;
            }
            if (user is Student)//если студент, то показывается вот это
            {
                studentGrid.Visibility = Visibility.Visible;
                employerGrid.Visibility = Visibility.Hidden;
                FIO.Content = user.FIO;
                group.Content += (user as Student).Group;
                course.Content += (user as Student).Course.ToString();
                faculty.Content += (user as Student).Faculty;
                registrationPacket.Content += (user as Student).RegistrationPacket.ToString();
                libraryCardId.Content += (user as Student).LibraryCard.Id.ToString();
                dateIssue.Content += (user as Student).LibraryCard.DateIssue.ToString();
            }
            if (user is Employee)//если работкник то вот это
            {
                studentGrid.Visibility = Visibility.Hidden;
                employerGrid.Visibility = Visibility.Visible;
                FIO.Content = user.FIO;
                badgeNumber.Content += (user as Employee).BadgeNumber;
                post.Content += (user as Employee).Post;
            }
            GetBooks();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)//метод нажатия на кнопку добавления книги
        {
            AddBookScreen addBookScreen = new AddBookScreen(user);
            addBookScreen.Owner = this;
            addBookScreen.ShowDialog();
            GetBooks();
        }

        private void GetBooks()
        {
            listBooks.Items.Clear();
            books = dbOperations.GetBooks();
            foreach (Book book in books)
            {
                listBooks.Items.Add(book);
            }
        }

        private void ListBook_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dbOperations.CheckAdminRole(user.Login, user.Password))//если пользователь админ
            {
                if (listBooks.SelectedIndex > 0 && listBooks.SelectedIndex < listBooks.Items.Count)
                    //если выбраная книга находится в списке книг (проверка на валидность данных)
                {
                    EditBookScreen editBookScreen = new EditBookScreen(user, listBooks.Items[listBooks.SelectedIndex] as Book);
                    //получение книги из списка книг по выбранному адресу
                    editBookScreen.Owner = this;//указывает на родительское окно
                    editBookScreen.ShowDialog();
                    GetBooks();
                }
            }
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel(user);
            adminPanel.Owner = this;
            adminPanel.Show();
        }
    }
}
