
namespace SoftwareII.Forms
{
    partial class UpdateUserForm
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
            this.customerAddressLabel = new System.Windows.Forms.Label();
            this.customerPhoneLabel = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.customerAddressTextbox = new System.Windows.Forms.TextBox();
            this.customerPhoneTextbox = new System.Windows.Forms.TextBox();
            this.customerNameTextbox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customerAddressLabel
            // 
            this.customerAddressLabel.AutoSize = true;
            this.customerAddressLabel.Location = new System.Drawing.Point(30, 135);
            this.customerAddressLabel.Name = "customerAddressLabel";
            this.customerAddressLabel.Size = new System.Drawing.Size(92, 13);
            this.customerAddressLabel.TabIndex = 13;
            this.customerAddressLabel.Text = "Customer Address";
            // 
            // customerPhoneLabel
            // 
            this.customerPhoneLabel.AutoSize = true;
            this.customerPhoneLabel.Location = new System.Drawing.Point(30, 83);
            this.customerPhoneLabel.Name = "customerPhoneLabel";
            this.customerPhoneLabel.Size = new System.Drawing.Size(125, 13);
            this.customerPhoneLabel.TabIndex = 12;
            this.customerPhoneLabel.Text = "Customer Phone Number";
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.AutoSize = true;
            this.customerNameLabel.Location = new System.Drawing.Point(33, 30);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(82, 13);
            this.customerNameLabel.TabIndex = 11;
            this.customerNameLabel.Text = "Customer Name";
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Location = new System.Drawing.Point(151, 229);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(105, 35);
            this.confirmButton.TabIndex = 10;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // customerAddressTextbox
            // 
            this.customerAddressTextbox.Location = new System.Drawing.Point(33, 151);
            this.customerAddressTextbox.Name = "customerAddressTextbox";
            this.customerAddressTextbox.Size = new System.Drawing.Size(227, 20);
            this.customerAddressTextbox.TabIndex = 9;
            // 
            // customerPhoneTextbox
            // 
            this.customerPhoneTextbox.Location = new System.Drawing.Point(33, 99);
            this.customerPhoneTextbox.Name = "customerPhoneTextbox";
            this.customerPhoneTextbox.Size = new System.Drawing.Size(227, 20);
            this.customerPhoneTextbox.TabIndex = 8;
            // 
            // customerNameTextbox
            // 
            this.customerNameTextbox.Location = new System.Drawing.Point(33, 46);
            this.customerNameTextbox.Name = "customerNameTextbox";
            this.customerNameTextbox.Size = new System.Drawing.Size(227, 20);
            this.customerNameTextbox.TabIndex = 7;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(33, 229);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(105, 35);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // UpdateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 297);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.customerAddressLabel);
            this.Controls.Add(this.customerPhoneLabel);
            this.Controls.Add(this.customerNameLabel);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.customerAddressTextbox);
            this.Controls.Add(this.customerPhoneTextbox);
            this.Controls.Add(this.customerNameTextbox);
            this.Name = "UpdateUserForm";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label customerAddressLabel;
        private System.Windows.Forms.Label customerPhoneLabel;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox customerAddressTextbox;
        private System.Windows.Forms.TextBox customerPhoneTextbox;
        private System.Windows.Forms.TextBox customerNameTextbox;
        private System.Windows.Forms.Button cancelButton;
    }
}