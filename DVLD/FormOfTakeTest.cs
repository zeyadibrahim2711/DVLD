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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAppiontmentBusinessLayer;
using static TestAppiontmentBusinessLayer.ClsTest;

namespace DVLD_Ep1
{
    public partial class FormOfTakeTest : Form
    {
       
        ClsTestAppointment _TestAppointment;
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsTest _Test;
        int _AppoinmentID;
        ClsTestType _TestType;

        private void SetIdentityOfForm()
        {
            switch (_TestType.TestTypeID)
            {
                case 1:
                   
                    pictureBox1.Image = Properties.Resources.Vision_Test_32;
                    label1.Text = "Vision Test Appointment";
                    return;
                case 2:
                  
                    pictureBox1.Image = Properties.Resources.Written_Test_32;
                    label1.Text = "Written Test Appointment";
                    return;
                case 3:
                   
                    pictureBox1.Image = Properties.Resources.Street_Test_32;
                    label1.Text = "Street Test Appointment";
                    return;
            }
        }
        private void _AddNewTest()
        {
            _Test.TestAppointmentID = _AppoinmentID;
            _Test.TestResult = (enTestResult)((rbFail.Checked == true) ? 0 : 1);
            _Test.Notes = string.IsNullOrWhiteSpace(tbNotes.Text) ? null : tbNotes.Text;
            _Test.CreatedByUserID = _LocalDrivingLicenseApplication.CreatedByUserID;
        }
        public FormOfTakeTest(int AppoinmentID, int TestTypeID)
        {
            InitializeComponent();
            _AppoinmentID = AppoinmentID;
            _TestAppointment = ClsTestAppointment.FindTestAppointmentByID(_AppoinmentID);
            _TestType = ClsTestType.Find(TestTypeID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Invalid Test Appointment ID");
                Close();
                return;
            }
        }
        public void LoadTestInfo()
        {
            SetIdentityOfForm();
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_TestAppointment.LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Local DrivingLicense Application with Local Driving License ApplicationID = " +
                    _TestAppointment.LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Test = new ClsTest();
            _FillTestInfo();
        }
        private void _FillTestInfo()
        {
            

            lbDLApplicationInSecTestControl.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbDClassinSecTestControl.Text = clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lbnameinSecTestControl.Text = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID).FullName;
            lbFeesinSecTestControl.Text = _TestType.TestTypeFees.ToString();
            dtpDateOfTest.Value = _TestAppointment.AppointmentDate;
            dtpDateOfTest.Format = DateTimePickerFormat.Custom;
            dtpDateOfTest.CustomFormat = "dd/MM/yyyy";
            lbtrialinSecTestControl.Text = ClsTest.GetTakenTestsCount(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,
          _TestAppointment.TestTypeID).ToString();
        }

        private void FormOfTakeTest_Load(object sender, EventArgs e)
        {
            LoadTestInfo();   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _AddNewTest();
            _TestAppointment.IsLocked = true;
            if (_Test.SaveTest()&&_TestAppointment.SaveTestAppointment())
            {
                MessageBox.Show("Data Saved Successfully.");
                lbTestIDInVTGB.Text = _Test.TestID.ToString();
            }

            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
