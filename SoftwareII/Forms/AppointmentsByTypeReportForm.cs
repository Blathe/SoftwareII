using SoftwareII.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class AppointmentsByTypeReportForm : Form
    {
        private List<Appointment> _allAppointments;
        public AppointmentsByTypeReportForm(DateTime time, string type)
        {
            InitializeComponent();

            _allAppointments = Program.DBService.GetAllAppointmentsByDateAndType(time, type);

            monthYearLabel.Text = string.Format("Month/Year Selected: {0}, {1}", time.ToString("MMMM"), time.ToString("yyyy"), type);
            typeLabel.Text = string.Format("Type of appointment selected: {0}", type);

            PopulateAppointments();
        }

        private void PopulateAppointments()
        {
            foreach (var appt in _allAppointments)
            {
                appointmentListView.Items.Add(string.Format("{0} - {1} - {2}", appt.start.ToLocalTime(), appt.contact, appt.type));
            }

            totalLabel.Text = string.Format("Total appointments: {0}", _allAppointments.Count);
        }
    }
}
