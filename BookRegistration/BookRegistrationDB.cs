using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    class BookRegistrationDB
    {
        public static void RegisterBook(Registration reg)
        {
           
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand regBookCmd = new SqlCommand();
            regBookCmd.Connection = con;
            regBookCmd.CommandText =
                @"INSERT INTO Registration(ISBN, CustomerID, RegDate)
                        VALUES(@isbn, @custID, @date)";
            regBookCmd.Parameters.AddWithValue("@isbn", reg.ISBN);
            regBookCmd.Parameters.AddWithValue("@custID", reg.CustomerID);
            regBookCmd.Parameters.AddWithValue("@date", reg.RegDate);

            try
            {
                con.Open();
                int rowsAffected = regBookCmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Registration successful.");

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

