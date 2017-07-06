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
    public partial class AddCustomer : Form
    {
        private Customer custToAdd;
        public AddCustomer(Customer cust = null)
        {
            custToAdd = cust;
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Customer addCust = new Customer()
            {
                DateOfBirth = dateTimePicker1.Value,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Title = txtTitle.Text
            };

            try
            {
                if (custToAdd == null)
                {
                    CustomerDB.AddCust(addCust);
                    MessageBox.Show("Customer added.");
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("We are having server issues, please try again later.:");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
