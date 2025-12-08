namespace DVLD_Ep1
{
    partial class UserDetailsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbUserId = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbIsActive = new System.Windows.Forms.Label();
            this.lbUseridinside = new System.Windows.Forms.Label();
            this.lbUserNameinside = new System.Windows.Forms.Label();
            this.lbIsActiveinside = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbIsActiveinside);
            this.groupBox1.Controls.Add(this.lbUserNameinside);
            this.groupBox1.Controls.Add(this.lbUseridinside);
            this.groupBox1.Controls.Add(this.lbIsActive);
            this.groupBox1.Controls.Add(this.lbUserName);
            this.groupBox1.Controls.Add(this.lbUserId);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(999, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // lbUserId
            // 
            this.lbUserId.AutoSize = true;
            this.lbUserId.Location = new System.Drawing.Point(69, 60);
            this.lbUserId.Name = "lbUserId";
            this.lbUserId.Size = new System.Drawing.Size(89, 22);
            this.lbUserId.TabIndex = 0;
            this.lbUserId.Text = "User ID :";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(428, 60);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(127, 22);
            this.lbUserName.TabIndex = 1;
            this.lbUserName.Text = "User Name : ";
            // 
            // lbIsActive
            // 
            this.lbIsActive.AutoSize = true;
            this.lbIsActive.Location = new System.Drawing.Point(787, 60);
            this.lbIsActive.Name = "lbIsActive";
            this.lbIsActive.Size = new System.Drawing.Size(98, 22);
            this.lbIsActive.TabIndex = 2;
            this.lbIsActive.Text = "Is Active :";
            // 
            // lbUseridinside
            // 
            this.lbUseridinside.AutoSize = true;
            this.lbUseridinside.Location = new System.Drawing.Point(217, 60);
            this.lbUseridinside.Name = "lbUseridinside";
            this.lbUseridinside.Size = new System.Drawing.Size(21, 22);
            this.lbUseridinside.TabIndex = 3;
            this.lbUseridinside.Text = "?";
            // 
            // lbUserNameinside
            // 
            this.lbUserNameinside.AutoSize = true;
            this.lbUserNameinside.Location = new System.Drawing.Point(582, 60);
            this.lbUserNameinside.Name = "lbUserNameinside";
            this.lbUserNameinside.Size = new System.Drawing.Size(21, 22);
            this.lbUserNameinside.TabIndex = 4;
            this.lbUserNameinside.Text = "?";
            // 
            // lbIsActiveinside
            // 
            this.lbIsActiveinside.AutoSize = true;
            this.lbIsActiveinside.Location = new System.Drawing.Point(900, 60);
            this.lbIsActiveinside.Name = "lbIsActiveinside";
            this.lbIsActiveinside.Size = new System.Drawing.Size(21, 22);
            this.lbIsActiveinside.TabIndex = 5;
            this.lbIsActiveinside.Text = "?";
            // 
            // UserDetailsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UserDetailsUC";
            this.Size = new System.Drawing.Size(1044, 272);
            this.Load += new System.EventHandler(this.UserDetailsUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbIsActive;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbUserId;
        private System.Windows.Forms.Label lbIsActiveinside;
        private System.Windows.Forms.Label lbUserNameinside;
        private System.Windows.Forms.Label lbUseridinside;
    }
}
