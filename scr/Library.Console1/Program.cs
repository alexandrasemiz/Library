using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Practices.Unity;
using Library.Repository;
using Library.Manager;
using Library.Core;
using System.Collections.ObjectModel;


namespace Library.Console1
{
   class Program 
    {
        static void Main()
        {
            var uc = new UnityContainer();
            //uc.RegisterType<ILibraryRepository, MSSQLRepository>();
            uc.RegisterType<ILibraryRepository, SQLiteRepository>();
            ManagerLibrary objectManager = uc.Resolve<ManagerLibrary>();
            //objectManager.SQLite_CreateDataBase();
            //objectManager.Create_Table();
            //objectManager.AddBook(new Book(1,"Булгаков М.А.", "Мастер и Маргарита"));
            //objectManager.AddBook(new Book(2,"Булгаков М.А.", "Собачье сердце"));
            //objectManager.AddBook(new Book(3, "Достоевский Ф.М.", "Идиот"));
            //objectManager.AddBook(new Book(4, "Достоевский Ф.М.", "Преступление и наказание"));
            //objectManager.AddBook(new Book(5, "Толстой А.", "Петр I"));
            //objectManager.AddBook(new Book(6,"Толстой Л.Н.", "Война и мир"));
            //objectManager.AddBook(new Book(7,"Стендаль", "Красное и черное"));
            
            ObservableCollection<Book> books= objectManager.ShowAllBooks();
            Console.WriteLine(objectManager.ObsCollToString(books));

            //Console.WriteLine(objectManager.LibraryCount());

            //Console.WriteLine(objectManager.SearchBook("тол"));

            //Console.WriteLine(objectManager.SortBy("Name"));

            //Console.WriteLine(objectManager.SortBy("Avtor"));

           //objectManager.DeleteBook(1);

    
      
           // Console.WriteLine(objectManager.ShowAllBooks());
          
            Console.ReadKey();
        }
    }
}
