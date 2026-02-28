using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationTyoesBusinessLayer;

namespace DVLD_Ep1
{
    public partial class FormOfApplicationTypes : Form
    {
        public FormOfApplicationTypes()
        {
            InitializeComponent();
        }
        private void _RefreshApplicationTypesList()
        {
            DataTable dt = ClsApplicationTypes.GetAllApplicationTypes();
            dvgApplicationTypes.DataSource = dt;
            lbRecordsNum.Text = dt.Rows.Count.ToString();
        }
        private void FormOfApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
            dvgApplicationTypes.AutoSize = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfUpdateApplicationType frm = new FormOfUpdateApplicationType((int)dvgApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }
    }
}
