using ApplicationsBusinessLayer;
using ApplicationTyoesBusinessLayer;
using BusinessLayer;
using CountriesBusinessLayer;
using LicenseClassesBusinessLayer;
using LocalDrivingLicenseApplicationBuisnessLayer;
using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAppiontmentBusinessLayer;

namespace DVLD_Ep1
{
    

    public partial class FormOfSechudleVisionTest : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        ClsTestAppointment _TestAppointment;
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsApplication _RetakeTestApplocation;
        int _LocalDrivingLicenseApplicationID;
        int _TestTypeID;
        int _AppoinmentID;
        ClsTestType _TestType;
        bool IsTestFound = false;
        bool ReAfterFail = false;
        decimal _ReTakeFees = 0;
        int Trial = 0;

        

        public FormOfSechudleVisionTest(int LocalDrivingLicenseApplicationID,int TestTypeID, int AppoinmentID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppoinmentID = AppoinmentID;
            _ReTakeFees = ClsApplicationTypes.Find((int)ClsApplicationTypes.enApplicationType.RetakeTest).Fees;

            if (_AppoinmentID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
                _Mode = enMode.Update;
        }

        private void SetIdentityOfForm()
        {
            switch (_TestType.TestTypeID)
            {
                case 1:
                    Text = "Sechudle Vision Test Appointment";
                    pictureBox1.Image = Properties.Resources.Vision_Test_32;
                    groupBox1.Text = "Vision Test ";
                    return;
                case 2:
                    Text = "Sechudle Written Test Appointment";
                    pictureBox1.Image = Properties.Resources.Written_Test_32;
                    groupBox1.Text = "Written Test ";
                    return;
                case 3:
                    Text = "Sechudle Street Test Appointment";
                    pictureBox1.Image = Properties.Resources.Street_Test_32;
                    groupBox1.Text = "Street Test ";
                    return;
            }
        }


        private void SetRetakeUI(bool enabled)
        {
            gbRetakeTestInfo.Enabled = enabled;
            if (enabled)
            {
                lbRAppFeesInRetakeTest.Text = _ReTakeFees.ToString("0.00");
                lbTotalFeesInRetakeTest.Text =
                    (_TestType.TestTypeFees + _ReTakeFees).ToString("0.00");

                var last = ClsTestAppointment.FindLatestTestAppointmentForLocalIDAndTestTypeID(_LocalDrivingLicenseApplicationID,_TestType.TestTypeID);

                if (last != null)
                    dtpDateOfTest.Value = last.AppointmentDate.AddDays(1);
            }
            else
            {
                lbRAppFeesInRetakeTest.Text = "0";
                lbTotalFeesInRetakeTest.Text =
                    _TestType.TestTypeFees.ToString("0.00");
            }

            lbRTestAppIDInRetakeTest.Text = "N/A";
        }


        private void LoadTestAppointmentInfo()
        {
           
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Local DrivingLicense Application with Local Driving License ApplicationID = " +
                    _LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TestType = ClsTestType.Find(_TestTypeID);
         
            if (_Mode == enMode.Update)
            {
                _TestAppointment = ClsTestAppointment.FindTestAppointmentByID(_AppoinmentID);
            }

            if (_Mode == enMode.AddNew)
            {
                _TestAppointment = new ClsTestAppointment();
               
            }

            _FillStaticInfo();
            _HandleTestState();

        }
        private void _FillStaticInfo()
        {
            SetIdentityOfForm(); 
            lbDLApplicationInSecTestControl.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbDClassinSecTestControl.Text = clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lbnameinSecTestControl.Text = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID).FullName;
            lbFeesinSecTestControl.Text = _TestType.TestTypeFees.ToString("0.00");
            dtpDateOfTest.Format = DateTimePickerFormat.Custom;
            dtpDateOfTest.CustomFormat = "dd/MM/yyyy";
            lbtrialinSecTestControl.Text =ClsTest.GetTakenTestsCount(
          _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,_TestType.TestTypeID ).ToString();
        }
        private void LockUI()
        {
            lbHeadLineST.Text = "Schedule Retake Test";
            lbDetailsST.Text = "Person already sat for the test, appointment locked";
            dtpDateOfTest.Enabled = false;
            btnSave.Enabled = false;
        }
        private void _HandleTestState()
        {
            if (_TestAppointment.IsLocked)
            {
                LockUI();
                return;
            }
            bool testPassed =   ClsTest.IsTestPassedByLocalIDandTestType(_LocalDrivingLicenseApplicationID,_TestType.TestTypeID);
            if (testPassed&&_Mode==enMode.AddNew)
            {
                lbHeadLineST.Text = "Secudle Retake Test ";
                ReAfterFail = true;
                _RetakeTestApplocation = new ClsApplication();
                SetRetakeUI(true);
            }
            if (!ReAfterFail)
            {
                lbRAppFeesInRetakeTest.Text = "0";
                lbTotalFeesInRetakeTest.Text = (_TestType.TestTypeFees + 0).ToString();
            }
          
            IsTestFound = ClsTest.IsTestExistByAppointmentID(_AppoinmentID);
        
           
            if (IsTestFound)
            {
                gbRetakeTestInfo.Enabled = true;
                SetRetakeUI(true);
            }
            if (!IsTestFound&&!ReAfterFail)
            {
                SetRetakeUI(false);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _TestAppointment.TestTypeID = _TestType.TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpDateOfTest.Value;
            _TestAppointment.PaidFees = _TestType.TestTypeFees;
            _TestAppointment.CreatedByUserID = _LocalDrivingLicenseApplication.CreatedByUserID;
            _TestAppointment.IsLocked = false;

            bool isSaved = false;

            if (ReAfterFail)
            {
                _RetakeTestApplocation.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                _RetakeTestApplocation.ApplicationDate =DateTime.Now;
                _RetakeTestApplocation.ApplicationTypeID = 7;
                _RetakeTestApplocation.ApplicationStatus = ClsApplication.enApplicationStatus.New;
                _RetakeTestApplocation.LastStatusDate = DateTime.Now;
                _RetakeTestApplocation.PaidFees = _TestType.TestTypeFees + _ReTakeFees;
                _RetakeTestApplocation.CreatedByUserID = _LocalDrivingLicenseApplication.CreatedByUserID;
                isSaved = _TestAppointment.SaveTestAppointment() &&
              _RetakeTestApplocation.SaveApplication();

            }
            else
            {
                isSaved = _TestAppointment.SaveTestAppointment();
            }

            if (isSaved)

            {
                _AppoinmentID = _TestAppointment.TestAppointmentID;
                MessageBox.Show("Data Saved Successfully.");

                if (ReAfterFail)
                    lbRTestAppIDInRetakeTest.Text = _RetakeTestApplocation.ApplicationID.ToString();

            }

            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }
            

            _Mode = enMode.Update;
         
        }

        private void FormOfSechudleVisionTest_Load(object sender, EventArgs e)
        {
            LoadTestAppointmentInfo();
        }
    }
}
