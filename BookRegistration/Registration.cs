using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    class Registration
    {
        private string _ISBN;
        private int _CustomerID;
        private DateTime _RegDate;


        public Registration()
        {

        }
        public Registration(int customerID, string isbn, DateTime regDate)
        {
            CustomerID = customerID;
            ISBN = isbn;
            RegDate = regDate;
        }

        public string ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }
        public DateTime RegDate
        {
            get { return _RegDate; }
            set { _RegDate = value; }
        }

        public bool RegSuccess()
        {
            throw new NotImplementedException();
        }
    }
}
