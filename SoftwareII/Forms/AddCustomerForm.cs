using SoftwareII.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            var name = customerNameTextbox.Text;
            var address = customerAddressTextbox.Text;
            var phone = customerPhoneTextbox.Text;

            if (customerNameTextbox.Text == "" || customerPhoneTextbox.Text == "" || customerAddressTextbox.Text == "")
            {
                MessageBox.Show("You must fill out all fields to add a customer.");
                return;
            }

            Program.DBService.CreateNewCustomer(name, address, phone);
        }
    }
}
