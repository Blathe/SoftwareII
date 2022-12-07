
namespace SoftwareII.Forms
{
    partial class AppointmentsByTypeReportForm
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
            this.monthYearLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.appointmentListView = new System.Windows.Forms.ListView();
            this.totalLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthYearLabel
            // 
            this.monthYearLabel.AutoSize = true;
            this.monthYearLabel.Location = new System.Drawing.Point(20, 20);
            this.monthYearLabel.Name = "monthYearLabel";
            this.monthYearLabel.Size = new System.Drawing.Size(35, 13);
            this.monthYearLabel.TabIndex = 0;
            this.monthYearLabel.Text = "label1";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(20, 54);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(35, 13);
            this.typeLabel.TabIndex = 1;
            this.typeLabel.Text = "label2";
            // 
            // appointmentListView
            // 
            this.appointmentListView.HideSelection = false;
            this.appointmentListView.Location = new System.Drawing.Point(23, 133);
            this.appointmentListView.Name = "appointmentListView";
            this.appointmentListView.Size = new System.Drawing.Size(347, 329);
            this.appointmentListView.TabIndex = 2;
            this.appointmentListView.UseCompatibleStateImageBehavior = false;
            this.appointmentListView.View = System.Windows.Forms.View.List;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(23, 114);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(35, 13);
            this.totalLabel.TabIndex = 3;
            this.totalLabel.Text = "label1";
            // 
            // AppointmentsByTypeReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 485);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.appointmentListView);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.monthYearLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AppointmentsByTypeReportForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppointmentsByTypeReportForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label monthYearLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ListView appointmentListView;
        private System.Windows.Forms.Label totalLabel;
    }
}