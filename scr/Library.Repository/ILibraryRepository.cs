using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core;
using System.Collections.ObjectModel;

namespace Library.Repository
{
    public interface ILibraryRepository
    {
        ObservableCollection<Book> ShowAllBooksDB();
        void SQLite_CreateDataBase();
        void Create_Table();
        void AddBookDB(Int32 id_book, String avtor, String name);
        Int32 LibraryCountDB();
        List<Book> SearchBookDB(String findstring);
        List<Book>   SortByDB(String sortname);
        void DeleteBookDB(Int32 id_book);
    }
}
