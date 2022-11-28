using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;
using SoftwareII.Models;

namespace SoftwareII.Forms
{
    public partial class AddAppointmentForm : Form
    {
        public List<Customer> _allCustomers;
        public List<User> _allUsers;

        public AddAppointmentForm()
        {
            InitializeComponent();
            PopulateCustomerSelectBox();
            //TODO: Add functionality to fetch all Users from DB.
        }

        private void PopulateCustomerSelectBox()
        {
            _allCustomers = Program.DBService.GetAllCustomers();
            customerSelectBox.Items.AddRange(_allCustomers.ToArray());
            customerSelectBox.DisplayMember = "customerName";
            customerSelectBox.ValueMember = "customerId";
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            datePicker.MinDate = DateTime.UtcNow;
        }
    }
}
