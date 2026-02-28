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
    public partial class FormOfLicenseInfo : Form
    {
        public FormOfLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            driverLicenseDetailsUC1.LoadDriverLicenseInfo(LicenseID);
        }

        private void driverLicenseDetailsUC1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOfLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
