namespace SoftwareII.Forms
{
    partial class SchedulingManagerForm
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
            this.components = new System.ComponentModel.Container();
            this.allCustomersLabel = new System.Windows.Forms.Label();
            this.localeLabel = new System.Windows.Forms.Label();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.customerDataGrid = new System.Windows.Forms.DataGridView();
            this.allAppointmentsLabel = new System.Windows.Forms.Label();
            this.appointmentDatagrid = new System.Windows.Forms.DataGridView();
            this.addAppointmentButton = new System.Windows.Forms.Button();
            this.updateAppointmentButton = new System.Windows.Forms.Button();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.calendarLabel = new System.Windows.Forms.Label();
            this.weeklyViewRadioButton = new System.Windows.Forms.RadioButton();
            this.monthlyViewRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.calendarListView = new System.Windows.Forms.ListView();
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.appointmentReportsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDatagrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // allCustomersLabel
            // 
            this.allCustomersLabel.AutoSize = true;
            this.allCustomersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allCustomersLabel.Location = new System.Drawing.Point(23, 20);
            this.allCustomersLabel.Name = "allCustomersLabel";
            this.allCustomersLabel.Size = new System.Drawing.Size(83, 13);
            this.allCustomersLabel.TabIndex = 1;
            this.allCustomersLabel.Text = "All Customers";
            // 
            // localeLabel
            // 
            this.localeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.localeLabel.AutoSize = true;
            this.localeLabel.Location = new System.Drawing.Point(1326, 849);
            this.localeLabel.Name = "localeLabel";
            this.localeLabel.Size = new System.Drawing.Size(75, 13);
            this.localeLabel.TabIndex = 2;
            this.localeLabel.Text = "Locale: en-US";
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCustomerButton.Location = new System.Drawing.Point(23, 279);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(165, 36);
            this.addCustomerButton.TabIndex = 3;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteCustomerButton.Location = new System.Drawing.Point(702, 279);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(165, 36);
            this.deleteCustomerButton.TabIndex = 4;
            this.deleteCustomerButton.Text = "Delete Customer";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // updateCustomerButton
            // 
            this.updateCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateCustomerButton.Location = new System.Drawing.Point(194, 279);
            this.updateCustomerButton.Name = "updateCustomerButton";
            this.updateCustomerButton.Size = new System.Drawing.Size(165, 36);
            this.updateCustomerButton.TabIndex = 5;
            this.updateCustomerButton.Text = "Update Customer";
            this.updateCustomerButton.UseVisualStyleBackColor = true;
            this.updateCustomerButton.Click += new System.EventHandler(this.updateCustomerButton_Click);
            // 
            // customerDataGrid
            // 
            this.customerDataGrid.AllowUserToAddRows = false;
            this.customerDataGrid.AllowUserToDeleteRows = false;
            this.customerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customerDataGrid.Location = new System.Drawing.Point(23, 36);
            this.customerDataGrid.Name = "customerDataGrid";
            this.customerDataGrid.ReadOnly = true;
            this.customerDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGrid.ShowEditingIcon = false;
            this.customerDataGrid.Size = new System.Drawing.Size(844, 237);
            this.customerDataGrid.TabIndex = 6;
            // 
            // allAppointmentsLabel
            // 
            this.allAppointmentsLabel.AutoSize = true;
            this.allAppointmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allAppointmentsLabel.Location = new System.Drawing.Point(20, 395);
            this.allAppointmentsLabel.Name = "allAppointmentsLabel";
            this.allAppointmentsLabel.Size = new System.Drawing.Size(101, 13);
            this.allAppointmentsLabel.TabIndex = 8;
            this.allAppointmentsLabel.Text = "All Appointments";
            // 
            // appointmentDatagrid
            // 
            this.appointmentDatagrid.AllowUserToAddRows = false;
            this.appointmentDatagrid.AllowUserToDeleteRows = false;
            this.appointmentDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDatagrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.appointmentDatagrid.Location = new System.Drawing.Point(23, 420);
            this.appointmentDatagrid.Name = "appointmentDatagrid";
            this.appointmentDatagrid.ReadOnly = true;
            this.appointmentDatagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDatagrid.ShowEditingIcon = false;
            this.appointmentDatagrid.Size = new System.Drawing.Size(1363, 332);
            this.appointmentDatagrid.TabIndex = 9;
            // 
            // addAppointmentButton
            // 
            this.addAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAppointmentButton.Location = new System.Drawing.Point(23, 758);
            this.addAppointmentButton.Name = "addAppointmentButton";
            this.addAppointmentButton.Size = new System.Drawing.Size(165, 36);
            this.addAppointmentButton.TabIndex = 10;
            this.addAppointmentButton.Text = "Add Appointment";
            this.addAppointmentButton.UseVisualStyleBackColor = true;
            this.addAppointmentButton.Click += new System.EventHandler(this.addAppointmentButton_Click);
            // 
            // updateAppointmentButton
            // 
            this.updateAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateAppointmentButton.Location = new System.Drawing.Point(194, 758);
            this.updateAppointmentButton.Name = "updateAppointmentButton";
            this.updateAppointmentButton.Size = new System.Drawing.Size(165, 36);
            this.updateAppointmentButton.TabIndex = 11;
            this.updateAppointmentButton.Text = "Update Appointment";
            this.updateAppointmentButton.UseVisualStyleBackColor = true;
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAppointmentButton.Location = new System.Drawing.Point(1221, 758);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(165, 36);
            this.deleteAppointmentButton.TabIndex = 12;
            this.deleteAppointmentButton.Text = "Delete Appointment";
            this.deleteAppointmentButton.UseVisualStyleBackColor = true;
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // calendarLabel
            // 
            this.calendarLabel.AutoSize = true;
            this.calendarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarLabel.Location = new System.Drawing.Point(914, 20);
            this.calendarLabel.Name = "calendarLabel";
            this.calendarLabel.Size = new System.Drawing.Size(131, 13);
            this.calendarLabel.TabIndex = 14;
            this.calendarLabel.Text = "Appointment Calendar";
            // 
            // weeklyViewRadioButton
            // 
            this.weeklyViewRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weeklyViewRadioButton.AutoSize = true;
            this.weeklyViewRadioButton.Location = new System.Drawing.Point(8, 10);
            this.weeklyViewRadioButton.Name = "weeklyViewRadioButton";
            this.weeklyViewRadioButton.Size = new System.Drawing.Size(87, 17);
            this.weeklyViewRadioButton.TabIndex = 15;
            this.weeklyViewRadioButton.TabStop = true;
            this.weeklyViewRadioButton.Text = "Weekly View";
            this.weeklyViewRadioButton.UseVisualStyleBackColor = true;
            this.weeklyViewRadioButton.CheckedChanged += new System.EventHandler(this.weeklyViewRadioButton_CheckedChanged);
            // 
            // monthlyViewRadioButton
            // 
            this.monthlyViewRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthlyViewRadioButton.AutoSize = true;
            this.monthlyViewRadioButton.Location = new System.Drawing.Point(101, 10);
            this.monthlyViewRadioButton.Name = "monthlyViewRadioButton";
            this.monthlyViewRadioButton.Size = new System.Drawing.Size(88, 17);
            this.monthlyViewRadioButton.TabIndex = 16;
            this.monthlyViewRadioButton.TabStop = true;
            this.monthlyViewRadioButton.Text = "Monthly View";
            this.monthlyViewRadioButton.UseVisualStyleBackColor = true;
            this.monthlyViewRadioButton.CheckedChanged += new System.EventHandler(this.monthlyViewRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.weeklyViewRadioButton);
            this.panel1.Controls.Add(this.monthlyViewRadioButton);
            this.panel1.Location = new System.Drawing.Point(1194, 279);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 36);
            this.panel1.TabIndex = 17;
            // 
            // calendarListView
            // 
            this.calendarListView.FullRowSelect = true;
            this.calendarListView.GridLines = true;
            this.calendarListView.HideSelection = false;
            this.calendarListView.Location = new System.Drawing.Point(917, 36);
            this.calendarListView.Name = "calendarListView";
            this.calendarListView.Size = new System.Drawing.Size(469, 237);
            this.calendarListView.TabIndex = 18;
            this.calendarListView.TabStop = false;
            this.calendarListView.UseCompatibleStateImageBehavior = false;
            // 
            // appointmentBindingSource
            // 
            this.appointmentBindingSource.DataSource = typeof(SoftwareII.Models.Appointment);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(SoftwareII.Models.User);
            // 
            // userBindingSource1
            // 
            this.userBindingSource1.DataSource = typeof(SoftwareII.Models.User);
            // 
            // userBindingSource2
            // 
            this.userBindingSource2.DataSource = typeof(SoftwareII.Models.User);
            // 
            // appointmentReportsButton
            // 
            this.appointmentReportsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentReportsButton.Location = new System.Drawing.Point(26, 811);
            this.appointmentReportsButton.Name = "appointmentReportsButton";
            this.appointmentReportsButton.Size = new System.Drawing.Size(165, 36);
            this.appointmentReportsButton.TabIndex = 19;
            this.appointmentReportsButton.Text = "Reports";
            this.appointmentReportsButton.UseVisualStyleBackColor = true;
            this.appointmentReportsButton.Click += new System.EventHandler(this.appointmentReportsButton_Click);
            // 
            // SchedulingManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 870);
            this.Controls.Add(this.appointmentReportsButton);
            this.Controls.Add(this.calendarListView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.calendarLabel);
            this.Controls.Add(this.deleteAppointmentButton);
            this.Controls.Add(this.updateAppointmentButton);
            this.Controls.Add(this.addAppointmentButton);
            this.Controls.Add(this.appointmentDatagrid);
            this.Controls.Add(this.allAppointmentsLabel);
            this.Controls.Add(this.customerDataGrid);
            this.Controls.Add(this.updateCustomerButton);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.localeLabel);
            this.Controls.Add(this.allCustomersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SchedulingManagerForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduling Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SchedulingManagerForm_FormClosed);
            this.Load += new System.EventHandler(this.SchedulingManagerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDatagrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Label allCustomersLabel;
        private System.Windows.Forms.Label localeLabel;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.DataGridView customerDataGrid;
        private System.Windows.Forms.BindingSource userBindingSource1;
        private System.Windows.Forms.BindingSource userBindingSource2;
        private System.Windows.Forms.Label allAppointmentsLabel;
        private System.Windows.Forms.DataGridView appointmentDatagrid;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        private System.Windows.Forms.Button addAppointmentButton;
        private System.Windows.Forms.Button updateAppointmentButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label calendarLabel;
        private System.Windows.Forms.RadioButton weeklyViewRadioButton;
        private System.Windows.Forms.RadioButton monthlyViewRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView calendarListView;
        private System.Windows.Forms.Button appointmentReportsButton;
    }
}