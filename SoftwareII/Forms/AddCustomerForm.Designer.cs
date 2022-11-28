
namespace SoftwareII.Forms
{
    partial class AddCustomerForm
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
            this.customerNameTextbox = new System.Windows.Forms.TextBox();
            this.customerPhoneTextbox = new System.Windows.Forms.TextBox();
            this.customerAddressTextbox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerPhoneLabel = new System.Windows.Forms.Label();
            this.customerAddressLabel = new System.Windows.Forms.Label();
            this.customerCityLabel = new System.Windows.Forms.Label();
            this.customerCityTextbox = new System.Windows.Forms.TextBox();
            this.customerCountryLabel = new System.Windows.Forms.Label();
            this.customerCountryTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // customerNameTextbox
            // 
            this.customerNameTextbox.Location = new System.Drawing.Point(53, 66);
            this.customerNameTextbox.Name = "customerNameTextbox";
            this.customerNameTextbox.Size = new System.Drawing.Size(227, 20);
            this.customerNameTextbox.TabIndex = 0;
            // 
            // customerPhoneTextbox
            // 
            this.customerPhoneTextbox.Location = new System.Drawing.Point(53, 119);
            this.customerPhoneTextbox.Name = "customerPhoneTextbox";
            this.customerPhoneTextbox.Size = new System.Drawing.Size(227, 20);
            this.customerPhoneTextbox.TabIndex = 1;
            // 
            // customerAddressTextbox
            // 
            this.customerAddressTextbox.Location = new System.Drawing.Point(53, 171);
            this.customerAddressTextbox.Name = "customerAddressTextbox";
            this.customerAddressTextbox.Size = new System.Drawing.Size(227, 20);
            this.customerAddressTextbox.TabIndex = 2;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Location = new System.Drawing.Point(175, 328);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(105, 35);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(53, 50);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(82, 13);
            this.customerNameLabel.TabIndex = 4;
            this.customerNameLabel.Text = "Customer Name";
            // 
            // customerPhoneLabel
            // 
            this.customerPhoneLabel.AutoSize = true;
            this.customerPhoneLabel.Location = new System.Drawing.Point(50, 103);
            this.customerPhoneLabel.Name = "customerPhoneLabel";
            this.customerPhoneLabel.Size = new System.Drawing.Size(125, 13);
            this.customerPhoneLabel.TabIndex = 5;
            this.customerPhoneLabel.Text = "Customer Phone Number";
            // 
            // customerAddressLabel
            // 
            this.customerAddressLabel.AutoSize = true;
            this.customerAddressLabel.Location = new System.Drawing.Point(50, 155);
            this.customerAddressLabel.Name = "customerAddressLabel";
            this.customerAddressLabel.Size = new System.Drawing.Size(92, 13);
            this.customerAddressLabel.TabIndex = 6;
            this.customerAddressLabel.Text = "Customer Address";
            // 
            // customerCityLabel
            // 
            this.customerCityLabel.AutoSize = true;
            this.customerCityLabel.Location = new System.Drawing.Point(50, 207);
            this.customerCityLabel.Name = "customerCityLabel";
            this.customerCityLabel.Size = new System.Drawing.Size(71, 13);
            this.customerCityLabel.TabIndex = 8;
            this.customerCityLabel.Text = "Customer City";
            // 
            // customerCityTextbox
            // 
            this.customerCityTextbox.Location = new System.Drawing.Point(53, 223);
            this.customerCityTextbox.Name = "customerCityTextbox";
            this.customerCityTextbox.Size = new System.Drawing.Size(227, 20);
            this.customerCityTextbox.TabIndex = 7;
            // 
            // customerCountryLabel
            // 
            this.customerCountryLabel.AutoSize = true;
            this.customerCountryLabel.Location = new System.Drawing.Point(51, 256);
            this.customerCountryLabel.Name = "customerCountryLabel";
            this.customerCountryLabel.Size = new System.Drawing.Size(90, 13);
            this.customerCountryLabel.TabIndex = 10;
            this.customerCountryLabel.Text = "Customer Country";
            // 
            // customerCountryTextbox
            // 
            this.customerCountryTextbox.Location = new System.Drawing.Point(54, 272);
            this.customerCountryTextbox.Name = "customerCountryTextbox";
            this.customerCountryTextbox.Size = new System.Drawing.Size(227, 20);
            this.customerCountryTextbox.TabIndex = 9;
            // 
            // AddCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 416);
            this.Controls.Add(this.customerCountryLabel);
            this.Controls.Add(this.customerCountryTextbox);
            this.Controls.Add(this.customerCityLabel);
            this.Controls.Add(this.customerCityTextbox);
            this.Controls.Add(this.customerAddressLabel);
            this.Controls.Add(this.customerPhoneLabel);
            this.Controls.Add(this.customerNameLabel);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.customerAddressTextbox);
            this.Controls.Add(this.customerPhoneTextbox);
            this.Controls.Add(this.customerNameTextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddCustomerForm";
            this.Padding = new System.Windows.Forms.Padding(50);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerNameTextbox;
        private System.Windows.Forms.TextBox customerPhoneTextbox;
        private System.Windows.Forms.TextBox customerAddressTextbox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label customerPhoneLabel;
        private System.Windows.Forms.Label customerAddressLabel;
        private System.Windows.Forms.Label customerCityLabel;
        private System.Windows.Forms.TextBox customerCityTextbox;
        private System.Windows.Forms.Label customerCountryLabel;
        private System.Windows.Forms.TextBox customerCountryTextbox;
    }
}