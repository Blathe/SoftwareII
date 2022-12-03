using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SoftwareII.Models;

namespace SoftwareII.Forms
{
    public partial class ReportsForm : Form
    {

        private List<User> _allConsultants;

        public ReportsForm()
        {
            InitializeComponent();

            _allConsultants = Program.DBService.GetAllConsultants();

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
                default:
                    break;
            }
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            if (consultantSelectionBox.Text == "")
            {
                MessageBox.Show("You must select a consultant before you can generate a report.");
            } else
            {
                switch (reportListBox.SelectedItem.ToString())
                {
                    case "Appointment Types by Month":
                        //GenerateAppointmentTypesByMonthReport(1);
                        break;
                    case "Consultant Schedules":
                        ConsultantScheduleForm form = new ConsultantScheduleForm((int)consultantSelectionBox.SelectedValue);
                        form.Show();
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
