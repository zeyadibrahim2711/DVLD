namespace DVLD_Ep1
{
    partial class FormOfLicenseHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfLicenseHistory));
            this.label1 = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnPersonSearch = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.lbFindBy = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbRecordsNum = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbRecords = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbNationalLicenseRecordNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.personDetalisUC1 = new DVLD_Ep1.PersonDetalisUC();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(603, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "License History";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnPersonSearch);
            this.gbFilter.Controls.Add(this.btnAddNewPerson);
            this.gbFilter.Controls.Add(this.tbFilterBy);
            this.gbFilter.Controls.Add(this.cbFilterBy);
            this.gbFilter.Controls.Add(this.lbFindBy);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(435, 61);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1009, 89);
            this.gbFilter.TabIndex = 83;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            this.gbFilter.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnPersonSearch
            // 
            this.btnPersonSearch.Image = global::DVLD_Ep1.Properties.Resources.SearchPerson1;
            this.btnPersonSearch.Location = new System.Drawing.Point(590, 19);
            this.btnPersonSearch.Name = "btnPersonSearch";
            this.btnPersonSearch.Size = new System.Drawing.Size(48, 48);
            this.btnPersonSearch.TabIndex = 13;
            this.btnPersonSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPersonSearch.UseVisualStyleBackColor = true;
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::DVLD_Ep1.Properties.Resources.AddPerson_322;
            this.btnAddNewPerson.Location = new System.Drawing.Point(660, 19);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(48, 48);
            this.btnAddNewPerson.TabIndex = 12;
            this.btnAddNewPerson.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterBy.Location = new System.Drawing.Point(370, 24);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(168, 34);
            this.tbFilterBy.TabIndex = 11;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Gender",
            "DateOfBirth",
            "Nationality",
            "Phone",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(155, 24);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(209, 37);
            this.cbFilterBy.TabIndex = 10;
            // 
            // lbFindBy
            // 
            this.lbFindBy.AutoSize = true;
            this.lbFindBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFindBy.Location = new System.Drawing.Point(23, 33);
            this.lbFindBy.Name = "lbFindBy";
            this.lbFindBy.Size = new System.Drawing.Size(84, 25);
            this.lbFindBy.TabIndex = 9;
            this.lbFindBy.Text = "Find By:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(93, 215);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 84;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(5, 495);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1439, 214);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver License";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1426, 193);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbRecordsNum);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvLocalLicenseHistory);
            this.tabPage1.Controls.Add(this.lbRecords);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1418, 164);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbRecordsNum
            // 
            this.lbRecordsNum.AutoSize = true;
            this.lbRecordsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsNum.Location = new System.Drawing.Point(125, 141);
            this.lbRecordsNum.Name = "lbRecordsNum";
            this.lbRecordsNum.Size = new System.Drawing.Size(39, 20);
            this.lbRecordsNum.TabIndex = 25;
            this.lbRecordsNum.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Local License History :\r\n";
            // 
            // dgvLocalLicenseHistory
            // 
            this.dgvLocalLicenseHistory.AllowUserToAddRows = false;
            this.dgvLocalLicenseHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicenseHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLocalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenseHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvLocalLicenseHistory.Location = new System.Drawing.Point(43, 26);
            this.dgvLocalLicenseHistory.Name = "dgvLocalLicenseHistory";
            this.dgvLocalLicenseHistory.ReadOnly = true;
            this.dgvLocalLicenseHistory.RowHeadersWidth = 51;
            this.dgvLocalLicenseHistory.RowTemplate.Height = 24;
            this.dgvLocalLicenseHistory.Size = new System.Drawing.Size(1307, 112);
            this.dgvLocalLicenseHistory.TabIndex = 0;
            this.dgvLocalLicenseHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 30);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseDetailsToolStripMenuItem.Image")));
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.showLicenseDetailsToolStripMenuItem.Text = "Show License Info";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(6, 141);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(113, 20);
            this.lbRecords.TabIndex = 24;
            this.lbRecords.Text = "# Records : ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbNationalLicenseRecordNum);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dgvInternationalLicenseHistory);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1418, 164);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "international";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbNationalLicenseRecordNum
            // 
            this.lbNationalLicenseRecordNum.AutoSize = true;
            this.lbNationalLicenseRecordNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNationalLicenseRecordNum.Location = new System.Drawing.Point(125, 124);
            this.lbNationalLicenseRecordNum.Name = "lbNationalLicenseRecordNum";
            this.lbNationalLicenseRecordNum.Size = new System.Drawing.Size(39, 20);
            this.lbNationalLicenseRecordNum.TabIndex = 26;
            this.lbNationalLicenseRecordNum.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "# Records : ";
            // 
            // dgvInternationalLicenseHistory
            // 
            this.dgvInternationalLicenseHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicenseHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenseHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInternationalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseHistory.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvInternationalLicenseHistory.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvInternationalLicenseHistory.Location = new System.Drawing.Point(39, 35);
            this.dgvInternationalLicenseHistory.Name = "dgvInternationalLicenseHistory";
            this.dgvInternationalLicenseHistory.ReadOnly = true;
            this.dgvInternationalLicenseHistory.RowHeadersWidth = 51;
            this.dgvInternationalLicenseHistory.RowTemplate.Height = 24;
            this.dgvInternationalLicenseHistory.Size = new System.Drawing.Size(1307, 86);
            this.dgvInternationalLicenseHistory.TabIndex = 3;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(215, 30);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(214, 26);
            this.toolStripMenuItem1.Text = "Show License Info";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "International License History :\r\n";
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1290, 715);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 41);
            this.button1.TabIndex = 86;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // personDetalisUC1
            // 
            this.personDetalisUC1.Location = new System.Drawing.Point(416, 156);
            this.personDetalisUC1.Name = "personDetalisUC1";
            this.personDetalisUC1.Size = new System.Drawing.Size(1028, 296);
            this.personDetalisUC1.TabIndex = 1;
            // 
            // FormOfLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1456, 762);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.personDetalisUC1);
            this.Controls.Add(this.label1);
            this.Name = "FormOfLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormOfLicenseHistory";
            this.Load += new System.EventHandler(this.FormOfLicenseHistory_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private PersonDetalisUC personDetalisUC1;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnPersonSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label lbFindBy;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvLocalLicenseHistory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbRecordsNum;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbNationalLicenseRecordNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}