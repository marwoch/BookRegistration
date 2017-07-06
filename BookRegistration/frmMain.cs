using BookRegistration;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PopulateCustomerList();
            PopulateBookList();
        }

        private void PopulateBookList()
        {
            cboBook.Items.Clear();
            try
            {
                List<Book> books = BookDB.GetAllBooks();
                foreach (Book b in books)
                {
                    cboBook.Items.Add(b);
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("We are having trouble loading book data at this time, please try again later.");
                Application.Exit();
            }
        }

        private void PopulateCustomerList()
        {
            cboCustomer.Items.Clear();
            try
            {
                List<Customer> customers = CustomerDB.GetAllCustomers();
                foreach (Customer c in customers)
                {
                    cboCustomer.Items.Add(c);
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("We are having trouble loading customer data at this time, please try again later");
                Application.Exit();
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboCustomer.SelectedIndex < 0)
            //{
            //    return;
            //}
            Customer cust = cboCustomer.SelectedItem as Customer;
            //MessageBox.Show(cust.CustomerID); // had for testing
        }

        private void cboBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBook.SelectedIndex < 0 )
            {
                return;
            }
            Book book = cboBook.SelectedItem as Book;
            //MessageBox.Show(book.ISBN); // had for testing
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer addCust = new AddCustomer();
            addCust.ShowDialog();
            PopulateCustomerList();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook();
            addBook.ShowDialog();
            PopulateBookList();
        }

        private void btnRegBook_Click(object sender, EventArgs e)
        {
            
            if (cboCustomer.SelectedIndex < 0 || cboBook.SelectedIndex < 0)
            {
                MessageBox.Show("You must make a selection.");
                return;
            }
            try
            {
                Customer selectedCust = (Customer)cboCustomer.SelectedItem;
                Book selectedBook = (Book)cboBook.SelectedItem;
                DateTime DateReg = (DateTime)dtpRegDate.Value;

                Registration updateReg = new Registration(selectedCust.CustomerID, selectedBook.ISBN, DateReg);
                BookRegistrationDB.RegisterBook(updateReg);
                
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("We are having server issues, please try again later.");
            }
                       
        }
    }
}
