using SoftwareII.Models;
using SoftwareII.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class UpdateAppointmentForm : Form
    {
        private int _appointmentId;
        private List<Customer> _allCustomers;
        private List<User> _allUsers;

        private DateTime _selectedTime;

        public UpdateAppointmentForm(int appointmentId)
        {
            InitializeComponent();

            _appointmentId = appointmentId;

            _allCustomers = Program.DBService.GetAllCustomers();
            _allUsers = Program.DBService.GetAllConsultants();

            userSelectBox.DataSource = _allUsers;
            userSelectBox.DisplayMember = "userName";
            userSelectBox.ValueMember = "userId";
            userSelectBox.DropDownStyle = ComboBoxStyle.DropDownList;

            customerSelectBox.DataSource = _allCustomers;
            customerSelectBox.DisplayMember = "customerName";
            customerSelectBox.ValueMember = "customerId";
            customerSelectBox.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadAppointment();
        }

        private void LoadAppointment()
        {
            var appointment = Program.DBService.GetAppointmentById(_appointmentId);

            PopulateForm(appointment);
        }

        private void PopulateForm(Appointment appointment)
        {
            datePicker.Value = appointment.start.ToLocalTime();
            timePicker.Value = appointment.start.ToLocalTime();
            appointmentTypeSelect.SelectedItem = appointment.type;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Make sure our dates display local time when shown to the user.
            _selectedTime = new DateTime(datePicker.Value.Year, datePicker.Value.Month, datePicker.Value.Day, timePicker.Value.Hour, timePicker.Value.Minute, timePicker.Value.Second).ToUniversalTime();


            if (formValid())
            {
                var customerId = (int)customerSelectBox.SelectedValue;
                var userId = (int)userSelectBox.SelectedValue;
                Program.DBService.UpdateAppointment(_appointmentId, customerId, userId, _selectedTime, appointmentTypeSelect.Text);
                //refresh our calendar so the new appointment shows up.
                Program.FormService._schedulingManagerForm.RefreshCalendar();
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

            if (AppointmentService.DoAppointmentsOverlap(_selectedTime, _appointmentId))
                return false;

            //Check if this is within business hours local time, we can be outside of business hours when saving to the DB as long as local time is correct.
            if (!AppointmentService.WithinBusinessHours(_selectedTime.ToLocalTime()))
                return false;

            return true;
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
    }
}
