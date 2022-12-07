using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SoftwareII.Models;
using SoftwareII.Utilities;

namespace SoftwareII.Forms
{
    public partial class ConsultantStatsForm : Form
    {
        private List<Appointment> _consultantAppointments;
        private User _consultant;

        private int _consultantId;

        public ConsultantStatsForm(int consultantId)
        {
            InitializeComponent();

            _consultantId = consultantId;
        }

        private void ConsultantStatsForm_Load(object sender, EventArgs e)
        {
            LoadConsultantInformation(_consultantId);
        }

        private void LoadConsultantInformation(int consultantId)
        {
            _consultantAppointments = Program.DBService.GetAllAppointmentsByConsultantId(consultantId);
            _consultant = Program.DBService.GetSingleConsultant(consultantId);

            consultantIdLabel.Text = string.Format("User id: {0}", _consultant.userID.ToString());

            Console.WriteLine(DateTimeUtilities.GetLastDayOfYear(DateTime.Now));

            futureThisWeek.Text = _consultantAppointments.FindAll(appointment => appointment.start >= DateTime.Now.ToUniversalTime() && appointment.start <= DateTimeUtilities.GetLastDayOfWeek(DateTime.Now.ToUniversalTime())).Count.ToString();
            futureThisMonth.Text = _consultantAppointments.FindAll(appointment => appointment.start >= DateTime.Now.ToUniversalTime() && appointment.start <= DateTimeUtilities.GetLastDayOfMonth(DateTime.Now.ToUniversalTime())).Count.ToString();
            futureThisYear.Text = _consultantAppointments.FindAll(appointment => appointment.start >= DateTime.Now.ToUniversalTime() && appointment.start <= DateTimeUtilities.GetLastDayOfYear(DateTime.Now.ToUniversalTime())).Count.ToString();

            pastThisWeek.Text = _consultantAppointments.FindAll(appointment => appointment.start <= DateTime.Now.ToUniversalTime() && appointment.start >= DateTimeUtilities.GetFirstDayOfWeek(DateTime.Now.ToUniversalTime())).Count.ToString();
            pastThisMonth.Text = _consultantAppointments.FindAll(appointment => appointment.start <= DateTime.Now.ToUniversalTime() && appointment.start >= DateTimeUtilities.GetFirstDayOfMonth(DateTime.Now.ToUniversalTime())).Count.ToString();
            pastThisYear.Text = _consultantAppointments.FindAll(appointment => appointment.start <= DateTime.Now.ToUniversalTime() && appointment.start >= DateTimeUtilities.GetFirstDayOfYear(DateTime.Now.ToUniversalTime())).Count.ToString();

        }
    }
}
