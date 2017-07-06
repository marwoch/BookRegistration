using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    public class Customer
    {
        #region fields
        private int _CustomerID;
        private DateTime _DateOfBirth;
        private string _FirstName;
        private string _LastName;
        private string _Title;
        #endregion

        #region constructors
        public Customer()
        {

        }

        public Customer(int _CustomerID)
        {
            this._CustomerID = _CustomerID;
        }

        public Customer(int customerID, DateTime DoB, string firstName, string lastName)
        {
            CustomerID = customerID;
            DateOfBirth = DoB;
            FirstName = firstName;
            LastName = lastName;
        }

        #endregion
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public override string ToString()
        {
            return $"{ FirstName} {LastName}";
        }
    }
}
