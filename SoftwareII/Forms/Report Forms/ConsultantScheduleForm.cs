using SoftwareII.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class ConsultantScheduleForm : Form
    {
        private User _user;
        private int _userId;
        private List<Appointment> _appointments;
        public ConsultantScheduleForm(int userId)
        {
            InitializeComponent();

            _userId = userId;
            PopulateReport(_userId);
        }

        private void PopulateReport(int userId)
        {
            _user = Program.DBService.GetSingleConsultant(userId);
            usernameLabel.Text = _user.userName;

            _appointments = Program.DBService.GetAllAppointmentsByConsultantId(_userId);
            foreach (var appointment in _appointments)
            {
                scheduleListView.Items.Add(string.Format("{0} - {1} - {2}", appointment.start.ToLocalTime().ToString(), appointment.contact, appointment.type));
            }

            totalAppointmentsLabel.Text = _appointments.Count.ToString();
        }
    }
}
