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
    public partial class FormOfInternationalLicenseInfo : Form
    {
        public FormOfInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            internationalDriverLicenseInfo1.LoadInternationalDriverLicenseInfo(InternationalLicenseID);
        }

        private void FormOfInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
