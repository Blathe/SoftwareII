
namespace SoftwareII.Forms
{
    partial class ConsultantStatsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.futureThisYear = new System.Windows.Forms.Label();
            this.futureThisMonth = new System.Windows.Forms.Label();
            this.futureThisWeek = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pastThisYear = new System.Windows.Forms.Label();
            this.pastThisMonth = new System.Windows.Forms.Label();
            this.pastThisWeek = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.consultantName = new System.Windows.Forms.Label();
            this.consultantIdLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Showing report for consultant:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.futureThisYear);
            this.groupBox1.Controls.Add(this.futureThisMonth);
            this.groupBox1.Controls.Add(this.futureThisWeek);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Future Appointments";
            // 
            // futureThisYear
            // 
            this.futureThisYear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.futureThisYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.futureThisYear.Location = new System.Drawing.Point(157, 61);
            this.futureThisYear.Name = "futureThisYear";
            this.futureThisYear.Size = new System.Drawing.Size(82, 13);
            this.futureThisYear.TabIndex = 5;
            this.futureThisYear.Text = "37";
            this.futureThisYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // futureThisMonth
            // 
            this.futureThisMonth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.futureThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.futureThisMonth.Location = new System.Drawing.Point(149, 39);
            this.futureThisMonth.Name = "futureThisMonth";
            this.futureThisMonth.Size = new System.Drawing.Size(90, 13);
            this.futureThisMonth.TabIndex = 4;
            this.futureThisMonth.Text = "24";
            this.futureThisMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // futureThisWeek
            // 
            this.futureThisWeek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.futureThisWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.futureThisWeek.Location = new System.Drawing.Point(150, 16);
            this.futureThisWeek.Name = "futureThisWeek";
            this.futureThisWeek.Size = new System.Drawing.Size(89, 13);
            this.futureThisWeek.TabIndex = 3;
            this.futureThisWeek.Text = "14";
            this.futureThisWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total This Year:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total This Month:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total This Week:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pastThisYear);
            this.groupBox2.Controls.Add(this.pastThisMonth);
            this.groupBox2.Controls.Add(this.pastThisWeek);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(27, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 88);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Past Appointments";
            // 
            // pastThisYear
            // 
            this.pastThisYear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pastThisYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pastThisYear.Location = new System.Drawing.Point(157, 61);
            this.pastThisYear.Name = "pastThisYear";
            this.pastThisYear.Size = new System.Drawing.Size(82, 13);
            this.pastThisYear.TabIndex = 5;
            this.pastThisYear.Text = "37";
            this.pastThisYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pastThisMonth
            // 
            this.pastThisMonth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pastThisMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pastThisMonth.Location = new System.Drawing.Point(149, 39);
            this.pastThisMonth.Name = "pastThisMonth";
            this.pastThisMonth.Size = new System.Drawing.Size(90, 13);
            this.pastThisMonth.TabIndex = 4;
            this.pastThisMonth.Text = "24";
            this.pastThisMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pastThisWeek
            // 
            this.pastThisWeek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pastThisWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pastThisWeek.Location = new System.Drawing.Point(150, 16);
            this.pastThisWeek.Name = "pastThisWeek";
            this.pastThisWeek.Size = new System.Drawing.Size(89, 13);
            this.pastThisWeek.TabIndex = 3;
            this.pastThisWeek.Text = "14";
            this.pastThisWeek.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Total This Year:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Total This Month:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Total This Week:";
            // 
            // consultantName
            // 
            this.consultantName.AutoSize = true;
            this.consultantName.Location = new System.Drawing.Point(176, 20);
            this.consultantName.Name = "consultantName";
            this.consultantName.Size = new System.Drawing.Size(24, 13);
            this.consultantName.TabIndex = 7;
            this.consultantName.Text = "test";
            // 
            // consultantIdLabel
            // 
            this.consultantIdLabel.AutoSize = true;
            this.consultantIdLabel.Location = new System.Drawing.Point(24, 38);
            this.consultantIdLabel.Name = "consultantIdLabel";
            this.consultantIdLabel.Size = new System.Drawing.Size(35, 13);
            this.consultantIdLabel.TabIndex = 8;
            this.consultantIdLabel.Text = "label5";
            // 
            // ConsultantStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 286);
            this.Controls.Add(this.consultantIdLabel);
            this.Controls.Add(this.consultantName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConsultantStatsForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultant Stats Report";
            this.Load += new System.EventHandler(this.ConsultantStatsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label futureThisYear;
        private System.Windows.Forms.Label futureThisMonth;
        private System.Windows.Forms.Label futureThisWeek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label pastThisYear;
        private System.Windows.Forms.Label pastThisMonth;
        private System.Windows.Forms.Label pastThisWeek;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label consultantName;
        private System.Windows.Forms.Label consultantIdLabel;
    }
}