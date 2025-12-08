namespace ClacUserControl
{
    partial class Form1
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnShowReslut = new System.Windows.Forms.Button();
            this.calculatorUC3 = new ClacUserControl.CalculatorUC();
            this.calculatorUC2 = new ClacUserControl.CalculatorUC();
            this.calculatorUC1 = new ClacUserControl.CalculatorUC();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1215, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 63);
            this.button1.TabIndex = 3;
            this.button1.Text = "Hide ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1215, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 63);
            this.button2.TabIndex = 4;
            this.button2.Text = "Show";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnShowReslut
            // 
            this.btnShowReslut.Location = new System.Drawing.Point(1215, 354);
            this.btnShowReslut.Name = "btnShowReslut";
            this.btnShowReslut.Size = new System.Drawing.Size(114, 63);
            this.btnShowReslut.TabIndex = 5;
            this.btnShowReslut.Text = "Show Result";
            this.btnShowReslut.UseVisualStyleBackColor = true;
            this.btnShowReslut.Click += new System.EventHandler(this.btnShowReslut_Click);
            // 
            // calculatorUC3
            // 
            this.calculatorUC3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculatorUC3.Location = new System.Drawing.Point(52, 350);
            this.calculatorUC3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculatorUC3.Name = "calculatorUC3";
            this.calculatorUC3.Size = new System.Drawing.Size(1309, 190);
            this.calculatorUC3.TabIndex = 2;
            // 
            // calculatorUC2
            // 
            this.calculatorUC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculatorUC2.Location = new System.Drawing.Point(64, 195);
            this.calculatorUC2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculatorUC2.Name = "calculatorUC2";
            this.calculatorUC2.Size = new System.Drawing.Size(1307, 170);
            this.calculatorUC2.TabIndex = 1;
            // 
            // calculatorUC1
            // 
            this.calculatorUC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculatorUC1.Location = new System.Drawing.Point(64, 48);
            this.calculatorUC1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.calculatorUC1.Name = "calculatorUC1";
            this.calculatorUC1.Size = new System.Drawing.Size(1297, 207);
            this.calculatorUC1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 789);
            this.Controls.Add(this.btnShowReslut);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.calculatorUC3);
            this.Controls.Add(this.calculatorUC2);
            this.Controls.Add(this.calculatorUC1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private CalculatorUC calculatorUC1;
        private CalculatorUC calculatorUC2;
        private CalculatorUC calculatorUC3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnShowReslut;
    }
}

