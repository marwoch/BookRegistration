using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    class CustomerDB
    {
        /// <summary>
        /// getting customers from db
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetAllCustomers()
        {
            //step 1: establish connection to DB
            SqlConnection con = DBHelper.GetConnection();

            //step 2: prepare query (command object)
            SqlCommand selQuery = new SqlCommand();
            selQuery.Connection = con;
            selQuery.CommandText =
                @"SELECT CustomerID 
                    ,DateOfBirth 
                    ,FirstName 
                    ,LastName
                    ,Title 
                  FROM Customer";

            //step 3: open connection
            try
            {
                con.Open();

                //step 4: execute query & get results
                SqlDataReader rdr = selQuery.ExecuteReader();

                List<Customer> customerList = new List<Customer>();
                //step 5: do something with results
                while (rdr.Read())
                {
                    Customer c = new Customer();
                    c.CustomerID = Convert.ToInt32(rdr["CustomerID"]);
                    c.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                    c.FirstName = rdr["FirstName"] as string;
                    c.LastName = rdr["LastName"] as string;
                    c.Title = rdr["Title"] as string;
                    customerList.Add(c);
                }
                return customerList;
            }
            finally
            {
                //step 6: close connection
                con.Close();
            }
        }

        public static void AddCust(Customer cust)
        {
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addCustCmd = new SqlCommand();
            addCustCmd.Connection = con;
            addCustCmd.CommandText =
                @"INSERT INTO Customer(DateOfBirth, FirstName, LastName, Title)
                    VALUES(@dob, @fName, @lName, @title)";
            addCustCmd.Parameters.AddWithValue("@dob", cust.DateOfBirth);
            addCustCmd.Parameters.AddWithValue("@fName", cust.FirstName);
            addCustCmd.Parameters.AddWithValue("@lName", cust.LastName);
            addCustCmd.Parameters.AddWithValue("@title", cust.Title);

            try
            {
                con.Open();
                int rowsAfftected = addCustCmd.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {

                throw sqlex;
            }
            finally
            {
                con.Close();
            }
        }
    }

}
