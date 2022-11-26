using SoftwareII.Models;
using SoftwareII.Services;
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
    public partial class UpdateUserForm : Form
    {
        public Address _address;
        public Customer _customer;
        public UpdateUserForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;

            customerNameTextbox.Text = _customer.customerName;
            _address = Program.DBService.GetAddressByID(_customer.addressId);
            customerAddressTextbox.Text = _address.address;
            customerPhoneTextbox.Text = _address.phone;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            Program.DBService.UpdateCustomer(_customer.customerId, _customer.addressId, customerNameTextbox.Text, customerAddressTextbox.Text, customerPhoneTextbox.Text);
        }
    }
}
