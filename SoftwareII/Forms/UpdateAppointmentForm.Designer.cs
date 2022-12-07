
namespace SoftwareII.Forms
{
    partial class UpdateAppointmentForm
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
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.businessHoursLabel = new System.Windows.Forms.Label();
            this.appointmentTypeSelect = new System.Windows.Forms.ComboBox();
            this.appointmentTypeLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.userSelectBox = new System.Windows.Forms.ComboBox();
            this.selectConsultantLabel = new System.Windows.Forms.Label();
            this.customerSelectBox = new System.Windows.Forms.ComboBox();
            this.appointmentTimeLabel = new System.Windows.Forms.Label();
            this.selectCustomerLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "hh:mm tt";
            this.timePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(525, 160);
            this.timePicker.MinDate = new System.DateTime(2022, 11, 27, 0, 0, 0, 0);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(102, 26);
            this.timePicker.TabIndex = 23;
            this.timePicker.Value = new System.DateTime(2022, 11, 27, 8, 0, 0, 0);
            this.timePicker.ValueChanged += new System.EventHandler(this.timePicker_ValueChanged);
            // 
            // businessHoursLabel
            // 
            this.businessHoursLabel.AutoSize = true;
            this.businessHoursLabel.Location = new System.Drawing.Point(23, 20);
            this.businessHoursLabel.Name = "businessHoursLabel";
            this.businessHoursLabel.Size = new System.Drawing.Size(196, 13);
            this.businessHoursLabel.TabIndex = 22;
            this.businessHoursLabel.Text = "Business Hours: 8 AM - 6 PM M-F (PST)";
            // 
            // appointmentTypeSelect
            // 
            this.appointmentTypeSelect.FormattingEnabled = true;
            this.appointmentTypeSelect.Items.AddRange(new object[] {
            "Informational",
            "Consultation"});
            this.appointmentTypeSelect.Location = new System.Drawing.Point(246, 208);
            this.appointmentTypeSelect.Name = "appointmentTypeSelect";
            this.appointmentTypeSelect.Size = new System.Drawing.Size(381, 21);
            this.appointmentTypeSelect.TabIndex = 21;
            // 
            // appointmentTypeLabel
            // 
            this.appointmentTypeLabel.AutoSize = true;
            this.appointmentTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTypeLabel.Location = new System.Drawing.Point(23, 209);
            this.appointmentTypeLabel.Name = "appointmentTypeLabel";
            this.appointmentTypeLabel.Size = new System.Drawing.Size(176, 17);
            this.appointmentTypeLabel.TabIndex = 20;
            this.appointmentTypeLabel.Text = "Change Appointment Type";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(23, 238);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(83, 38);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(477, 238);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(150, 38);
            this.updateButton.TabIndex = 18;
            this.updateButton.Text = "Update Appointment";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // userSelectBox
            // 
            this.userSelectBox.FormattingEnabled = true;
            this.userSelectBox.Location = new System.Drawing.Point(246, 111);
            this.userSelectBox.Name = "userSelectBox";
            this.userSelectBox.Size = new System.Drawing.Size(381, 21);
            this.userSelectBox.TabIndex = 17;
            // 
            // selectConsultantLabel
            // 
            this.selectConsultantLabel.AutoSize = true;
            this.selectConsultantLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectConsultantLabel.Location = new System.Drawing.Point(23, 111);
            this.selectConsultantLabel.Name = "selectConsultantLabel";
            this.selectConsultantLabel.Size = new System.Drawing.Size(176, 17);
            this.selectConsultantLabel.TabIndex = 16;
            this.selectConsultantLabel.Text = "Change Consultant (User):";
            // 
            // customerSelectBox
            // 
            this.customerSelectBox.FormattingEnabled = true;
            this.customerSelectBox.Location = new System.Drawing.Point(246, 63);
            this.customerSelectBox.Name = "customerSelectBox";
            this.customerSelectBox.Size = new System.Drawing.Size(381, 21);
            this.customerSelectBox.TabIndex = 15;
            // 
            // appointmentTimeLabel
            // 
            this.appointmentTimeLabel.AutoSize = true;
            this.appointmentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTimeLabel.Location = new System.Drawing.Point(23, 160);
            this.appointmentTimeLabel.Name = "appointmentTimeLabel";
            this.appointmentTimeLabel.Size = new System.Drawing.Size(179, 17);
            this.appointmentTimeLabel.TabIndex = 14;
            this.appointmentTimeLabel.Text = "Change Appointment Time:";
            // 
            // selectCustomerLabel
            // 
            this.selectCustomerLabel.AutoSize = true;
            this.selectCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomerLabel.Location = new System.Drawing.Point(23, 63);
            this.selectCustomerLabel.Name = "selectCustomerLabel";
            this.selectCustomerLabel.Size = new System.Drawing.Size(125, 17);
            this.selectCustomerLabel.TabIndex = 13;
            this.selectCustomerLabel.Text = "Change Customer:";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "MMMM dd, yyyy";
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(246, 160);
            this.datePicker.MinDate = new System.DateTime(2022, 11, 27, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(273, 26);
            this.datePicker.TabIndex = 12;
            this.datePicker.Value = new System.DateTime(2022, 11, 27, 20, 51, 24, 0);
            // 
            // UpdateAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 303);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.businessHoursLabel);
            this.Controls.Add(this.appointmentTypeSelect);
            this.Controls.Add(this.appointmentTypeLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.userSelectBox);
            this.Controls.Add(this.selectConsultantLabel);
            this.Controls.Add(this.customerSelectBox);
            this.Controls.Add(this.appointmentTimeLabel);
            this.Controls.Add(this.selectCustomerLabel);
            this.Controls.Add(this.datePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpdateAppointmentForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateAppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label businessHoursLabel;
        private System.Windows.Forms.ComboBox appointmentTypeSelect;
        private System.Windows.Forms.Label appointmentTypeLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ComboBox userSelectBox;
        private System.Windows.Forms.Label selectConsultantLabel;
        private System.Windows.Forms.ComboBox customerSelectBox;
        private System.Windows.Forms.Label appointmentTimeLabel;
        private System.Windows.Forms.Label selectCustomerLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
    }
}