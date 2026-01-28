namespace DVLD_Ep1
{
    partial class FormOfChangePassword
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.userDetailsUC1 = new DVLD_Ep1.UserDetailsUC();
            this.personDetalisUC1 = new DVLD_Ep1.PersonDetalisUC();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbCurrentPassword = new System.Windows.Forms.TextBox();
            this.lbNewPaswword = new System.Windows.Forms.Label();
            this.lbCurrentPassword = new System.Windows.Forms.Label();
            this.tbConfirmNewPassword = new System.Windows.Forms.TextBox();
            this.lbConfirmPassword = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(458, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(0, 29);
            this.lbTitle.TabIndex = 23;
            // 
            // userDetailsUC1
            // 
            this.userDetailsUC1.Location = new System.Drawing.Point(36, 326);
            this.userDetailsUC1.Name = "userDetailsUC1";
            this.userDetailsUC1.Size = new System.Drawing.Size(1028, 234);
            this.userDetailsUC1.TabIndex = 22;
            // 
            // personDetalisUC1
            // 
            this.personDetalisUC1.Location = new System.Drawing.Point(36, 7);
            this.personDetalisUC1.Name = "personDetalisUC1";
            this.personDetalisUC1.Size = new System.Drawing.Size(1011, 335);
            this.personDetalisUC1.TabIndex = 21;
            this.personDetalisUC1.Load += new System.EventHandler(this.personDetalisUC1_Load);
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewPassword.Location = new System.Drawing.Point(323, 645);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(212, 28);
            this.tbNewPassword.TabIndex = 83;
            this.tbNewPassword.UseSystemPasswordChar = true;
            // 
            // tbCurrentPassword
            // 
            this.tbCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCurrentPassword.Location = new System.Drawing.Point(323, 587);
            this.tbCurrentPassword.Name = "tbCurrentPassword";
            this.tbCurrentPassword.Size = new System.Drawing.Size(212, 28);
            this.tbCurrentPassword.TabIndex = 82;
            this.tbCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lbNewPaswword
            // 
            this.lbNewPaswword.AutoSize = true;
            this.lbNewPaswword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNewPaswword.Location = new System.Drawing.Point(58, 650);
            this.lbNewPaswword.Name = "lbNewPaswword";
            this.lbNewPaswword.Size = new System.Drawing.Size(169, 20);
            this.lbNewPaswword.TabIndex = 81;
            this.lbNewPaswword.Text = "    New Password :\r\n";
            // 
            // lbCurrentPassword
            // 
            this.lbCurrentPassword.AutoSize = true;
            this.lbCurrentPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentPassword.Location = new System.Drawing.Point(58, 587);
            this.lbCurrentPassword.Name = "lbCurrentPassword";
            this.lbCurrentPassword.Size = new System.Drawing.Size(172, 20);
            this.lbCurrentPassword.TabIndex = 80;
            this.lbCurrentPassword.Text = "Current Password :";
            // 
            // tbConfirmNewPassword
            // 
            this.tbConfirmNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmNewPassword.Location = new System.Drawing.Point(323, 707);
            this.tbConfirmNewPassword.Name = "tbConfirmNewPassword";
            this.tbConfirmNewPassword.Size = new System.Drawing.Size(212, 28);
            this.tbConfirmNewPassword.TabIndex = 85;
            this.tbConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // lbConfirmPassword
            // 
            this.lbConfirmPassword.AutoSize = true;
            this.lbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfirmPassword.Location = new System.Drawing.Point(58, 715);
            this.lbConfirmPassword.Name = "lbConfirmPassword";
            this.lbConfirmPassword.Size = new System.Drawing.Size(175, 20);
            this.lbConfirmPassword.TabIndex = 84;
            this.lbConfirmPassword.Text = "Confirm Password :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DVLD_Ep1.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1053, 711);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(154, 41);
            this.btnSave.TabIndex = 79;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(893, 712);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 41);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Ep1.Properties.Resources.Number_32;
            this.pictureBox3.Location = new System.Drawing.Point(253, 577);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 38);
            this.pictureBox3.TabIndex = 142;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Ep1.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(253, 707);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 38);
            this.pictureBox1.TabIndex = 143;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Ep1.Properties.Resources.Number_32;
            this.pictureBox2.Location = new System.Drawing.Point(253, 635);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 38);
            this.pictureBox2.TabIndex = 144;
            this.pictureBox2.TabStop = false;
            // 
            // FormOfChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 791);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.tbConfirmNewPassword);
            this.Controls.Add(this.lbConfirmPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.tbCurrentPassword);
            this.Controls.Add(this.lbNewPaswword);
            this.Controls.Add(this.lbCurrentPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.userDetailsUC1);
            this.Controls.Add(this.personDetalisUC1);
            this.Name = "FormOfChangePassword";
            this.Text = "FormOfChangePassword";
            this.Load += new System.EventHandler(this.FormOfChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbTitle;
        private UserDetailsUC userDetailsUC1;
        private PersonDetalisUC personDetalisUC1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbCurrentPassword;
        private System.Windows.Forms.Label lbNewPaswword;
        private System.Windows.Forms.Label lbCurrentPassword;
        private System.Windows.Forms.TextBox tbConfirmNewPassword;
        private System.Windows.Forms.Label lbConfirmPassword;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}