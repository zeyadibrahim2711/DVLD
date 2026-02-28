using DriversBusinessLayer;
using InternationalLicenseBusinessLayer;
using LicenseClassesBusinessLayer;
using LicensesBusinessLayer;
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
using static LicensesBusinessLayer.ClsLicense;

namespace DVLD_Ep1
{
    public partial class InternationalDriverLicenseInfo : UserControl
    {
        private ClsInternationalLicense _InternationalLicense;
        private ClsDriver _Driver;
        public InternationalDriverLicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadInternationalDriverLicenseInfo(int InternationalLicenseID)
        {
            _InternationalLicense = ClsInternationalLicense.FindInternationalLicenseByID(InternationalLicenseID);
            if (_InternationalLicense != null)
            {
                _Driver = ClsDriver.FindByDriverID(_InternationalLicense.DriverID);
            }
            else
            {
                MessageBox.Show("No License with LicenseID = " + InternationalLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInternationalDriverLicenseInfo();
        }
        private void _FillInternationalDriverLicenseInfo()
        {

            clsPerson _Person = clsPerson.FindByID(_Driver.PersonID);

            
            lblFullName.Text = _Person.FullName;
            lbIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lbLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lbNationalNumber.Text = _Person.NationalNo;
            lbGender.Text = _Person.GenderByte == 0 ? "Male" : "Female";
            lbIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lbAppID.Text = _InternationalLicense.ApplicationID.ToString();
            lbIsActive.Text = _InternationalLicense.IsActive == true ? "Yes" : "No";
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lbDriverID.Text = _Driver.DriverID.ToString();
            lbExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            if (_Person.ImagePath != null)
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
