using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;
using SoftwareII.Models;
using SoftwareII.Services;

namespace SoftwareII.Forms
{
    public partial class AddAppointmentForm : Form
    {
        public List<Customer> _allCustomers;
        public List<User> _allUsers;

        public int _timePickerCurrentMinute;

        public DateTime _selectedTime;

        public AddAppointmentForm()
        {
            InitializeComponent();
            PopulateCustomerSelectBox();

            _timePickerCurrentMinute = timePicker.Value.Minute;

            //TODO: Add functionality to fetch all Users from DB.
        }

        private void PopulateCustomerSelectBox()
        {
            _allCustomers = Program.DBService.GetAllCustomers();
            customerSelectBox.DataSource = _allCustomers;
            customerSelectBox.DisplayMember = "customerName";
            customerSelectBox.ValueMember = "customerId";
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            datePicker.MinDate = DateTime.UtcNow;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //30 minute increments for minutes in time picker
                if (timePicker.Value.Minute == 1 || timePicker.Value.Minute == 31)
                {
                    timePicker.Value = timePicker.Value.AddMinutes(29);
                }

                if (timePicker.Value.Minute == 59)
                {
                    timePicker.Value = timePicker.Value.AddMinutes(-29);
                }

                if (timePicker.Value.Minute == 29)
                {
                    timePicker.Value = timePicker.Value.AddMinutes(-29);
                    timePicker.Value = timePicker.Value.AddHours(-1);
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            _selectedTime = new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day, timePicker.Value.Hour, timePicker.Value.Minute, timePicker.Value.Second);


            if (formValid())
            {
                var customerId = (int)customerSelectBox.SelectedValue;
                var userId = 1; //TODO hardcoded for now
                Program.DBService.CreateNewAppointment(customerId, userId, appointmentTypeSelect.Text, _selectedTime, _selectedTime.AddMinutes(29));
            }
        }

        private bool formValid()
        {
            if (customerSelectBox.Text == "" || userSelectBox.Text == "" || appointmentTypeSelect.Text == "")
                return false;

            var customerId = Program.DBService.GetSingleCustomer((int)customerSelectBox.SelectedValue);

            if (customerId == null)
            {
                Console.WriteLine("That customer doesn't exist.");
                return false;
            }

            //TODO
            //var user = Program.DBService.GetSingleUser();

            if (AppointmentService.DoAppointmentsOverlap(_selectedTime))
                return false;

            return true;
        }

        private bool AppointmentOverlaps()
        {
            return false;
        }
    }
}
