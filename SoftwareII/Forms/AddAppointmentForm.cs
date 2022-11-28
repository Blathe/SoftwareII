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

        public int _timePickerCurrentMinute;

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
            customerSelectBox.Items.AddRange(_allCustomers.ToArray());
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
    }
}
