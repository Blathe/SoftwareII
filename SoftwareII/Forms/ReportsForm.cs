using SoftwareII.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class ReportsForm : Form
    {

        private List<User> _allConsultants;
        private List<string> _allAppointmentTypes;

        public ReportsForm()
        {
            InitializeComponent();

            _allConsultants = Program.DBService.GetAllConsultants();
            _allAppointmentTypes = Program.DBService.GetAllAppointmentTypes();

            appointmentTypeDropdown.DataSource = _allAppointmentTypes;
            appointmentTypeDropdown.DisplayMember = "type";

            consultantSelectionBox.ValueMember = "userID";
            consultantSelectionBox.DisplayMember = "userName";
            consultantSelectionBox.DataSource = _allConsultants;

            //PopulateConsultantBox();
        }

        private void PopulateConsultantBox()
        {
            foreach (var consultant in _allConsultants)
            {
                consultantSelectionBox.Items.Add(consultant.userName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportListBox.SelectedItem == null)
            {
                return;
            }

            switch (reportListBox.SelectedItem.ToString())
            {
                case "Appointment Types by Month":
                    appointmentTypesMonthPanel.Enabled = true;
                    appointmentTypesMonthPanel.Visible = true;
                    consultantSchedulePanel.Enabled = false;
                    consultantSchedulePanel.Visible = false;
                    break;
                case "Consultant Schedules":
                    appointmentTypesMonthPanel.Enabled = false;
                    appointmentTypesMonthPanel.Visible = false;
                    consultantSchedulePanel.Enabled = true;
                    consultantSchedulePanel.Visible = true;
                    break;
                case "Consultant Stats":
                    appointmentTypesMonthPanel.Enabled = false;
                    appointmentTypesMonthPanel.Visible = false;
                    consultantSchedulePanel.Enabled = true;
                    consultantSchedulePanel.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            if (reportListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a report to display.");
                return;
            }

            if (consultantSelectionBox.Text == "")
            {
                MessageBox.Show("You must select a consultant before you can generate a report.");
                return;
            }
            else
            {
                switch (reportListBox.SelectedItem.ToString())
                {
                    case "Appointment Types by Month":
                        //GenerateAppointmentTypesByMonthReport(1);
                        AppointmentsByTypeReportForm apptByTypeForm = new AppointmentsByTypeReportForm(monthYearSelection.Value, appointmentTypeDropdown.Text);
                        apptByTypeForm.Show();
                        break;
                    case "Consultant Schedules":
                        ConsultantScheduleForm consultantScheduleForm = new ConsultantScheduleForm((int)consultantSelectionBox.SelectedValue);
                        consultantScheduleForm.Show();
                        //GenerateConsultantSchedulesReport();
                        break;
                    case "Consultant Stats":
                        ConsultantStatsForm consultantStatsForm = new ConsultantStatsForm((int)consultantSelectionBox.SelectedValue);
                        consultantStatsForm.Show();
                        //GenerateConsultantSchedulesReport();
                        break;
                    default:
                        break;
                }
            }
        }

        private void GenerateConsultantSchedulesReport(User consultant)
        {

        }

        private void GenerateAppointmentTypesByMonthReport(int month, string type)
        {

        }
    }
}
