using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Library.Core;
using System.Collections.ObjectModel;


namespace Library.Repository
{
  
   public class MSSQLRepository: ILibraryRepository
    {
        private static String connectionString = "Server=.\\SQLEXPRESS;Database=BookLibrary;Integrated Security=true";

        public void SQLite_CreateDataBase() { }
        public void Create_Table(){}

        public ObservableCollection<Book> ShowAllBooksDB()
       {
           String query = "SELECT * from  [dbo].[Books] ORDER BY Id_book";
           SqlConnection conn = new SqlConnection(connectionString);
           conn.Open();
           Console.WriteLine(conn.State);
           SqlCommand command = new SqlCommand(query, conn);
           SqlDataReader result = command.ExecuteReader();
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
               Console.WriteLine((result.IsClosed) ? "SQLDataReader closed" : "SQLDataReader didn't close");
               conn.Close();
               Console.WriteLine(conn.State);
           }      
          
       }

        public void AddBookDB(Int32 id_book, String avtor, String name)
        {         
            String query = String.Format("INSERT INTO [BookLibrary].[dbo].[Books] (Id_book, Avtor, Name) Values ('{0}', '{1}', '{2}')",id_book,avtor,name);
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            Console.WriteLine(conn.State);
            SqlCommand command = new SqlCommand(query,conn);
            command.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine(conn.State);             
        }

        public Int32 LibraryCountDB()
        {
            String query = "SELECT COUNT(*) FROM [BookLibrary].[dbo].[Books]";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            Console.WriteLine(conn.State);
            SqlCommand commmand = new SqlCommand(query,conn);
            SqlDataReader reader = commmand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    Int32 librarycount = (Int32)reader[0];
                    return librarycount;
                }
            }
            finally
            {
                reader.Close();
                Console.WriteLine((reader.IsClosed) ? "SqlDataReader closed" : "SqlDataReader didn't close");
                conn.Close();
                Console.WriteLine(conn.State);
            }
            return 0;
        }

        public List<Book> SearchBookDB(String findstring)
        {
            String query = "SELECT * FROM [BookLibrary].[dbo].[Books]";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            Console.WriteLine( conn.State);
            SqlCommand command = new SqlCommand(query,conn);
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                List<Book> books=new List<Book>();
                while (reader.Read())
                {
                    String bookstring = (String)reader[1] + (String)reader[2];
                    
                    bookstring = bookstring.ToLower();
                    if (bookstring.Contains(findstring))
                    {
                        Book findbook = new Book((Int32)reader[0],reader[1].ToString(),reader[2].ToString());
                        books.Add(findbook);
                    }
                    
                }
                return books;
            }
            finally
            {
                reader.Close();
                Console.WriteLine((reader.IsClosed) ? "SqlDataReader closed" : "SqlDataReader didn't close");
                conn.Close();
                Console.WriteLine(conn.State);
            }            
        }

        public List<Book> SortByDB(String sortname)
        {
            String query = String.Format("SELECT Id_book, Avtor, Name FROM [BookLibrary].[dbo].[Books] ORDER BY {0}", sortname);
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            Console.WriteLine(conn.State);
            SqlCommand command =new SqlCommand (query,conn);
            SqlDataReader reader = command.ExecuteReader();
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
                Console.WriteLine((reader.IsClosed) ? "SqlDataReader closed" : "SqlDataReader didn't close");
                conn.Close();
                Console.WriteLine(conn.State);
            }
        }

       public void DeleteBookDB(Int32 id_book)
       {
           String query = String.Format("DELETE FROM [BookLibrary].[dbo].[Books] WHERE id_book={0}", id_book);
           SqlConnection conn = new SqlConnection(connectionString);
           conn.Open();
           Console.WriteLine(conn.State);
           SqlCommand command = new SqlCommand(query,conn);
           command.ExecuteNonQuery();

           Console.WriteLine("Book number {0} deleted from library", id_book);
           
           for (Int32 i = id_book; i <= this.LibraryCountDB(); i++)
           {
               query = String.Format("UPDATE [BookLibrary].[dbo].[Books] SET Id_book={0} WHERE Id_book={1}", i, i + 1);
               command = new SqlCommand(query,conn);
               command.ExecuteNonQuery();
           }
           conn.Close();
           Console.WriteLine(conn.State);
       }
    }

}
