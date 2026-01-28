using LocalDrivingLicenseApplicationBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Ep1
{
    public partial class VisionTestAppiontment : Form
    {
        private ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public VisionTestAppiontment(int LocalDrivingLicenseApplicationID, int ApplicationID)
        {
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByIDForControl(LocalDrivingLicenseApplicationID);
            InitializeComponent();
            localDrivingLicenseAppDetails1.LoadLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
            applicationBasicDetails1.LoadApplicationBasic(ApplicationID);
        }

        private void applicationBasicDetails1_Load(object sender, EventArgs e)
        {

        }

        private void dvgGetLatestTestAppiontment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VisionTestAppiontment_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOfSechudleVisionTest frm = new FormOfSechudleVisionTest(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, 1);
            frm.Show();
        }
    }
}
