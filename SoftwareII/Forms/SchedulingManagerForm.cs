using SoftwareII.Models;
using SoftwareII.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class SchedulingManagerForm : Form
    {
        private List<Customer> _allCustomers;
        private List<Appointment> _allAppointments;
        public CultureInfo _culture;

        public SchedulingManagerForm()
        {
            InitializeComponent();
            _culture = CultureInfo.CurrentCulture;

            localeLabel.Text = string.Format("Locale: {0}", _culture.Name);

            LoadAllCustomers();
        }

        public void LoadAllCustomers()
        {
            _allCustomers = Program.DBService.GetAllCustomers();
            customerDataGrid.DataSource = _allCustomers;
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            var addCustomerForm = new AddCustomerForm();
            addCustomerForm.Show();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {

        }
    }
}
