using SoftwareII.Models;
using SoftwareII.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class AddAppointmentForm : Form
    {
        private SchedulingManagerForm _schedulingForm;
        private List<Customer> _allCustomers;
        private List<User> _allUsers;

        //private int _timePickerCurrentMinute;

        private DateTime _selectedTime;

        public AddAppointmentForm(SchedulingManagerForm schedulingForm)
        {
            InitializeComponent();
            PopulateCustomerSelectBox();

            _schedulingForm = schedulingForm;

            //_timePickerCurrentMinute = timePicker.Value.Minute;
            _allUsers = Program.DBService.GetAllConsultants();

            userSelectBox.DataSource = _allUsers;
            userSelectBox.DisplayMember = "userName";
            userSelectBox.ValueMember = "userId";
            //to prevent user typing user names.
            userSelectBox.DropDownStyle = ComboBoxStyle.DropDownList;

            appointmentTypeSelect.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void PopulateCustomerSelectBox()
        {
            _allCustomers = Program.DBService.GetAllCustomers();
            customerSelectBox.DataSource = _allCustomers;
            customerSelectBox.DisplayMember = "customerName";
            customerSelectBox.ValueMember = "customerId";
            //to prevent user typing customer names.
            customerSelectBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void AddAppointmentForm_Load(object sender, EventArgs e)
        {
            //Uncomment the code below to prevent selecting a date in the past. Currently allowing appointments to be scheduled in the past to test reports.
            //datePicker.MinDate = DateTime.UtcNow;
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            //Make sure our dates display local time when shown to the user.
            _selectedTime = new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day, timePicker.Value.Hour, timePicker.Value.Minute, timePicker.Value.Second).ToUniversalTime();

            //Validate our form, if it's valid, create our appointment.
            if (formValid())
            {
                var customerId = (int)customerSelectBox.SelectedValue;
                var userId = (int)userSelectBox.SelectedValue;
                Program.DBService.CreateNewAppointment(customerId, userId, Program.DBService.GetCustomerNameById(customerId), appointmentTypeSelect.Text, _selectedTime, _selectedTime.AddMinutes(29));
                //refresh our calendar so the new appointment shows up.
                _schedulingForm.RefreshCalendar();
            }
        }

        private bool formValid()
        {
            if (Program.AuthService._activeUser == null)
                return false;

            if (customerSelectBox.Text == "" || userSelectBox.Text == "" || appointmentTypeSelect.Text == "")
            {
                MessageBox.Show("You must fill in all fields to create a new appointment.");
                return false;
            }

            //Grab our customer from the DB based on the customer ID falue in our select box.
            var customerId = Program.DBService.GetSingleCustomer((int)customerSelectBox.SelectedValue);

            if (customerId == null)
            {
                Console.WriteLine("That customer doesn't exist.");
                return false;
            }

            if (AppointmentService.DoAppointmentsOverlap(_selectedTime, null))
                return false;

            //Check if this is within business hours local time, we can be outside of business hours when saving to the DB as long as local time is correct.
            if (!AppointmentService.WithinBusinessHours(_selectedTime.ToLocalTime()))
                return false;

            return true;
        }
    }
}
