namespace DVLD_Ep1
{
    partial class FormOfLocalDrivingLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfLocalDrivingLicenseApplication));
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.lbFilterBy = new System.Windows.Forms.Label();
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.EditApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SechudleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechudleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechudleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechudleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivigLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbLocalDrivingLicenseApplication = new System.Windows.Forms.Label();
            this.lbRecordsNum = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.btnAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetAllRecordsForLocalDrivingLicenseApplication)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterBy.Location = new System.Drawing.Point(363, 330);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(168, 34);
            this.tbFilterBy.TabIndex = 21;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "LdL.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(148, 331);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(209, 37);
            this.cbFilterBy.TabIndex = 20;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // lbFilterBy
            // 
            this.lbFilterBy.AutoSize = true;
            this.lbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilterBy.Location = new System.Drawing.Point(13, 335);
            this.lbFilterBy.Name = "lbFilterBy";
            this.lbFilterBy.Size = new System.Drawing.Size(107, 29);
            this.lbFilterBy.TabIndex = 19;
            this.lbFilterBy.Text = "Filter By:";
            // 
            // dvgGetAllRecordsForLocalDrivingLicenseApplication
            // 
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.AllowUserToAddRows = false;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.AllowUserToDeleteRows = false;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.ContextMenuStrip = this.contextMenuStrip1;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.Location = new System.Drawing.Point(4, 377);
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.MultiSelect = false;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.Name = "dvgGetAllRecordsForLocalDrivingLicenseApplication";
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.ReadOnly = true;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.RowHeadersWidth = 51;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.RowTemplate.Height = 24;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.Size = new System.Drawing.Size(1457, 319);
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.TabIndex = 18;
            this.dvgGetAllRecordsForLocalDrivingLicenseApplication.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvgGetAllRecordsForLocalDrivingLicenseApplication_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.EditApplicationToolStripMenuItem,
            this.DeleteApplicationToolStripMenuItem,
            this.toolStripSeparator2,
            this.CancelApplicationToolStripMenuItem,
            this.toolStripSeparator3,
            this.SechudleTestsToolStripMenuItem,
            this.toolStripSeparator5,
            this.issueDrivigLicenseToolStripMenuItem,
            this.toolStripSeparator6,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator4,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(306, 248);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDetailsToolStripMenuItem.Image = global::DVLD_Ep1.Properties.Resources.PersonDetails_321;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(302, 6);
            // 
            // EditApplicationToolStripMenuItem
            // 
            this.EditApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EditApplicationToolStripMenuItem.Image")));
            this.EditApplicationToolStripMenuItem.Name = "EditApplicationToolStripMenuItem";
            this.EditApplicationToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.EditApplicationToolStripMenuItem.Text = "Edit Application";
            this.EditApplicationToolStripMenuItem.Click += new System.EventHandler(this.EditApplicationToolStripMenuItem_Click);
            // 
            // DeleteApplicationToolStripMenuItem
            // 
            this.DeleteApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteApplicationToolStripMenuItem.Image")));
            this.DeleteApplicationToolStripMenuItem.Name = "DeleteApplicationToolStripMenuItem";
            this.DeleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.DeleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.DeleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.DeleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(302, 6);
            // 
            // CancelApplicationToolStripMenuItem
            // 
            this.CancelApplicationToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelApplicationToolStripMenuItem.Image = global::DVLD_Ep1.Properties.Resources.Delete_32;
            this.CancelApplicationToolStripMenuItem.Name = "CancelApplicationToolStripMenuItem";
            this.CancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.CancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.CancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.CancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(302, 6);
            // 
            // SechudleTestsToolStripMenuItem
            // 
            this.SechudleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sechudleVisionTestToolStripMenuItem,
            this.sechudleWrittenTestToolStripMenuItem,
            this.sechudleStreetTestToolStripMenuItem});
            this.SechudleTestsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SechudleTestsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SechudleTestsToolStripMenuItem.Image")));
            this.SechudleTestsToolStripMenuItem.Name = "SechudleTestsToolStripMenuItem";
            this.SechudleTestsToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.SechudleTestsToolStripMenuItem.Text = "Sechudle Tests";
            // 
            // sechudleVisionTestToolStripMenuItem
            // 
            this.sechudleVisionTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sechudleVisionTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sechudleVisionTestToolStripMenuItem.Image")));
            this.sechudleVisionTestToolStripMenuItem.Name = "sechudleVisionTestToolStripMenuItem";
            this.sechudleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.sechudleVisionTestToolStripMenuItem.Text = "Sechudle Vision Test";
            this.sechudleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.sechudleVisionTestToolStripMenuItem_Click);
            // 
            // sechudleWrittenTestToolStripMenuItem
            // 
            this.sechudleWrittenTestToolStripMenuItem.Enabled = false;
            this.sechudleWrittenTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sechudleWrittenTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sechudleWrittenTestToolStripMenuItem.Image")));
            this.sechudleWrittenTestToolStripMenuItem.Name = "sechudleWrittenTestToolStripMenuItem";
            this.sechudleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.sechudleWrittenTestToolStripMenuItem.Text = "Sechudle Written Test";
            this.sechudleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.sechudleWrittenTestToolStripMenuItem_Click);
            // 
            // sechudleStreetTestToolStripMenuItem
            // 
            this.sechudleStreetTestToolStripMenuItem.Enabled = false;
            this.sechudleStreetTestToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sechudleStreetTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sechudleStreetTestToolStripMenuItem.Image")));
            this.sechudleStreetTestToolStripMenuItem.Name = "sechudleStreetTestToolStripMenuItem";
            this.sechudleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.sechudleStreetTestToolStripMenuItem.Text = "Sechudle Street Test";
            this.sechudleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.sechudleStreetTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(302, 6);
            // 
            // issueDrivigLicenseToolStripMenuItem
            // 
            this.issueDrivigLicenseToolStripMenuItem.Enabled = false;
            this.issueDrivigLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueDrivigLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("issueDrivigLicenseToolStripMenuItem.Image")));
            this.issueDrivigLicenseToolStripMenuItem.Name = "issueDrivigLicenseToolStripMenuItem";
            this.issueDrivigLicenseToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.issueDrivigLicenseToolStripMenuItem.Text = "Issue Drivig License (First Time)";
            this.issueDrivigLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueDrivigLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(302, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseToolStripMenuItem.Image")));
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License ";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(302, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Variable Text", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonLicenseHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showPersonLicenseHistoryToolStripMenuItem.Image")));
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseToolStripMenuItem_Click);
            // 
            // lbLocalDrivingLicenseApplication
            // 
            this.lbLocalDrivingLicenseApplication.AutoSize = true;
            this.lbLocalDrivingLicenseApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalDrivingLicenseApplication.ForeColor = System.Drawing.Color.Red;
            this.lbLocalDrivingLicenseApplication.Location = new System.Drawing.Point(438, 258);
            this.lbLocalDrivingLicenseApplication.Name = "lbLocalDrivingLicenseApplication";
            this.lbLocalDrivingLicenseApplication.Size = new System.Drawing.Size(457, 36);
            this.lbLocalDrivingLicenseApplication.TabIndex = 17;
            this.lbLocalDrivingLicenseApplication.Text = "Local Driving License Application";
            // 
            // lbRecordsNum
            // 
            this.lbRecordsNum.AutoSize = true;
            this.lbRecordsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsNum.Location = new System.Drawing.Point(172, 711);
            this.lbRecordsNum.Name = "lbRecordsNum";
            this.lbRecordsNum.Size = new System.Drawing.Size(52, 29);
            this.lbRecordsNum.TabIndex = 23;
            this.lbRecordsNum.Text = "???";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(13, 711);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(153, 29);
            this.lbRecords.TabIndex = 22;
            this.lbRecords.Text = "# Records : ";
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewLocalDrivingLicenseApplication.Image")));
            this.btnAddNewLocalDrivingLicenseApplication.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(1349, 286);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(104, 85);
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 26;
            this.btnAddNewLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(794, 142);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 50);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1299, 709);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 41);
            this.button1.TabIndex = 24;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(566, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // FormOfLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 822);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbRecordsNum);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.lbFilterBy);
            this.Controls.Add(this.dvgGetAllRecordsForLocalDrivingLicenseApplication);
            this.Controls.Add(this.lbLocalDrivingLicenseApplication);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormOfLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormOfLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.FormOfLocalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetAllRecordsForLocalDrivingLicenseApplication)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label lbFilterBy;
        private System.Windows.Forms.DataGridView dvgGetAllRecordsForLocalDrivingLicenseApplication;
        private System.Windows.Forms.Label lbLocalDrivingLicenseApplication;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbRecordsNum;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SechudleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivigLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechudleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechudleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechudleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}