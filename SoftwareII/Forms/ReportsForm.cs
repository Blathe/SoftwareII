using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SoftwareII.Forms
{
    public partial class ReportsForm : Form
    {
        private string _selectedReport;

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
    }
}
