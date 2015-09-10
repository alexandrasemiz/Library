using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Repository;
using Library.Core;
using System.Collections.Generic;
using Library.Manager;

namespace Manager
{

   public class FakeRepositoryEmpty :ILibraryRepository
   {
        public List<Book> SearchBookDB(String findstring)
        {            
            List<Book> emptyList=new List<Book>();
            return emptyList;
        }

        public List<Book> ShowAllBooksDB() { return new List<Book>(); }
        public void SQLite_CreateDataBase() { }
        public void Create_Table() { }
        public void AddBookDB(Int32 id_book, String avtor, String name) { }
        public Int32 LibraryCountDB() { return 0; }
        public List<Book> SortByDB(String sortname) { return new List<Book>(); }
        public void DeleteBookDB(Int32 id_book) { }
   }

   public class FakeRepositoryException:ILibraryRepository
   {
       public List<Book> SearchBookDB(String findstring)
       {
           throw new ArgumentException();
                
       }
       public List<Book> ShowAllBooksDB() { return new List<Book>(); }
       public void SQLite_CreateDataBase() { }
       public void Create_Table() { }
       public void AddBookDB(Int32 id_book, String avtor, String name) { }
       public Int32 LibraryCountDB() { return 0; }
       public List<Book> SortByDB(String sortname) { return new List<Book>(); }
       public void DeleteBookDB(Int32 id_book) { }
   }

    [TestClass]
    public class SearchTests
    {
        [TestMethod]

        public void Should_Return_Empty_String_If_SearchBookDB_Empty()
        {
            //Arrange
            FakeRepositoryEmpty FakeRepositoryEmpty = new FakeRepositoryEmpty();
            ManagerLibrary manager = new ManagerLibrary(FakeRepositoryEmpty);
            String query = "";
            //Act
            String result = manager.SearchBook(query);

            //Assert
            Assert.IsTrue(result == "");
        }

        [TestMethod]
       
        public void Should_Return_Empty_If_SearchBookDB_Return_Argument_Exception()
        {
            //Arrange
            FakeRepositoryException FakeRepositoryException = new FakeRepositoryException();
            ManagerLibrary manager = new ManagerLibrary(FakeRepositoryException);
            String query= "";

            //Act
            String result = manager.SearchBook(query);

            //Assert
            Assert.IsTrue(result == "");
        }
    }
}
