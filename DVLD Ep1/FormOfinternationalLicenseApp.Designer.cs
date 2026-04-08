namespace DVLD_Ep1
{
    partial class FormOfinternationalLicenseApp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfinternationalLicenseApp));
            this.lbRecordsNum = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.lbFilterBy = new System.Windows.Forms.Label();
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbInternationalDrivingLicenseApplication = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewInternationalDrivingLicenseApplication = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetAllRecordsForInternationalDrivingLicenseApplication)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRecordsNum
            // 
            this.lbRecordsNum.AutoSize = true;
            this.lbRecordsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsNum.Location = new System.Drawing.Point(192, 682);
            this.lbRecordsNum.Name = "lbRecordsNum";
            this.lbRecordsNum.Size = new System.Drawing.Size(52, 29);
            this.lbRecordsNum.TabIndex = 33;
            this.lbRecordsNum.Text = "???";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(33, 682);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(153, 29);
            this.lbRecords.TabIndex = 32;
            this.lbRecords.Text = "# Records : ";
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterBy.Location = new System.Drawing.Point(383, 301);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(168, 34);
            this.tbFilterBy.TabIndex = 31;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Int.License ID",
            "Application ID",
            "DriverID",
            "L.Licesne ID",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(168, 302);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(209, 37);
            this.cbFilterBy.TabIndex = 30;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // lbFilterBy
            // 
            this.lbFilterBy.AutoSize = true;
            this.lbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilterBy.Location = new System.Drawing.Point(33, 306);
            this.lbFilterBy.Name = "lbFilterBy";
            this.lbFilterBy.Size = new System.Drawing.Size(107, 29);
            this.lbFilterBy.TabIndex = 29;
            this.lbFilterBy.Text = "Filter By:";
            // 
            // dvgGetAllRecordsForInternationalDrivingLicenseApplication
            // 
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.AllowUserToAddRows = false;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.AllowUserToDeleteRows = false;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.Location = new System.Drawing.Point(24, 348);
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.MultiSelect = false;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.Name = "dvgGetAllRecordsForInternationalDrivingLicenseApplication";
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.ReadOnly = true;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.RowHeadersWidth = 51;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.RowTemplate.Height = 24;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.Size = new System.Drawing.Size(1457, 319);
            this.dvgGetAllRecordsForInternationalDrivingLicenseApplication.TabIndex = 28;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(293, 82);
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
            // lbInternationalDrivingLicenseApplication
            // 
            this.lbInternationalDrivingLicenseApplication.AutoSize = true;
            this.lbInternationalDrivingLicenseApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInternationalDrivingLicenseApplication.ForeColor = System.Drawing.Color.Red;
            this.lbInternationalDrivingLicenseApplication.Location = new System.Drawing.Point(458, 229);
            this.lbInternationalDrivingLicenseApplication.Name = "lbInternationalDrivingLicenseApplication";
            this.lbInternationalDrivingLicenseApplication.Size = new System.Drawing.Size(549, 36);
            this.lbInternationalDrivingLicenseApplication.TabIndex = 27;
            this.lbInternationalDrivingLicenseApplication.Text = "International Driving License Application";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(814, 113);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 50);
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1319, 680);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 41);
            this.button1.TabIndex = 34;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(586, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewInternationalDrivingLicenseApplication
            // 
            this.btnAddNewInternationalDrivingLicenseApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewInternationalDrivingLicenseApplication.Image")));
            this.btnAddNewInternationalDrivingLicenseApplication.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddNewInternationalDrivingLicenseApplication.Location = new System.Drawing.Point(1377, 257);
            this.btnAddNewInternationalDrivingLicenseApplication.Name = "btnAddNewInternationalDrivingLicenseApplication";
            this.btnAddNewInternationalDrivingLicenseApplication.Size = new System.Drawing.Size(104, 85);
            this.btnAddNewInternationalDrivingLicenseApplication.TabIndex = 36;
            this.btnAddNewInternationalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewInternationalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewInternationalDrivingLicenseApplication_Click);
            // 
            // FormOfinternationalLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1504, 737);
            this.Controls.Add(this.btnAddNewInternationalDrivingLicenseApplication);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbRecordsNum);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.lbFilterBy);
            this.Controls.Add(this.dvgGetAllRecordsForInternationalDrivingLicenseApplication);
            this.Controls.Add(this.lbInternationalDrivingLicenseApplication);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormOfinternationalLicenseApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormOfinternationalLicenseApp";
            this.Load += new System.EventHandler(this.FormOfinternationalLicenseApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetAllRecordsForInternationalDrivingLicenseApplication)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbRecordsNum;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label lbFilterBy;
        private System.Windows.Forms.DataGridView dvgGetAllRecordsForInternationalDrivingLicenseApplication;
        private System.Windows.Forms.Label lbInternationalDrivingLicenseApplication;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewInternationalDrivingLicenseApplication;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}