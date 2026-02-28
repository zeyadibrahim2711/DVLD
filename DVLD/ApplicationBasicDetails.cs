using ApplicationsBusinessLayer;
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
    public partial class ApplicationBasicDetails : UserControl
    {

        private ClsApplication _Application;
        public static string DateToShort(DateTime Dt1)
        { 
            return Dt1.ToString("dd/MMM/yyyy");
        }
        public ApplicationBasicDetails()
        {
            InitializeComponent();
        }

        public void LoadApplicationBasic(int ApplicationID)
        {
            _Application = ClsApplication.FindApplicationByID(ApplicationID);
            if (_Application == null)
            {
                MessageBox.Show("No Local DrivingLicense Application with Local Driving License ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillApplicationInfo();
        }
        private void _FillApplicationInfo()
        {
            lbIDinAppControl.Text = _Application.ApplicationID.ToString();
            lbStatusinAppControl.Text = _Application.ApplicationStatus.ToString();
            lbFeesinAppControl.Text = _Application.PaidFees.ToString();
            lbTypeinAppControl.Text = _Application.ApplicationTypeInfo.Title;//important
            lbApplicantinAppControl.Text = _Application.ApplicantPersonID.ToString();
            lbDatainAppControl.Text = DateToShort(_Application.ApplicationDate);
            lbStatusDateinAppControl.Text =DateToShort(_Application.LastStatusDate);
            lbCreatedByinAppControl.Text = _Application.CreatedByUserID.ToString();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ApplicationBasicDetails_Load(object sender, EventArgs e)
        {

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormOfPersonDetails frm = new FormOfPersonDetails(_Application.ApplicantPersonID);
            frm.ShowDialog();
        }
    }
}
