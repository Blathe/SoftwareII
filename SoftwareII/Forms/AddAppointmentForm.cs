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
        private SchedulingManagerForm _schedulingForm;
        public List<Customer> _allCustomers;
        public List<User> _allUsers;

        public int _timePickerCurrentMinute;

        public DateTime _selectedTime;

        public AddAppointmentForm(SchedulingManagerForm schedulingForm)
        {
            InitializeComponent();
            PopulateCustomerSelectBox();

            _schedulingForm = schedulingForm;

            _timePickerCurrentMinute = timePicker.Value.Minute;
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
            _selectedTime = new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day, timePicker.Value.Hour, timePicker.Value.Minute, timePicker.Value.Second).ToUniversalTime();

            if (formValid())
            {
                var customerId = (int)customerSelectBox.SelectedValue;
                var userId = 1; //TODO hardcoded for now
                Program.DBService.CreateNewAppointment(customerId, userId, Program.DBService.GetCustomerNameById(customerId), appointmentTypeSelect.Text, _selectedTime, _selectedTime.AddMinutes(29));
                _schedulingForm.RefreshCalendar();
            }
        }

        private bool formValid()
        {
            if (Program.AuthService._activeUser == null)
                return false;

            if (customerSelectBox.Text == "" || userSelectBox.Text == "" || appointmentTypeSelect.Text == "")
                return false;

            var customerId = Program.DBService.GetSingleCustomer((int)customerSelectBox.SelectedValue);

            if (customerId == null)
            {
                Console.WriteLine("That customer doesn't exist.");
                return false;
            }

            if (AppointmentService.DoAppointmentsOverlap(_selectedTime))
                return false;

            //Check if this is within business hours local time, we can be outside of business hours when saving to the DB as long as local time is correct.
            if (!AppointmentService.WithinBusinessHours(_selectedTime.ToLocalTime()))
                return false;

            return true;
        }
    }
}
