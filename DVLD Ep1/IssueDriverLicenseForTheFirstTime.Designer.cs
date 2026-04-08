namespace DVLD_Ep1
{
    partial class Issue_Driver_License_For_The_First_Time
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Issue_Driver_License_For_The_First_Time));
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.lbNotes = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.applicationBasicDetails1 = new DVLD_Ep1.ApplicationBasicDetails();
            this.localDrivingLicenseAppDetails1 = new DVLD_Ep1.LocalDrivingLicenseAppDetails();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(278, 562);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(515, 30);
            this.tbNotes.TabIndex = 124;
            // 
            // lbNotes
            // 
            this.lbNotes.AutoSize = true;
            this.lbNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNotes.Location = new System.Drawing.Point(48, 569);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(64, 20);
            this.lbNotes.TabIndex = 122;
            this.lbNotes.Text = "Notes:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(958, 665);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnClose.Size = new System.Drawing.Size(153, 36);
            this.btnClose.TabIndex = 126;
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Image = ((System.Drawing.Image)(resources.GetObject("btnIssue.Image")));
            this.btnIssue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssue.Location = new System.Drawing.Point(1137, 665);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnIssue.Size = new System.Drawing.Size(153, 36);
            this.btnIssue.TabIndex = 125;
            this.btnIssue.Text = "  Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(219, 557);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(37, 35);
            this.pictureBox9.TabIndex = 123;
            this.pictureBox9.TabStop = false;
            // 
            // applicationBasicDetails1
            // 
            this.applicationBasicDetails1.Location = new System.Drawing.Point(36, 247);
            this.applicationBasicDetails1.Name = "applicationBasicDetails1";
            this.applicationBasicDetails1.Size = new System.Drawing.Size(1290, 293);
            this.applicationBasicDetails1.TabIndex = 1;
            this.applicationBasicDetails1.Load += new System.EventHandler(this.applicationBasicDetails1_Load);
            // 
            // localDrivingLicenseAppDetails1
            // 
            this.localDrivingLicenseAppDetails1.Location = new System.Drawing.Point(12, 53);
            this.localDrivingLicenseAppDetails1.Name = "localDrivingLicenseAppDetails1";
            this.localDrivingLicenseAppDetails1.Size = new System.Drawing.Size(1289, 150);
            this.localDrivingLicenseAppDetails1.TabIndex = 0;
            // 
            // Issue_Driver_License_For_The_First_Time
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 713);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.lbNotes);
            this.Controls.Add(this.applicationBasicDetails1);
            this.Controls.Add(this.localDrivingLicenseAppDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Issue_Driver_License_For_The_First_Time";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Issue Driver License For The First Time";
            this.Load += new System.EventHandler(this.Issue_Driver_License_For_The_First_Time_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LocalDrivingLicenseAppDetails localDrivingLicenseAppDetails1;
        private ApplicationBasicDetails applicationBasicDetails1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lbNotes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
    }
}