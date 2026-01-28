namespace DVLD_Ep1
{
    partial class FormOfInfoOfLocalDrivingLicenseApplication
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
            this.button1 = new System.Windows.Forms.Button();
            this.lbShowLDLAInfo = new System.Windows.Forms.Label();
            this.applicationBasicDetails1 = new DVLD_Ep1.ApplicationBasicDetails();
            this.localDrivingLicenseAppDetails1 = new DVLD_Ep1.LocalDrivingLicenseAppDetails();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1207, 686);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 62);
            this.button1.TabIndex = 25;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbShowLDLAInfo
            // 
            this.lbShowLDLAInfo.AutoSize = true;
            this.lbShowLDLAInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShowLDLAInfo.ForeColor = System.Drawing.Color.Red;
            this.lbShowLDLAInfo.Location = new System.Drawing.Point(386, 9);
            this.lbShowLDLAInfo.Name = "lbShowLDLAInfo";
            this.lbShowLDLAInfo.Size = new System.Drawing.Size(639, 39);
            this.lbShowLDLAInfo.TabIndex = 26;
            this.lbShowLDLAInfo.Text = "Show Local Driving Application Details";
            // 
            // applicationBasicDetails1
            // 
            this.applicationBasicDetails1.Location = new System.Drawing.Point(25, 237);
            this.applicationBasicDetails1.Name = "applicationBasicDetails1";
            this.applicationBasicDetails1.Size = new System.Drawing.Size(1336, 443);
            this.applicationBasicDetails1.TabIndex = 1;
            this.applicationBasicDetails1.Load += new System.EventHandler(this.applicationBasicDetails1_Load);
            // 
            // localDrivingLicenseAppDetails1
            // 
            this.localDrivingLicenseAppDetails1.Location = new System.Drawing.Point(25, 22);
            this.localDrivingLicenseAppDetails1.Name = "localDrivingLicenseAppDetails1";
            this.localDrivingLicenseAppDetails1.Size = new System.Drawing.Size(1281, 230);
            this.localDrivingLicenseAppDetails1.TabIndex = 0;
            this.localDrivingLicenseAppDetails1.Load += new System.EventHandler(this.localDrivingLicenseAppDetails1_Load);
            // 
            // FormOfInfoOfLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 760);
            this.Controls.Add(this.lbShowLDLAInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.applicationBasicDetails1);
            this.Controls.Add(this.localDrivingLicenseAppDetails1);
            this.Name = "FormOfInfoOfLocalDrivingLicenseApplication";
            this.Text = "FormOfInfoOfLocalDrivingLicenseApplication";
            this.Load += new System.EventHandler(this.FormOfInfoOfLocalDrivingLicenseApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LocalDrivingLicenseAppDetails localDrivingLicenseAppDetails1;
        private ApplicationBasicDetails applicationBasicDetails1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbShowLDLAInfo;
    }
}