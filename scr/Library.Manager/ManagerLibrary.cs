using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Library.Repository;
using Library.Core;
using System.Collections.ObjectModel;


namespace Library.Manager
{
    interface IManagerLibrary
    { }
    public class ManagerLibrary
    {
        private ILibraryRepository _ilibraryRepository;

        public ManagerLibrary(ILibraryRepository ilibraryRepository)
        {
            this._ilibraryRepository = ilibraryRepository;           
        }

        public ObservableCollection<Book> ShowAllBooks()
        {
           ObservableCollection<Book> books = _ilibraryRepository.ShowAllBooksDB();                      
            return books;
        }

        public void AddBook(Book book)
        {
            String avtor = book.Avtor;
            String name = book.Name;
            Int32 id_book = this.LibraryCount() + 1;
            _ilibraryRepository.AddBookDB(id_book, avtor, name);

            Console.WriteLine("Book {0} {1} {2} is inserting in Library", id_book, avtor, name);

        }

        public Int32 LibraryCount()
        {
            Int32 BooksCount = _ilibraryRepository.LibraryCountDB();
            return BooksCount;
        }

        public String SearchBook(String findstring)
        {
            try
            {
                findstring = findstring.ToLower();
                List<Book> books = _ilibraryRepository.SearchBookDB(findstring);
                String booksString = ListToString(books);
                return booksString;
            }
            catch (ArgumentException e)
            {                
                Console.WriteLine("Ошибка ArgumentException при запросе к БД. {0}", e.ToString());
                findstring = "";
                return findstring;
            }
            finally
            {           
            }
        }

        public String SortBy(String sortname)
        {
           List<Book> books= _ilibraryRepository.SortByDB(sortname);
           String booksString = ListToString(books);
           return booksString;
        }


        public String ObsCollToString(ObservableCollection<Book> books)
        {
            String booksString = "";
            foreach (Book book in books)
            {
                String bookString = book.Id + ". " + book.Avtor + ", " + book.Name + Environment.NewLine;
                booksString += bookString;
            }
            return booksString;
        }

        public String ListToString (List<Book> books)
        {
            String booksString = "";
            foreach (Book book in books)
            {
                String bookString = book.Id + ". " + book.Avtor + ", " + book.Name+Environment.NewLine;
                booksString += bookString;
            }
            return booksString;
        }

        public void DeleteBook(Int32 id_book)
        {
            if (id_book > this.LibraryCount())
            {
                Console.WriteLine("No book with number {0}", id_book);
            }
            else
            {
                _ilibraryRepository.DeleteBookDB(id_book);
            }

        }       
          
        public void SQLite_CreateDataBase()
        { _ilibraryRepository.SQLite_CreateDataBase(); }

        public void Create_Table()
        { _ilibraryRepository.Create_Table(); }
    }
}
