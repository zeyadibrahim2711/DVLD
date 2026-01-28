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
            dvgApplicationTypes.DataSource = ClsApplicationTypes.GetAllApplicationTypes();
            lbRecordsNum.Text = ClsApplicationTypes.CountAllApplicationTypes().ToString();
        }
        private void FormOfApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
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
