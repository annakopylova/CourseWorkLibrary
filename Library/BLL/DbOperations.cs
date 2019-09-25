using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DbOperations
    {
        LibraryDBContainer db = new LibraryDBContainer();

        public bool CheckLogin(string login)
        {
            var u = from User in db.UserSet
                    where User.Login.ToLower() == login.ToLower()
                    select User;
            try
            {
                u.First();
                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool CheckAdminRole(string login, string password)
        {
            return GetUser(login, password).Admin;
        }

        public User AddUser(User user)
        {
            if (CheckLogin(user.Login))
            {
                db.UserSet.Add(user);
                db.SaveChanges();
                return user;
            }
            return null;
        }

        public void UpdateUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public User GetUser(string login, string password)
        {
            var user = from User in db.UserSet
                       where User.Login.ToLower() == login && User.Password == password
                       select User;
            try
            {
                return user.First();
            }
            catch
            {
                return null;
            }
        }

        public User GetUser(string login)
        {
            var user = from User in db.UserSet
                       where User.Login.ToLower() == login
                       select User;
            try
            {
                return user.First();
            }
            catch
            {
                return null;
            }
        }

        public List<User> GetUsers()
        {
            return db.UserSet.ToList();
        }

        public Student AddStudent(Student student)
        {
            student.LibraryCard = AddLibraryCard();
            db.UserSet.Add(student);
            db.SaveChanges();
            return student;
        }

        public Employee AddEmployee(Employee employee)
        {
            db.UserSet.Add(employee);
            db.SaveChanges();
            return employee;
        }

        private Book GetBook(int id)
        {
           var book = from Book in db.BookSet
                      where Book.Id == id
                      select Book;
            try
            {
                return book.First();
            }
            catch
            {
                return null;
            }
        }

        public List<Book> GetBooks()
        {
            return db.BookSet.ToList();
        }

        public void AddBook(Book book)
        {
            db.BookSet.Add(book);
            db.SaveChanges();
        }

        public void UpdateBook(Book oldBook, Book newBook)
        {
            DeleteBook(oldBook);
            db.BookSet.Add(newBook);
            db.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            db.BookSet.Remove(GetBook(book.Id));
            db.SaveChanges();
        }

        private LibraryCard AddLibraryCard()
        {
           return db.LibraryCardSet.Add(new LibraryCard());
        }
    }
}
