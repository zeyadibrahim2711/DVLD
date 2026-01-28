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
            dvgTestTypes.DataSource = ClsTestType.GetAllTestTypes();
            lbRecordsNum.Text = ClsTestType.Count().ToString();
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
