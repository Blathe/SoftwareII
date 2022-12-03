
namespace SoftwareII.Forms
{
    partial class ConsultantScheduleForm
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
            this.usernameLabel = new System.Windows.Forms.Label();
            this.scheduleListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalAppointmentsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(233, 24);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(35, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "label1";
            // 
            // scheduleListView
            // 
            this.scheduleListView.HideSelection = false;
            this.scheduleListView.Location = new System.Drawing.Point(23, 84);
            this.scheduleListView.Name = "scheduleListView";
            this.scheduleListView.Size = new System.Drawing.Size(379, 231);
            this.scheduleListView.TabIndex = 1;
            this.scheduleListView.UseCompatibleStateImageBehavior = false;
            this.scheduleListView.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Displaying all appointments for consultant: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total appointments: ";
            // 
            // totalAppointmentsLabel
            // 
            this.totalAppointmentsLabel.AutoSize = true;
            this.totalAppointmentsLabel.Location = new System.Drawing.Point(129, 48);
            this.totalAppointmentsLabel.Name = "totalAppointmentsLabel";
            this.totalAppointmentsLabel.Size = new System.Drawing.Size(35, 13);
            this.totalAppointmentsLabel.TabIndex = 4;
            this.totalAppointmentsLabel.Text = "label3";
            // 
            // ConsultantScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 338);
            this.Controls.Add(this.totalAppointmentsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scheduleListView);
            this.Controls.Add(this.usernameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConsultantScheduleForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultant Schedule Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.ListView scheduleListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalAppointmentsLabel;
    }
}