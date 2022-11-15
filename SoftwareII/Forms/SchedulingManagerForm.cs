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
            LoadAllAppointments();
        }

        public void LoadAllCustomers()
        {
            _allCustomers = Program.DBService.GetAllCustomers();
            customerDataGrid.DataSource = _allCustomers;
        }

        public void LoadAllAppointments()
        {
            _allAppointments = Program.DBService.GetAllAppointments();
            appointmentDatagrid.DataSource = _allAppointments;
        }
        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            var addCustomerForm = new AddCustomerForm();
            addCustomerForm.Show();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                UpdateUserForm form = new UpdateUserForm(Program.DBService.GetSingleCustomer((int)customerDataGrid.SelectedRows[0].Cells["customerId"].Value));
                form.Show();
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                for (int i = 0; i < customerDataGrid.SelectedRows.Count; i++)
                {
                    Program.DBService.DeleteCustomer((int)customerDataGrid.SelectedRows[i].Cells["customerId"].Value);
                }
            }
        }

        public void RefreshData()
        {
            customerDataGrid.Refresh();
        }
    }
}
