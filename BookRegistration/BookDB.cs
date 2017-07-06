using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistration
{
    class BookDB
    {
        /// <summary>
        /// gets books from the DB
        /// </summary>
        /// <returns>bookList</returns>
        public static List<Book> GetAllBooks()
        {
            // step 1: establish connection to DB
            SqlConnection con = DBHelper.GetConnection();

            // step 2:
            SqlCommand selQuery = new SqlCommand();
            selQuery.Connection = con;
            selQuery.CommandText =
                @"SELECT ISBN 
                    ,Price 
                    ,Title 
                  FROM Book";

            // step 3: open connection
            try
            {
                con.Open();

                //step 4: execute query & get results
                SqlDataReader rdr = selQuery.ExecuteReader();

                List<Book> bookList = new List<Book>();
                //step 5: do something with results
                while (rdr.Read())
                {
                    Book b = new Book();
                    b.ISBN = rdr["ISBN"] as string;
                    b.Price = rdr["Price"] as string;
                    b.Title = rdr["Title"] as string;
                    bookList.Add(b);
                }
                return bookList;
            }
            finally
            {
                //step 6: close connection
                con.Close();
            }
        }


        public static void AddBooks(Book books)
        {
            SqlConnection con = DBHelper.GetConnection();

            SqlCommand addBookCmd = new SqlCommand();
            addBookCmd.Connection = con;
            addBookCmd.CommandText =
                @"INSERT INTO Book(ISBN, Price, Title)
                        VALUES(@isbn, @price, @title)";
            addBookCmd.Parameters.AddWithValue("@isbn", books.ISBN);
            addBookCmd.Parameters.AddWithValue("@price", books.Price);
            addBookCmd.Parameters.AddWithValue("@title", books.Title);

            try
            {
                con.Open();
                int rowsAffected = addBookCmd.ExecuteNonQuery();
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
