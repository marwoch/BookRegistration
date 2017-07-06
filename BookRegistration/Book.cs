using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    public class Book
    {
        #region fields
        private string _ISBN;
        private string _Price;
        private string _Title;
        #endregion

        #region constructors
        public Book()
        {

        }

        public Book(string _ISBN)
        {
            this._ISBN = _ISBN;
        }

        public Book(string isbn, string price, string title)
        {
            ISBN = isbn;
            Price = price;
            Title = title;
        }
        #endregion

        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

        public string Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public override string ToString()
        {
            return $"{Title}"; 
        }

    }
}
