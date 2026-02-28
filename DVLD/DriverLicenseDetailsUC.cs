using CountriesBusinessLayer;
using DriversBusinessLayer;
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
    public partial class DriverLicenseDetailsUC : UserControl
    {
        private ClsLicense _License;
        private ClsDriver _Driver;
        public DriverLicenseDetailsUC()
        {
            InitializeComponent();
        }
        public string IssueReasonText (enIssueReason IssueReason)
        {
           
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";

                    case enIssueReason.Renew:
                        return "Renew";

                    case enIssueReason.ReplacementForDamaged:
                        return "Replacement For Damaged";

                    case enIssueReason.ReplacementForLost:
                        return "Replacement For Lost";

                    default:
                        return "Unknown";
                }
            
        }

        public void LoadDriverLicenseInfo(int LicenseID)
        {
            _License = ClsLicense.FindLicenseByID(LicenseID);
            if (_License!=null)
            {
                _Driver = ClsDriver.FindByDriverID(_License.DriverID);
            }
            if (_License == null)
            {
                MessageBox.Show("No License with LicenseID = " + LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillDriverLicenseInfo();
        }
        private void _FillDriverLicenseInfo()
        {

            clsPerson _Person = clsPerson.FindByID(_Driver.PersonID);

            lbClassName.Text = clsLicenseClass.FindLicenseClassByID(_License.LicenseClass).ClassName;
            lblFullName.Text = _Person.FullName;
            lbLicenseID.Text = _License.LicenseID.ToString();
            lbNationalNumber.Text = _Person.NationalNo;
            lbGender.Text = _Person.GenderByte == 0 ? "Male" : "Female";
            lbIssueDate.Text = _License.IssueDate.ToShortDateString();
            lbIssueReason.Text = IssueReasonText(_License.IssueReason);
            lbNotes.Text = _License.Notes == "" ? "No Notes " : _License.Notes;
            lbIsActive.Text = _License.IsActive == true ? "Yes" : "No";
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lbDriverID.Text = _Driver.DriverID.ToString();
            lbExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lbIsDetained.Text = _License.IsActive == true ? "No" : "Yes";
            if (_Person.ImagePath != null)
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
