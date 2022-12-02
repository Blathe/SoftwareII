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

        public CalendarStyle _calendarStyle;

        public enum CalendarStyle
        {
            MONTHLY,
            WEEKLY
        }

        public SchedulingManagerForm()
        {
            InitializeComponent();
            _culture = CultureInfo.CurrentCulture;

            localeLabel.Text = string.Format("Locale: {0}", _culture.Name);
        }

        private void SchedulingManagerForm_Load(object sender, EventArgs e)
        {
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
            foreach (var appointment in _allAppointments)
            {
                appointment.start = appointment.start.ToLocalTime();
                appointment.end = appointment.end.ToLocalTime();
            }

            appointmentDatagrid.DataSource = _allAppointments;

            SetupCalendar();
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

        public void RefreshCalendar()
        {
            PopulateCalendar(_calendarStyle);
        }

        private void SchedulingManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            AddAppointmentForm form = new AddAppointmentForm(this);
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
                        PopulateCalendar(CalendarStyle.WEEKLY);
                    } 
                }
            }
        }
        private void SetupCalendar()
        {
            calendarListView.View = View.Details;
            calendarListView.Columns.Add("Customer", 70);
            calendarListView.Columns.Add("Appointment Start", 200);
            calendarListView.Columns.Add("Appointment End", 200);

            weeklyViewRadioButton.Checked = true;
            monthlyViewRadioButton.Checked = false;
        }

        private void weeklyViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (weeklyViewRadioButton.Checked == true)
            {
                PopulateCalendar(CalendarStyle.WEEKLY);
            }
        }

        private void monthlyViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (monthlyViewRadioButton.Checked == true)
            {
                PopulateCalendar(CalendarStyle.MONTHLY);
            }
        }

        private void PopulateCalendar(CalendarStyle style)
        {
            try
            {
                if (style == CalendarStyle.MONTHLY)
                {
                    calendarLabel.Text = "Appointment Calendar - This Month (next 30 days)";

                    //This lambda function makes it easy to filter specific appointments to load into the calendar.
                    _calendarAppointments = _allAppointments.FindAll(a => a.createdBy == Program.AuthService._activeUser && a.start >= DateTime.Now.ToUniversalTime() && a.start <= DateTime.Now.AddMonths(1).ToUniversalTime());
                    //This lambda function makes it easy to sort our appointments by starting time.
                    _calendarAppointments.Sort((a1, a2) => a1.start.CompareTo(a2.start));
                    LoadCalendarItems(_calendarAppointments);
                    _calendarStyle = CalendarStyle.MONTHLY;

                }
                else if (style == CalendarStyle.WEEKLY)
                {
                    calendarLabel.Text = "Appointment Calendar - This Week (next 7 days)";
                    //This lambda function makes it easy to filter specific appointments to load into the calendar.
                    _calendarAppointments = _allAppointments.FindAll(a => a.start >= DateTime.Now.ToUniversalTime() && a.start <= DateTime.Now.AddDays(8).ToUniversalTime());
                    //This lambda function makes it easy to sort our appointments by starting time.
                    _calendarAppointments.Sort((a1, a2) => a1.start.CompareTo(a2.start));

                    LoadCalendarItems(_calendarAppointments);
                    _calendarStyle = CalendarStyle.WEEKLY;
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
         
        }

        private void LoadCalendarItems(List<Appointment> appointments)
        {
            calendarListView.Items.Clear();

            foreach (var appointment in appointments)
            {
                var startTime = appointment.start;
                var endTime = appointment.end;
                string[] itemInfo = { appointment.contact, startTime.ToString(), endTime.ToString() };
                ListViewItem item = new ListViewItem(itemInfo);
                calendarListView.Items.Add(item);
            }
        }
    }
}
