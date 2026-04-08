namespace DVLD_Ep1
{
    partial class FormOfUserDetails
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
            this.button1 = new System.Windows.Forms.Button();
            this.userDetailsUC1 = new DVLD_Ep1.UserDetailsUC();
            this.personDetalisUC1 = new DVLD_Ep1.PersonDetalisUC();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(416, 55);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(0, 29);
            this.lbTitle.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(851, 689);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 41);
            this.button1.TabIndex = 20;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // userDetailsUC1
            // 
            this.userDetailsUC1.Location = new System.Drawing.Point(12, 458);
            this.userDetailsUC1.Name = "userDetailsUC1";
            this.userDetailsUC1.Size = new System.Drawing.Size(1028, 234);
            this.userDetailsUC1.TabIndex = 2;
            this.userDetailsUC1.Load += new System.EventHandler(this.userDetailsUC1_Load);
            // 
            // personDetalisUC1
            // 
            this.personDetalisUC1.Location = new System.Drawing.Point(29, 126);
            this.personDetalisUC1.Name = "personDetalisUC1";
            this.personDetalisUC1.Size = new System.Drawing.Size(1011, 335);
            this.personDetalisUC1.TabIndex = 1;
            this.personDetalisUC1.Load += new System.EventHandler(this.personDetalisUC1_Load);
            // 
            // FormOfUserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 787);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.userDetailsUC1);
            this.Controls.Add(this.personDetalisUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormOfUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormOfUserDetails";
            this.Load += new System.EventHandler(this.FormOfUserDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersonDetalisUC personDetalisUC1;
        private UserDetailsUC userDetailsUC1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button button1;
    }
}