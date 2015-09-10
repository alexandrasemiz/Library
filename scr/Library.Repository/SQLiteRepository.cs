using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Library.Core;
using System.Collections.ObjectModel;

namespace Library.Repository
{
    public class SQLiteRepository:ILibraryRepository
    {
        
        static String DataBaseName = @"D://ProgrammingC#/Library/scr/DataBase.db";
        
        public void SQLite_CreateDataBase()
        {           
            SQLiteConnection.CreateFile(DataBaseName);
            Console.WriteLine(File.Exists(DataBaseName) ? "База данных создана" : "Возникла ошибка при создании базы данных");
          
        }

        public void Create_Table()
        {
            SQLiteConnection m_dbconnection = new SQLiteConnection(String.Format("Data Source={0}",DataBaseName));
            m_dbconnection.Open();
            
            String sql = "create table books (Id_book Int32, Avtor varchar(20), Name varchar(20))";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbconnection);
            command.ExecuteNonQuery();

            m_dbconnection.Close();

            Console.WriteLine("Таблица книги создана");
        }

        public void AddBookDB(Int32 id_book,String avtor, String name)
        {
            String query = String.Format("INSERT INTO books (Id_book, Avtor, Name) Values ('{0}', '{1}', '{2}')", id_book, avtor, name);
            SQLiteConnection m_dbconnection = new SQLiteConnection(String.Format("Data Source={0}", DataBaseName));
            m_dbconnection.Open();

            SQLiteCommand command=new SQLiteCommand(query, m_dbconnection);
            command.ExecuteNonQuery();

            m_dbconnection.Close();
        }

        public ObservableCollection<Book> ShowAllBooksDB()
        {
            String query = "SELECT * from  books ORDER BY Id_book";
            SQLiteConnection m_dbconnection = new SQLiteConnection(String.Format("Data Source={0}", DataBaseName));
            m_dbconnection.Open();

            SQLiteCommand command = new SQLiteCommand(query, m_dbconnection);
            SQLiteDataReader result = command.ExecuteReader();
           
            try
            {
                ObservableCollection<Book> books = new ObservableCollection<Book>();
                while (result.Read())
                {
                    Book book = new Book((Int32)result[0], result[1].ToString(),result[2].ToString());
                    books.Add(book);
                }
                return books;
            }
            finally
            {
                result.Close();
                Console.WriteLine((result.IsClosed) ? "SQLiteDataReader closed" : "SQLiteDataReader didn't close");
                m_dbconnection.Close();
                Console.WriteLine(m_dbconnection.State);
            }      
        }

        public Int32 LibraryCountDB()
        {
            String query = "SELECT COUNT(*) FROM books";
            SQLiteConnection conn = new SQLiteConnection(String.Format("Data Source={0}",DataBaseName));
            conn.Open();
            Console.WriteLine(conn.State);
            SQLiteCommand commmand = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = commmand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    String librarycount = reader[0].ToString();
                    Int32 libcount = Convert.ToInt32(librarycount, 16);
                    return libcount;
                }
            }
            finally
            {
                reader.Close();
                Console.WriteLine((reader.IsClosed) ? "SqliteDataReader closed" : "SqliteDataReader didn't close");
                conn.Close();
                Console.WriteLine(conn.State);
            }
            return 0;
        }

        public List<Book> SearchBookDB(String findstring)
        {
            String query = "SELECT * FROM books";
            SQLiteConnection conn = new SQLiteConnection(String.Format("Data Source={0}",DataBaseName));
            conn.Open();
            Console.WriteLine(conn.State);
            SQLiteCommand command = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            try
            {
                List <Book> books= new List<Book>();
                while (reader.Read())
                {
                    String bookstring = (String)reader[1] + (String)reader[2];

                    bookstring = bookstring.ToLower();
                    if (bookstring.Contains(findstring))
                    {
                        Book book = new Book((Int32)reader[0], reader[1].ToString(), reader[2].ToString());
                        books.Add(book);
                    }

                }
                return books;
            }
            finally
            {
                reader.Close();
                Console.WriteLine((reader.IsClosed) ? "SqliteDataReader closed" : "SqliteDataReader didn't close");
                conn.Close();
                Console.WriteLine(conn.State);
            }            
        }

        public List<Book> SortByDB(String sortname)
        {
            String query = String.Format("SELECT Id_book, Avtor, Name FROM books ORDER BY {0}", sortname);
            SQLiteConnection conn = new SQLiteConnection(String.Format("Data Source={0}",DataBaseName));
            conn.Open();
            Console.WriteLine(conn.State);
            SQLiteCommand command = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            try
            {
                List<Book> books = new List<Book>();
                while (reader.Read())
                {
                    Book book = new Book((Int32)reader[0], reader[1].ToString(), reader[2].ToString());
                    books.Add(book);
                }
                return books;
            }

            finally
            {
                reader.Close();
                Console.WriteLine((reader.IsClosed) ? "SqliteDataReader closed" : "SqliteDataReader didn't close");
                conn.Close();
                Console.WriteLine(conn.State);
            }
        }

        public void DeleteBookDB(Int32 id_book)
        {
            String query = String.Format("DELETE FROM books WHERE id_book={0}", id_book);
            SQLiteConnection conn = new SQLiteConnection(String.Format("Data Source={0}",DataBaseName));
            conn.Open();
            Console.WriteLine(conn.State);
            SQLiteCommand command = new SQLiteCommand(query, conn);
            command.ExecuteNonQuery();

            Console.WriteLine("Book number {0} deleted from library", id_book);

            for (Int32 i = id_book; i <= this.LibraryCountDB(); i++)
            {
                query = String.Format("UPDATE books SET Id_book={0} WHERE Id_book={1}", i, i + 1);
                command = new SQLiteCommand(query, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
            Console.WriteLine(conn.State);
        }
    }
}
