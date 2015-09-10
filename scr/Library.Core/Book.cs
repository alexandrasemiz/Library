using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Core
{
    public class Book
    {
        private Int32 _id;
        private String _avtor;
        private String _name;
       
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Avtor
        {
            get { return _avtor; }
            set { _avtor = value; }
        }
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Book(Int32 id, String avtor, String name)
        {
            this.Id = id;
            this.Avtor = avtor;
            this.Name = name;
        }
    }
}
