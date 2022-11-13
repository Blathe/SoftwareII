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
            this.allUsersDataGrid = new System.Windows.Forms.DataGridView();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allUsersLabel = new System.Windows.Forms.Label();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.allUsersDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // allUsersDataGrid
            // 
            this.allUsersDataGrid.AllowUserToAddRows = false;
            this.allUsersDataGrid.AllowUserToDeleteRows = false;
            this.allUsersDataGrid.AutoGenerateColumns = false;
            this.allUsersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allUsersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.activeDataGridViewTextBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.lastUpdateDataGridViewTextBoxColumn,
            this.lastUpdateByDataGridViewTextBoxColumn});
            this.allUsersDataGrid.DataSource = this.userBindingSource;
            this.allUsersDataGrid.Location = new System.Drawing.Point(23, 36);
            this.allUsersDataGrid.Name = "allUsersDataGrid";
            this.allUsersDataGrid.ReadOnly = true;
            this.allUsersDataGrid.Size = new System.Drawing.Size(844, 150);
            this.allUsersDataGrid.TabIndex = 0;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(SoftwareII.Models.User);
            // 
            // allUsersLabel
            // 
            this.allUsersLabel.AutoSize = true;
            this.allUsersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allUsersLabel.Location = new System.Drawing.Point(23, 20);
            this.allUsersLabel.Name = "allUsersLabel";
            this.allUsersLabel.Size = new System.Drawing.Size(57, 13);
            this.allUsersLabel.TabIndex = 1;
            this.allUsersLabel.Text = "All Users";
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "userID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "userID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "userName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "userName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activeDataGridViewTextBoxColumn
            // 
            this.activeDataGridViewTextBoxColumn.DataPropertyName = "active";
            this.activeDataGridViewTextBoxColumn.HeaderText = "active";
            this.activeDataGridViewTextBoxColumn.Name = "activeDataGridViewTextBoxColumn";
            this.activeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "createDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "createDate";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "createdBy";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "createdBy";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdateDataGridViewTextBoxColumn
            // 
            this.lastUpdateDataGridViewTextBoxColumn.DataPropertyName = "lastUpdate";
            this.lastUpdateDataGridViewTextBoxColumn.HeaderText = "lastUpdate";
            this.lastUpdateDataGridViewTextBoxColumn.Name = "lastUpdateDataGridViewTextBoxColumn";
            this.lastUpdateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdateByDataGridViewTextBoxColumn
            // 
            this.lastUpdateByDataGridViewTextBoxColumn.DataPropertyName = "lastUpdateBy";
            this.lastUpdateByDataGridViewTextBoxColumn.HeaderText = "lastUpdateBy";
            this.lastUpdateByDataGridViewTextBoxColumn.Name = "lastUpdateByDataGridViewTextBoxColumn";
            this.lastUpdateByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localeLabel
            // 
            this.localeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.localeLabel.AutoSize = true;
            this.localeLabel.Location = new System.Drawing.Point(1234, 837);
            this.localeLabel.Name = "localeLabel";
            this.localeLabel.Size = new System.Drawing.Size(75, 13);
            this.localeLabel.TabIndex = 2;
            this.localeLabel.Text = "Locale: en-US";
            // 
            // SchedulingManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 870);
            this.Controls.Add(this.localeLabel);
            this.Controls.Add(this.allUsersLabel);
            this.Controls.Add(this.allUsersDataGrid);
            this.Name = "SchedulingManager";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduling Manager";
            ((System.ComponentModel.ISupportInitialize)(this.allUsersDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView allUsersDataGrid;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateByDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label allUsersLabel;
        private System.Windows.Forms.Label localeLabel;
    }
}