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
        private List<Appointment> _calendarAppointments;
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
                    var confirmResult = MessageBox.Show("Are you sure you want to delete this customer? It will also delete all appointments and data related to this customer.", "Delete Customer?", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        Program.DBService.DeleteCustomer((int)customerDataGrid.SelectedRows[i].Cells["customerId"].Value);
                    }
                }
            }
        } 

        public void RefreshData()
        {
            customerDataGrid.Refresh();
        }

        private void SchedulingManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            AddAppointmentForm form = new AddAppointmentForm();
            form.Show();
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentDatagrid.SelectedRows.Count > 0)
            {
                for (int i = 0; i < appointmentDatagrid.SelectedRows.Count; i++)
                {

                    var confirmResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Delete Appointment?", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        Program.DBService.DeleteAppointment((int)appointmentDatagrid.SelectedRows[i].Cells["appointmentId"].Value);
                    }
                }
            }
        }

        private void weeklyViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _calendarAppointments = _allAppointments.FindAll(appointment => appointment.start > DateTime.Now && appointment.start < DateTime.Now.AddDays(8) && appointment.createdBy == Program.AuthService._activeUser);
            calendarLabel.Text = "Appointment Calendar - This Week (next 7 days)";
            calendarListView.View = View.Details;
            calendarListView.Columns.Add("Customer");
            calendarListView.Columns.Add("Appointment Start");
            foreach (var appointment in _calendarAppointments)
            {
                ListViewItem item = new ListViewItem();
            }
        }

        private void monthlyViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            calendarLabel.Text = "Appointment Calendar - This Month (next 30 days)";
        }
    }
}
