using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Ep1
{
    public partial class FormOfTestTypes : Form
    {
        public FormOfTestTypes()
        {
            InitializeComponent();
        }
        private void _RefreshTestTypesList()
        {
            DataTable dt = ClsTestType.GetAllTestTypes();
            dvgTestTypes.DataSource = dt;
            lbRecordsNum.Text = dt.Rows.Count.ToString();
        }


        private void FormOfTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
