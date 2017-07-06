using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRegistration
{
    public partial class AddBook : Form
    {
        private Book bookToAdd;

        public AddBook(Book book = null)
        {
            bookToAdd = book;
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Book addBooks = new Book()
            {
                ISBN = txtISBN.Text,
                Price = txtPrice.Text,
                Title = txtTitle.Text
            };
            try
            {
                if(bookToAdd == null)
                {
                    BookDB.AddBooks(addBooks);
                    MessageBox.Show("Book added");
                }
            }
            catch (SqlException sqlex)
            {

                MessageBox.Show("We are having server issues, try again later.");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}






