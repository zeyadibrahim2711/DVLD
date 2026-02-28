using ApplicationsBusinessLayer;
using BusinessLayer;
using LicenseClassesBusinessLayer;
using LocalDrivingLicenseApplicationBuisnessLayer;
using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAppiontmentBusinessLayer;

namespace DVLD_Ep1
{
    public partial class SecudleTest : UserControl
    {
        private ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
      
        private ClsTestType _TestType;


        int trial = 0;
       
        int RTake = 5;

        
        public SecudleTest()
        {
            InitializeComponent();
        }

        public void LoadTestAppointmentInfo(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            gbRetakeTestInfo.Enabled = false;
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Local DrivingLicense Application with Local Driving License ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillTestAppointmentInfo(TestTypeID);
        }
        private void _FillTestAppointmentInfo(int TestTypeID)
        {
            _TestType = ClsTestType.Find(TestTypeID);
            switch (_TestType.TestTypeID)
            {
                case 1:
                    groupBox1.Text = _TestType.TestTypeTitle;
                    pictureBox1.Image = Properties.Resources.Vision_Test_32;
                   
                    break;

                case 2:
                    groupBox1.Text = "Written Test";
                    pictureBox1.Image = Properties.Resources.Written_Test_32;
                   
                    break;

                case 3:
                    groupBox1.Text = "Street Test";
                    pictureBox1.Image = Properties.Resources.Street_Test_32;
                  
                    break;

            }


            lbDLApplicationInSecTestControl.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbDClassinSecTestControl.Text = clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lbnameinSecTestControl.Text= clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID).FullName;
            lbFeesinSecTestControl.Text = _TestType.TestTypeFees.ToString();
            dtpDateOfTest.Format = DateTimePickerFormat.Custom;
            dtpDateOfTest.CustomFormat = "dd/MM/yyyy";
            //trial = ClsTestAppointment.CountTestExist(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,
            //    lbDClassinSecTestControl.Text,lbnameinSecTestControl.Text,_TestType.TestTypeID);
            if (trial>0)
            {
                gbRetakeTestInfo.Enabled = true;
                lbtrialinSecTestControl.Text = trial.ToString();
                lbRAppFeesInRetakeTest.Text = RTake.ToString();
                lbTotalFeesInRetakeTest.Text = (_TestType.TestTypeFees + RTake).ToString();
                lbRTestAppIDInRetakeTest.Text = "N/A";
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lbtrialinSecTestControl.Text ="0";
                lbRAppFeesInRetakeTest.Text = "0";
                lbTotalFeesInRetakeTest.Text = _TestType.TestTypeFees.ToString();
                lbRTestAppIDInRetakeTest.Text = "N/A";
            } 
        }

        private void SecudleTest_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    
    }
}
