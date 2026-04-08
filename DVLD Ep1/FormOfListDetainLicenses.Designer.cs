namespace DVLD_Ep1
{
    partial class FormOfListDetainLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfListDetainLicenses));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDetain = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbRecordsNum = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.lbFilterBy = new System.Windows.Forms.Label();
            this.dvgGetAllRecordsDetainedLicense = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbInternationalDrivingLicenseApplication = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRelease = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetAllRecordsDetainedLicense)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDetain
            // 
            this.btnDetain.Image = ((System.Drawing.Image)(resources.GetObject("btnDetain.Image")));
            this.btnDetain.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDetain.Location = new System.Drawing.Point(1397, 240);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(104, 85);
            this.btnDetain.TabIndex = 47;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1287, 666);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 41);
            this.button1.TabIndex = 45;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbRecordsNum
            // 
            this.lbRecordsNum.AutoSize = true;
            this.lbRecordsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsNum.Location = new System.Drawing.Point(160, 668);
            this.lbRecordsNum.Name = "lbRecordsNum";
            this.lbRecordsNum.Size = new System.Drawing.Size(52, 29);
            this.lbRecordsNum.TabIndex = 44;
            this.lbRecordsNum.Text = "???";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(1, 668);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(153, 29);
            this.lbRecords.TabIndex = 43;
            this.lbRecords.Text = "# Records : ";
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterBy.Location = new System.Drawing.Point(351, 287);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(168, 34);
            this.tbFilterBy.TabIndex = 42;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "Full Name",
            "Release Application ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(136, 288);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(209, 37);
            this.cbFilterBy.TabIndex = 41;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // lbFilterBy
            // 
            this.lbFilterBy.AutoSize = true;
            this.lbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilterBy.Location = new System.Drawing.Point(1, 292);
            this.lbFilterBy.Name = "lbFilterBy";
            this.lbFilterBy.Size = new System.Drawing.Size(107, 29);
            this.lbFilterBy.TabIndex = 40;
            this.lbFilterBy.Text = "Filter By:";
            // 
            // dvgGetAllRecordsDetainedLicense
            // 
            this.dvgGetAllRecordsDetainedLicense.AllowUserToAddRows = false;
            this.dvgGetAllRecordsDetainedLicense.AllowUserToDeleteRows = false;
            this.dvgGetAllRecordsDetainedLicense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvgGetAllRecordsDetainedLicense.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgGetAllRecordsDetainedLicense.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgGetAllRecordsDetainedLicense.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgGetAllRecordsDetainedLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgGetAllRecordsDetainedLicense.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgGetAllRecordsDetainedLicense.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgGetAllRecordsDetainedLicense.Location = new System.Drawing.Point(27, 331);
            this.dvgGetAllRecordsDetainedLicense.MultiSelect = false;
            this.dvgGetAllRecordsDetainedLicense.Name = "dvgGetAllRecordsDetainedLicense";
            this.dvgGetAllRecordsDetainedLicense.ReadOnly = true;
            this.dvgGetAllRecordsDetainedLicense.RowHeadersWidth = 51;
            this.dvgGetAllRecordsDetainedLicense.RowTemplate.Height = 24;
            this.dvgGetAllRecordsDetainedLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgGetAllRecordsDetainedLicense.Size = new System.Drawing.Size(1457, 319);
            this.dvgGetAllRecordsDetainedLicense.TabIndex = 39;
            this.dvgGetAllRecordsDetainedLicense.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dvgGetAllRecordsDetainedLicense_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.releaseDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(293, 108);
            // 
            // ShowPersonDetailsToolStripMenuItem
            // 
            this.ShowPersonDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ShowPersonDetailsToolStripMenuItem.Image")));
            this.ShowPersonDetailsToolStripMenuItem.Name = "ShowPersonDetailsToolStripMenuItem";
            this.ShowPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.ShowPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.ShowPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseDetailsToolStripMenuItem.Image")));
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showPersonLicenseHistoryToolStripMenuItem.Image")));
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // releaseDToolStripMenuItem
            // 
            this.releaseDToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("releaseDToolStripMenuItem.Image")));
            this.releaseDToolStripMenuItem.Name = "releaseDToolStripMenuItem";
            this.releaseDToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.releaseDToolStripMenuItem.Text = "Release Detained Licesne";
            this.releaseDToolStripMenuItem.Click += new System.EventHandler(this.releaseDToolStripMenuItem_Click);
            // 
            // lbInternationalDrivingLicenseApplication
            // 
            this.lbInternationalDrivingLicenseApplication.AutoSize = true;
            this.lbInternationalDrivingLicenseApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInternationalDrivingLicenseApplication.ForeColor = System.Drawing.Color.Red;
            this.lbInternationalDrivingLicenseApplication.Location = new System.Drawing.Point(569, 218);
            this.lbInternationalDrivingLicenseApplication.Name = "lbInternationalDrivingLicenseApplication";
            this.lbInternationalDrivingLicenseApplication.Size = new System.Drawing.Size(301, 36);
            this.lbInternationalDrivingLicenseApplication.TabIndex = 38;
            this.lbInternationalDrivingLicenseApplication.Text = "List Detain Licenses\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(617, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // btnRelease
            // 
            this.btnRelease.Image = ((System.Drawing.Image)(resources.GetObject("btnRelease.Image")));
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRelease.Location = new System.Drawing.Point(1270, 240);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(104, 85);
            this.btnRelease.TabIndex = 48;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // FormOfListDetainLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 708);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbRecordsNum);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.lbFilterBy);
            this.Controls.Add(this.dvgGetAllRecordsDetainedLicense);
            this.Controls.Add(this.lbInternationalDrivingLicenseApplication);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormOfListDetainLicenses";
            this.Text = "FormOfListDetainLicenses";
            this.Load += new System.EventHandler(this.FormOfListDetainLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetAllRecordsDetainedLicense)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbRecordsNum;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label lbFilterBy;
        private System.Windows.Forms.DataGridView dvgGetAllRecordsDetainedLicense;
        private System.Windows.Forms.Label lbInternationalDrivingLicenseApplication;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDToolStripMenuItem;
    }
}