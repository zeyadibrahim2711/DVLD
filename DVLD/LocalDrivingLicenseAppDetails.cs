using LicenseClassesBusinessLayer;
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
    public partial class LocalDrivingLicenseAppDetails : UserControl
    {
        private ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public LocalDrivingLicenseAppDetails()
        {
            InitializeComponent();
        }

        public void LoadLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByIDForControl(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication==null)
            {
                MessageBox.Show("No Local DrivingLicense Application with Local Driving License ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();

        }
        private void _FillLocalDrivingLicenseApplicationInfo ()
        {
            lbDLApplicationInControl.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbInAppliedForLicenseControl.Text = clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lbPassedTestsinControl.Text = _LocalDrivingLicenseApplication.PassedTests.ToString() + "/3";
        }


        private void LocalDrivingLicenseAppDetails_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
