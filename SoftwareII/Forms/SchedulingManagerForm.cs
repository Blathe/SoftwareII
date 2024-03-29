﻿using SoftwareII.Models;
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
        public void RefreshAllData()
        {
            LoadAllCustomers();
            LoadAllAppointments();
            RefreshCalendar();
        }

        private void SchedulingManagerForm_Load(object sender, EventArgs e)
        {
            //Do our initial setup, fetching data and setting up calendar.
            LoadAllCustomers();
            LoadAllAppointments();
            SetupCalendar();
        }

        private void SchedulingManagerForm_Shown(object sender, EventArgs e)
        {
            //Do this check in the Form.Shown event to prevent it from popping up before the Scheduling Manager Form is actually visible.
            CheckMyAppointments();
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
        }

        private void CheckMyAppointments()
        {
            foreach (var appt in _allAppointments)
            {
                if (appt.start.ToLocalTime() > DateTime.Now.ToLocalTime())
                {
                    var timeUntil = appt.start.ToLocalTime() - DateTime.Now.ToLocalTime();
                    if (timeUntil.TotalMinutes < 15)
                    {
                        MessageBox.Show(string.Format("You have an upcoming appointment in {0} minute(s). ({1})", Math.Ceiling(timeUntil.TotalMinutes), appt.start.ToLocalTime().ToString("hh:mm tt")));
                        return;
                    }
                }
            }
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

        public void RefreshCalendar()
        {
            PopulateCalendar(_calendarStyle);
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
            }
            catch (Exception e)
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

        private void appointmentReportsButton_Click(object sender, EventArgs e)
        {
            ReportsForm reportForm = new ReportsForm();
            reportForm.Show();
        }

        private void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentDatagrid.SelectedRows.Count > 0)
            {
                var apptId = (int)appointmentDatagrid.SelectedRows[0].Cells["appointmentId"].Value;
                UpdateAppointmentForm updateForm = new UpdateAppointmentForm(apptId);
                updateForm.Show();
            }
        }
    }
}
