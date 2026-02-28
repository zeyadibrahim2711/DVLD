using DriversBusinessLayer;
using LicenseClassesBusinessLayer;
using LicensesBusinessLayer;
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
    public partial class Issue_Driver_License_For_The_First_Time : Form
    {
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        ClsDriver _Driver;
        ClsLicense _License;
        public Issue_Driver_License_For_The_First_Time(int LocalDrivingLicenseApplicationID, int ApplicationID)
        {
            InitializeComponent();
            localDrivingLicenseAppDetails1.LoadLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID);
            applicationBasicDetails1.LoadApplicationBasic(ApplicationID);
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);
        }

        private void Issue_Driver_License_For_The_First_Time_Load(object sender, EventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (ClsDriver.DriverExistByPersonID(_LocalDrivingLicenseApplication.ApplicantPersonID))
            {
                _Driver = ClsDriver.FindByPersonID(_LocalDrivingLicenseApplication.ApplicantPersonID);
            }
            else
            {
                _Driver = new ClsDriver();
                _Driver.PersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                _Driver.CreatedByUserID = _LocalDrivingLicenseApplication.CreatedByUserID;
                _Driver.CreatedDate = DateTime.Now;
                if (!_Driver.Save())
                    return;
            }

                _License = new ClsLicense();
                _License.ApplicationID = _LocalDrivingLicenseApplication.ApplicationID;
                _License.DriverID = _Driver.DriverID;
                _License.LicenseClass = clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).LicenseClassID;
                _License.IssueDate = DateTime.Now;
                _License.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).DefaultValidityLength);
                _License.Notes = string.IsNullOrWhiteSpace(tbNotes.Text) ? null : tbNotes.Text;
                _License.PaidFees = _LocalDrivingLicenseApplication.PaidFees + 5;
                _License.IsActive = true;
                _License.IssueReason = ClsLicense.enIssueReason.FirstTime;
                _License.CreatedByUserID = _LocalDrivingLicenseApplication.CreatedByUserID;
          
            
            if (_License.SaveLicense())
            {
                MessageBox.Show("License issued Succesfullly With LicenseID = " + _License.LicenseID,"Successed",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                
            }
        }

        private void applicationBasicDetails1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
