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
        private UserService _userService;
        private List<User> _allUsers;
        private List<Customer> _allCustomers;
        private List<Appointment> _allAppointments;
        public CultureInfo _culture;

        public SchedulingManagerForm(UserService userService)
        {
            InitializeComponent();

            _userService = userService;
            _culture = CultureInfo.CurrentCulture;

            localeLabel.Text = string.Format("Locale: {0}", _culture.Name);

            LoadAllCustomers();
        }

        public void LoadAllCustomers()
        {
            _allCustomers = Program.DBService.GetAllCustomers();
            customerDataGrid.DataSource = _allCustomers;
        }
    }
}
