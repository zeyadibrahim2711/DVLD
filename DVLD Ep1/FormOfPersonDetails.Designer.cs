namespace DVLD_Ep1
{
    partial class FormOfPersonDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.personDetalisUC1 = new DVLD_Ep1.PersonDetalisUC();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(313, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Details";
            // 
            // personDetalisUC1
            // 
            this.personDetalisUC1.Location = new System.Drawing.Point(3, 83);
            this.personDetalisUC1.Name = "personDetalisUC1";
            this.personDetalisUC1.Size = new System.Drawing.Size(917, 335);
            this.personDetalisUC1.TabIndex = 0;
            this.personDetalisUC1.Load += new System.EventHandler(this.personDetalisUC1_Load);
            // 
            // FormOfPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.personDetalisUC1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormOfPersonDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormOfPersonDetails";
            this.Load += new System.EventHandler(this.FormOfPersonDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersonDetalisUC personDetalisUC1;
        private System.Windows.Forms.Label label1;
    }
}