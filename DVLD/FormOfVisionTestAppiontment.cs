using BusinessLayer;
using LicenseClassesBusinessLayer;
using LocalDrivingLicenseApplicationBuisnessLayer;
using PeopleBusinessLayer;
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
using TestAppiontmentBusinessLayer;

namespace DVLD_Ep1
{
    public partial class VisionTestAppiontment : Form
    {
        private ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsTestType _TestType;
       
        int _CountOfTestAppointmentExist;

        private int _GetCountOfTestAppointmentExist()
        {
            return ClsTestAppointment.CountTestAppointmentExist(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, 
                clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName,
                clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID).FullName, _TestType.TestTypeID);
        }

        private void _LoadApplicationInfo(int LocalID, int AppID)
        {
            localDrivingLicenseAppDetails1.LoadLocalDrivingLicenseApplication(LocalID);
            applicationBasicDetails1.LoadApplicationBasic(AppID);
        }



        private void _RefreshTestAppiontmentList()
        {
            _CountOfTestAppointmentExist = _GetCountOfTestAppointmentExist();
            dvgGetLatestTestAppiontment.DataSource = ClsTestAppointment.FindTestAppointment(_CountOfTestAppointmentExist,
                _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,_TestType.TestTypeID);
            lbRecordsNum.Text = ClsTestAppointment.CountTestAppointmentinDGV(_CountOfTestAppointmentExist,
                _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID).ToString();
        }

        private void  SetIdentityOfForm()
        {
            switch (_TestType.TestTypeID)
            {
                case 1:
                    Text = "Vision Test Appointment";
                    pictureBox1.Image= Properties.Resources.Vision_Test_32;
                    label1.Text = "Vision Test Appointment";
                    return;
                case 2:
                    Text = "Written Test Appointment";
                    pictureBox1.Image = Properties.Resources.Written_Test_32;
                    label1.Text = "Written Test Appointment";
                    return;
                case 3:
                    Text = "Street Test Appointment";
                    pictureBox1.Image = Properties.Resources.Street_Test_32;
                    label1.Text = "Street Test Appointment";
                    return;
            }
        }
        public VisionTestAppiontment(int LocalDrivingLicenseApplicationID, int ApplicationID , int TestTypeID)
        {
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);
            _TestType = ClsTestType.Find(TestTypeID);
            InitializeComponent();
        }
        private void _RefreshAll()
        {
            SetIdentityOfForm();
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID);

            _LoadApplicationInfo(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,
                _LocalDrivingLicenseApplication.ApplicationID);

            _RefreshTestAppiontmentList();
          
        }

        private void VisionTestAppiontment_Load(object sender, EventArgs e)
        {
            _RefreshAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int localID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;

            if (ClsTestAppointment.IsTestAppointmentExist(localID))
            {
                MessageBox.Show("Person already has an active Appointment for this Test,You can`t add new appointment", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lastAppointment = ClsTestAppointment.FindLatestTestAppointmentForLocalIDAndTestTypeID(localID,_TestType.TestTypeID);
            if (lastAppointment !=null
                && ClsTest.IsTestPassedByAppointmentID(lastAppointment.TestAppointmentID))
            {
                MessageBox.Show("This Person already Passed This Test before,you can only retake failed test ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormOfSechudleVisionTest frm = new FormOfSechudleVisionTest(localID, _TestType.TestTypeID,-1);
            frm.ShowDialog();
            _RefreshTestAppiontmentList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfSechudleVisionTest frm = new FormOfSechudleVisionTest(_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,
                _TestType.TestTypeID, (int)dvgGetLatestTestAppiontment.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestAppiontmentList();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfTakeTest frm = new FormOfTakeTest ((int)dvgGetLatestTestAppiontment.CurrentRow.Cells[0].Value,_TestType.TestTypeID);
            frm.ShowDialog();
            _RefreshAll();
        }

        private void applicationBasicDetails1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}