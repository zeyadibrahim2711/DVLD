using LocalDrivingLicenseApplicationBuisnessLayer;
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
    public partial class FormOfInfoOfLocalDrivingLicenseApplication : Form
    {
      
        public FormOfInfoOfLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID,int ApplicationID)
        {

            InitializeComponent();
            localDrivingLicenseAppDetails1.LoadLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
            applicationBasicDetails1.LoadApplicationBasic(ApplicationID);
            
        }

        private void FormOfInfoOfLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

        }

        private void localDrivingLicenseAppDetails1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applicationBasicDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
