
namespace SoftwareII.Forms
{
    partial class AddAppointmentForm
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
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.selectCustomerLabel = new System.Windows.Forms.Label();
            this.appointmentTimeLabel = new System.Windows.Forms.Label();
            this.customerSelectBox = new System.Windows.Forms.ComboBox();
            this.userSelectBox = new System.Windows.Forms.ComboBox();
            this.selectConsultantLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.appointmentTypeLabel = new System.Windows.Forms.Label();
            this.appointmentTypeSelect = new System.Windows.Forms.ComboBox();
            this.businessHoursLabel = new System.Windows.Forms.Label();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            this.datePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datePicker.CustomFormat = "MMMM dd, yyyy";
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(286, 160);
            this.datePicker.MinDate = new System.DateTime(2022, 11, 27, 0, 0, 0, 0);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(273, 26);
            this.datePicker.TabIndex = 0;
            this.datePicker.Value = new System.DateTime(2022, 11, 27, 20, 51, 24, 0);
            // 
            // selectCustomerLabel
            // 
            this.selectCustomerLabel.AutoSize = true;
            this.selectCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectCustomerLabel.Location = new System.Drawing.Point(23, 63);
            this.selectCustomerLabel.Name = "selectCustomerLabel";
            this.selectCustomerLabel.Size = new System.Drawing.Size(115, 17);
            this.selectCustomerLabel.TabIndex = 1;
            this.selectCustomerLabel.Text = "Select Customer:";
            // 
            // appointmentTimeLabel
            // 
            this.appointmentTimeLabel.AutoSize = true;
            this.appointmentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTimeLabel.Location = new System.Drawing.Point(23, 160);
            this.appointmentTimeLabel.Name = "appointmentTimeLabel";
            this.appointmentTimeLabel.Size = new System.Drawing.Size(169, 17);
            this.appointmentTimeLabel.TabIndex = 2;
            this.appointmentTimeLabel.Text = "Select Appointment Time:";
            // 
            // customerSelectBox
            // 
            this.customerSelectBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customerSelectBox.FormattingEnabled = true;
            this.customerSelectBox.Location = new System.Drawing.Point(286, 63);
            this.customerSelectBox.Name = "customerSelectBox";
            this.customerSelectBox.Size = new System.Drawing.Size(381, 21);
            this.customerSelectBox.TabIndex = 3;
            // 
            // userSelectBox
            // 
            this.userSelectBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userSelectBox.FormattingEnabled = true;
            this.userSelectBox.Location = new System.Drawing.Point(286, 111);
            this.userSelectBox.Name = "userSelectBox";
            this.userSelectBox.Size = new System.Drawing.Size(381, 21);
            this.userSelectBox.TabIndex = 5;
            // 
            // selectConsultantLabel
            // 
            this.selectConsultantLabel.AutoSize = true;
            this.selectConsultantLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectConsultantLabel.Location = new System.Drawing.Point(23, 111);
            this.selectConsultantLabel.Name = "selectConsultantLabel";
            this.selectConsultantLabel.Size = new System.Drawing.Size(166, 17);
            this.selectConsultantLabel.TabIndex = 4;
            this.selectConsultantLabel.Text = "Select Consultant (User):";
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(517, 278);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(150, 38);
            this.confirmButton.TabIndex = 6;
            this.confirmButton.Text = "Create Appointment";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(23, 278);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(83, 38);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // appointmentTypeLabel
            // 
            this.appointmentTypeLabel.AutoSize = true;
            this.appointmentTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentTypeLabel.Location = new System.Drawing.Point(23, 209);
            this.appointmentTypeLabel.Name = "appointmentTypeLabel";
            this.appointmentTypeLabel.Size = new System.Drawing.Size(166, 17);
            this.appointmentTypeLabel.TabIndex = 8;
            this.appointmentTypeLabel.Text = "Select Appointment Type";
            // 
            // appointmentTypeSelect
            // 
            this.appointmentTypeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentTypeSelect.FormattingEnabled = true;
            this.appointmentTypeSelect.Items.AddRange(new object[] {
            "Informational",
            "Consultation"});
            this.appointmentTypeSelect.Location = new System.Drawing.Point(286, 208);
            this.appointmentTypeSelect.Name = "appointmentTypeSelect";
            this.appointmentTypeSelect.Size = new System.Drawing.Size(381, 21);
            this.appointmentTypeSelect.TabIndex = 9;
            // 
            // businessHoursLabel
            // 
            this.businessHoursLabel.AutoSize = true;
            this.businessHoursLabel.Location = new System.Drawing.Point(23, 20);
            this.businessHoursLabel.Name = "businessHoursLabel";
            this.businessHoursLabel.Size = new System.Drawing.Size(197, 13);
            this.businessHoursLabel.TabIndex = 10;
            this.businessHoursLabel.Text = "Business Hours: 8 AM - 6 PM M-F (UTC)";
            // 
            // timePicker
            // 
            this.timePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timePicker.CustomFormat = "hh:mm tt";
            this.timePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(565, 160);
            this.timePicker.MinDate = new System.DateTime(2022, 11, 27, 0, 0, 0, 0);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(102, 26);
            this.timePicker.TabIndex = 11;
            this.timePicker.Value = new System.DateTime(2022, 11, 27, 8, 0, 0, 0);
            this.timePicker.ValueChanged += new System.EventHandler(this.timePicker_ValueChanged);
            // 
            // AddAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 339);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.businessHoursLabel);
            this.Controls.Add(this.appointmentTypeSelect);
            this.Controls.Add(this.appointmentTypeLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.userSelectBox);
            this.Controls.Add(this.selectConsultantLabel);
            this.Controls.Add(this.customerSelectBox);
            this.Controls.Add(this.appointmentTimeLabel);
            this.Controls.Add(this.selectCustomerLabel);
            this.Controls.Add(this.datePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddAppointmentForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Appointment";
            this.Load += new System.EventHandler(this.AddAppointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label selectCustomerLabel;
        private System.Windows.Forms.Label appointmentTimeLabel;
        private System.Windows.Forms.ComboBox customerSelectBox;
        private System.Windows.Forms.ComboBox userSelectBox;
        private System.Windows.Forms.Label selectConsultantLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label appointmentTypeLabel;
        private System.Windows.Forms.ComboBox appointmentTypeSelect;
        private System.Windows.Forms.Label businessHoursLabel;
        private System.Windows.Forms.DateTimePicker timePicker;
    }
}