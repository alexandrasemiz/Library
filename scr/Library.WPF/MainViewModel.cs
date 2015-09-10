using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core;
using Library.Manager;
using Library.Repository;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;

namespace Library.WPF
{
    public partial class MainViewModel
    {
        private ObservableCollection<Book> _booksCollection;
        public ObservableCollection<Book> booksCollection
        {
            get { return _booksCollection ?? (_booksCollection = new ObservableCollection<Book>()); }
            set { }
        }   

        public MainViewModel()
        {
            UnityContainer uc = new UnityContainer();
            uc.RegisterType<ILibraryRepository, SQLiteRepository>();
            //uc.RegisterType<ILibraryRepository, MSSQLRepository>();
            ManagerLibrary manager = uc.Resolve<ManagerLibrary>();           
            ObservableCollection<Book> books = manager.ShowAllBooks();
            foreach (Book book in books)
            {
                booksCollection.Add(book);
            }
        }
        
    }
}
