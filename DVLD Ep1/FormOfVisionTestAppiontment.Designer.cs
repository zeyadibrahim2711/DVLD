namespace DVLD_Ep1
{
    partial class VisionTestAppiontment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisionTestAppiontment));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dvgGetLatestTestAppiontment = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbRecordsNum = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.applicationBasicDetails1 = new DVLD_Ep1.ApplicationBasicDetails();
            this.localDrivingLicenseAppDetails1 = new DVLD_Ep1.LocalDrivingLicenseAppDetails();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetLatestTestAppiontment)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Location = new System.Drawing.Point(596, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vision Test Appointment";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appointments";
            // 
            // dvgGetLatestTestAppiontment
            // 
            this.dvgGetLatestTestAppiontment.AllowUserToAddRows = false;
            this.dvgGetLatestTestAppiontment.AllowUserToDeleteRows = false;
            this.dvgGetLatestTestAppiontment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvgGetLatestTestAppiontment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgGetLatestTestAppiontment.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dvgGetLatestTestAppiontment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgGetLatestTestAppiontment.ContextMenuStrip = this.contextMenuStrip1;
            this.dvgGetLatestTestAppiontment.Location = new System.Drawing.Point(125, 622);
            this.dvgGetLatestTestAppiontment.MultiSelect = false;
            this.dvgGetLatestTestAppiontment.Name = "dvgGetLatestTestAppiontment";
            this.dvgGetLatestTestAppiontment.ReadOnly = true;
            this.dvgGetLatestTestAppiontment.RowHeadersWidth = 51;
            this.dvgGetLatestTestAppiontment.RowTemplate.Height = 24;
            this.dvgGetLatestTestAppiontment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgGetLatestTestAppiontment.Size = new System.Drawing.Size(1250, 146);
            this.dvgGetLatestTestAppiontment.TabIndex = 19;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 56);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.takeTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("takeTestToolStripMenuItem.Image")));
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test ";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // lbRecordsNum
            // 
            this.lbRecordsNum.AutoSize = true;
            this.lbRecordsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsNum.Location = new System.Drawing.Point(159, 753);
            this.lbRecordsNum.Name = "lbRecordsNum";
            this.lbRecordsNum.Size = new System.Drawing.Size(52, 29);
            this.lbRecordsNum.TabIndex = 26;
            this.lbRecordsNum.Text = "???";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(12, 751);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(153, 29);
            this.lbRecords.TabIndex = 25;
            this.lbRecords.Text = "# Records : ";
            // 
            // button2
            // 
            this.button2.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1282, 751);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 41);
            this.button2.TabIndex = 27;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAppointment.Image")));
            this.btnAddAppointment.Location = new System.Drawing.Point(1282, 557);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(66, 59);
            this.btnAddAppointment.TabIndex = 5;
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            this.btnAddAppointment.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(690, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // applicationBasicDetails1
            // 
            this.applicationBasicDetails1.Location = new System.Drawing.Point(104, 262);
            this.applicationBasicDetails1.Name = "applicationBasicDetails1";
            this.applicationBasicDetails1.Size = new System.Drawing.Size(1290, 293);
            this.applicationBasicDetails1.TabIndex = 29;
            // 
            // localDrivingLicenseAppDetails1
            // 
            this.localDrivingLicenseAppDetails1.Location = new System.Drawing.Point(104, 117);
            this.localDrivingLicenseAppDetails1.Name = "localDrivingLicenseAppDetails1";
            this.localDrivingLicenseAppDetails1.Size = new System.Drawing.Size(1289, 150);
            this.localDrivingLicenseAppDetails1.TabIndex = 28;
            // 
            // VisionTestAppiontment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 894);
            this.Controls.Add(this.applicationBasicDetails1);
            this.Controls.Add(this.localDrivingLicenseAppDetails1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbRecordsNum);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.dvgGetLatestTestAppiontment);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VisionTestAppiontment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vision Test Appiontment";
            this.Load += new System.EventHandler(this.VisionTestAppiontment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetLatestTestAppiontment)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.DataGridView dvgGetLatestTestAppiontment;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbRecordsNum;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private LocalDrivingLicenseAppDetails localDrivingLicenseAppDetails1;
        private ApplicationBasicDetails applicationBasicDetails1;
    }
}