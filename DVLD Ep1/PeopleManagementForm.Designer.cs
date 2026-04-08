namespace DVLD_Ep1
{
    partial class PeopleManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeopleManagementForm));
            this.lbManagePeople = new System.Windows.Forms.Label();
            this.dvgGetAllRecords = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbRecords = new System.Windows.Forms.Label();
            this.lbRecordsNum = new System.Windows.Forms.Label();
            this.lbFilterBy = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetAllRecords)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbManagePeople
            // 
            this.lbManagePeople.AutoSize = true;
            this.lbManagePeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManagePeople.ForeColor = System.Drawing.Color.Red;
            this.lbManagePeople.Location = new System.Drawing.Point(578, 233);
            this.lbManagePeople.Name = "lbManagePeople";
            this.lbManagePeople.Size = new System.Drawing.Size(223, 36);
            this.lbManagePeople.TabIndex = 1;
            this.lbManagePeople.Text = "Manage People";
            // 
            // dvgGetAllRecords
            // 
            this.dvgGetAllRecords.AllowUserToAddRows = false;
            this.dvgGetAllRecords.AllowUserToDeleteRows = false;
            this.dvgGetAllRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvgGetAllRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgGetAllRecords.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgGetAllRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgGetAllRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgGetAllRecords.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgGetAllRecords.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgGetAllRecords.Location = new System.Drawing.Point(12, 376);
            this.dvgGetAllRecords.Name = "dvgGetAllRecords";
            this.dvgGetAllRecords.ReadOnly = true;
            this.dvgGetAllRecords.RowHeadersWidth = 51;
            this.dvgGetAllRecords.RowTemplate.Height = 24;
            this.dvgGetAllRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgGetAllRecords.Size = new System.Drawing.Size(1470, 351);
            this.dvgGetAllRecords.TabIndex = 2;
            this.dvgGetAllRecords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgGetAllRecords_CellContentClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.showDetailsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 82);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_Ep1.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::DVLD_Ep1.Properties.Resources.Delete_32;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::DVLD_Ep1.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecords.Location = new System.Drawing.Point(21, 751);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(153, 29);
            this.lbRecords.TabIndex = 3;
            this.lbRecords.Text = "# Records : ";
            // 
            // lbRecordsNum
            // 
            this.lbRecordsNum.AutoSize = true;
            this.lbRecordsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordsNum.Location = new System.Drawing.Point(180, 751);
            this.lbRecordsNum.Name = "lbRecordsNum";
            this.lbRecordsNum.Size = new System.Drawing.Size(52, 29);
            this.lbRecordsNum.TabIndex = 4;
            this.lbRecordsNum.Text = "???";
            // 
            // lbFilterBy
            // 
            this.lbFilterBy.AutoSize = true;
            this.lbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFilterBy.Location = new System.Drawing.Point(21, 330);
            this.lbFilterBy.Name = "lbFilterBy";
            this.lbFilterBy.Size = new System.Drawing.Size(107, 29);
            this.lbFilterBy.TabIndex = 6;
            this.lbFilterBy.Text = "Filter By:";
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
            this.cbFilterBy.Location = new System.Drawing.Point(156, 326);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(209, 37);
            this.cbFilterBy.TabIndex = 7;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterBy.Location = new System.Drawing.Point(371, 325);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(168, 34);
            this.tbFilterBy.TabIndex = 8;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::DVLD_Ep1.Properties.Resources.Add_Person_40;
            this.btnAddNewPerson.Location = new System.Drawing.Point(1309, 316);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(104, 54);
            this.btnAddNewPerson.TabIndex = 9;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // button1
            // 
            this.button1.Image = global::DVLD_Ep1.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1259, 751);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(584, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PeopleManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 847);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.lbFilterBy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbRecordsNum);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.dvgGetAllRecords);
            this.Controls.Add(this.lbManagePeople);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PeopleManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PeopleManagementForm";
            this.Load += new System.EventHandler(this.PeopleManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgGetAllRecords)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbManagePeople;
        private System.Windows.Forms.DataGridView dvgGetAllRecords;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.Label lbRecordsNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
    }
}