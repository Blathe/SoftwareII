﻿using System;
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
            var city = customerCityTextbox.Text;
            var country = customerCountryTextbox.Text;

            if (customerNameTextbox.Text == "" || customerPhoneTextbox.Text == "" || customerAddressTextbox.Text == "" || customerCountryTextbox.Text == "" || customerCityTextbox.Text == "")
            {
                MessageBox.Show("You must fill out all fields to add a customer.");
                return;
            }

            Program.DBService.CreateNewCustomer(name, address, phone, city, country);
            this.Close();
        }
    }
}
