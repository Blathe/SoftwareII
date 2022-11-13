using SoftwareII.Models;
using SoftwareII.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class SchedulingManagerForm : Form
    {
        private UserService _userService;
        private List<User> _allUsers;
        public CultureInfo _culture;

        public SchedulingManagerForm(UserService userService)
        {
            InitializeComponent();

            _userService = userService;
            _culture = CultureInfo.CurrentCulture;

            localeLabel.Text = string.Format("Locale: {0}", _culture.Name);

            LoadAllUsers();
        }

        public void LoadAllUsers()
        {
            _allUsers = _userService.SelectAllUsers();
            allUsersDataGrid.DataSource = _allUsers;
        }
    }
}
