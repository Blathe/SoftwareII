
namespace SoftwareII.Forms
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportListBox = new System.Windows.Forms.ListBox();
            this.generateReportButton = new System.Windows.Forms.Button();
            this.appointmentTypesMonthPanel = new System.Windows.Forms.Panel();
            this.appointmentTypeDropdown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monthYearSelection = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.consultantSchedulePanel = new System.Windows.Forms.Panel();
            this.consultantSelectionBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.appointmentTypesMonthPanel.SuspendLayout();
            this.consultantSchedulePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportListBox
            // 
            this.reportListBox.FormattingEnabled = true;
            this.reportListBox.Items.AddRange(new object[] {
            "Appointment Types by Month",
            "Consultant Schedules"});
            this.reportListBox.Location = new System.Drawing.Point(23, 40);
            this.reportListBox.Name = "reportListBox";
            this.reportListBox.Size = new System.Drawing.Size(360, 95);
            this.reportListBox.TabIndex = 0;
            this.reportListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // generateReportButton
            // 
            this.generateReportButton.Location = new System.Drawing.Point(23, 265);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(360, 46);
            this.generateReportButton.TabIndex = 1;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.UseVisualStyleBackColor = true;
            this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click);
            // 
            // appointmentTypesMonthPanel
            // 
            this.appointmentTypesMonthPanel.Controls.Add(this.appointmentTypeDropdown);
            this.appointmentTypesMonthPanel.Controls.Add(this.label3);
            this.appointmentTypesMonthPanel.Controls.Add(this.label2);
            this.appointmentTypesMonthPanel.Controls.Add(this.monthYearSelection);
            this.appointmentTypesMonthPanel.Enabled = false;
            this.appointmentTypesMonthPanel.Location = new System.Drawing.Point(23, 141);
            this.appointmentTypesMonthPanel.Name = "appointmentTypesMonthPanel";
            this.appointmentTypesMonthPanel.Size = new System.Drawing.Size(360, 118);
            this.appointmentTypesMonthPanel.TabIndex = 2;
            this.appointmentTypesMonthPanel.Visible = false;
            // 
            // appointmentTypeDropdown
            // 
            this.appointmentTypeDropdown.FormattingEnabled = true;
            this.appointmentTypeDropdown.Location = new System.Drawing.Point(6, 74);
            this.appointmentTypeDropdown.Name = "appointmentTypeDropdown";
            this.appointmentTypeDropdown.Size = new System.Drawing.Size(121, 21);
            this.appointmentTypeDropdown.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Appointment Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select Month:";
            // 
            // monthYearSelection
            // 
            this.monthYearSelection.CustomFormat = "MMMM, yyyy";
            this.monthYearSelection.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthYearSelection.Location = new System.Drawing.Point(6, 22);
            this.monthYearSelection.Name = "monthYearSelection";
            this.monthYearSelection.Size = new System.Drawing.Size(190, 20);
            this.monthYearSelection.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Report";
            // 
            // consultantSchedulePanel
            // 
            this.consultantSchedulePanel.Controls.Add(this.consultantSelectionBox);
            this.consultantSchedulePanel.Controls.Add(this.label5);
            this.consultantSchedulePanel.Enabled = false;
            this.consultantSchedulePanel.Location = new System.Drawing.Point(23, 141);
            this.consultantSchedulePanel.Name = "consultantSchedulePanel";
            this.consultantSchedulePanel.Size = new System.Drawing.Size(216, 55);
            this.consultantSchedulePanel.TabIndex = 4;
            this.consultantSchedulePanel.Visible = false;
            // 
            // consultantSelectionBox
            // 
            this.consultantSelectionBox.FormattingEnabled = true;
            this.consultantSelectionBox.Location = new System.Drawing.Point(6, 23);
            this.consultantSelectionBox.Name = "consultantSelectionBox";
            this.consultantSelectionBox.Size = new System.Drawing.Size(190, 21);
            this.consultantSelectionBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Select Consultant";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 334);
            this.Controls.Add(this.consultantSchedulePanel);
            this.Controls.Add(this.appointmentTypesMonthPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.generateReportButton);
            this.Controls.Add(this.reportListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReportsForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.appointmentTypesMonthPanel.ResumeLayout(false);
            this.appointmentTypesMonthPanel.PerformLayout();
            this.consultantSchedulePanel.ResumeLayout(false);
            this.consultantSchedulePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox reportListBox;
        private System.Windows.Forms.Button generateReportButton;
        private System.Windows.Forms.Panel appointmentTypesMonthPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker monthYearSelection;
        private System.Windows.Forms.ComboBox appointmentTypeDropdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel consultantSchedulePanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox consultantSelectionBox;
    }
}