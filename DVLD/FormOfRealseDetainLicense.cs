using ApplicationsBusinessLayer;
using ApplicationTyoesBusinessLayer;
using DetainLicensesBusinessLayer;
using DriversBusinessLayer;
using LicenseClassesBusinessLayer;
using LicensesBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Ep1
{
    public partial class FormOfRealseDetainLicense : Form
    {
        ClsDriver _Driver;
        ClsDetainedLicense _DetainLicense;
        ClsApplication _App;
        int _LicenseID;

        public FormOfRealseDetainLicense(int LicenseID)
        {
            InitializeComponent();
            if (LicenseID != -1)
            {
                _LicenseID = LicenseID;
            }
            else
                _LicenseID = -1;

        }
        private void KnownLicense()
        {
            _DetainLicense = ClsDetainedLicense.FindDetainedLicenseByLicense(_LicenseID);
            result = ClsLicense.FindLicenseByID(_LicenseID);
            tbFilterBy.Text = _LicenseID.ToString();
            groupBox2.Enabled = false;
            ShowData();
           _LicenseFound();
            LLShowLicenseInfo.Enabled = true;
            LLShowLicesneHistory.Enabled = true;
            btnRelease.Enabled = true;
        }
        private void LoadData()
        {
            if (_LicenseID!=-1)
            {
                KnownLicense();
                return;
            }
            LLShowLicenseInfo.Enabled = false;
            LLShowLicesneHistory.Enabled = false;
            btnRelease.Enabled = false;
        }
        private void ShowData()
        {
            lbDetainID.Text = _DetainLicense.DetainID.ToString();
            lbDetainDate.Text = _DetainLicense.DetainDate.ToShortDateString();
            lbCreatedBy.Text = GlobalUser.CurrentUser.UserName.ToString();
            lbApplicationFees.Text = ClsApplicationTypes.Find((int)ClsApplicationTypes.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lbFineFees.Text = _DetainLicense.FineFees.ToString();
            lbTotalFees.Text = (Convert.ToDecimal(lbApplicationFees.Text) + Convert.ToDecimal(lbFineFees.Text)).ToString();
        }
        private void CreateApp()
        {
            _App = new ClsApplication();
            _App.ApplicantPersonID = _Driver.PersonID;
            _App.ApplicationDate = DateTime.Now;
            _App.ApplicationTypeID = (int)ClsApplicationTypes.enApplicationType.ReleaseDetainedDrivingLicsense;
            _App.ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
            _App.LastStatusDate = DateTime.Now;
            _App.PaidFees = ClsApplicationTypes.Find((int)ClsApplicationTypes.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            _App.CreatedByUserID = GlobalUser.CurrentUser.UserID;
        }
        private void _LicenseFound()
        {

            _Driver = ClsDriver.FindByDriverID(result.DriverID);
            driverLicenseDetailsUC1.LoadDriverLicenseInfo(result.LicenseID);
            lbLicenseID.Text = result.LicenseID.ToString();
            LLShowLicesneHistory.Enabled = true;
        }

        private void driverLicenseDetailsUC1_Load(object sender, EventArgs e)
        {

        }

        private void FormOfRealseDetainLicense_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        ClsLicense result = null;
        private void btnLicenseSearch_Click(object sender, EventArgs e)
        {
            string filterValue = tbFilterBy.Text;
            if (!string.IsNullOrWhiteSpace(filterValue) &&
     int.TryParse(filterValue, out int licenseId))
            {
                result = ClsLicense.FindLicenseByID(licenseId);
            }

            if (result != null)
            {

                if (ClsDetainedLicense.IsLicenseDetained(result.LicenseID))
                {
                    _DetainLicense = ClsDetainedLicense.FindDetainedLicenseByLicense(result.LicenseID);
                    btnRelease.Enabled = true;
                    ShowData();
                }
                else
                {
                    MessageBox.Show("Selected Licesne is not Detained ",
                   "Not Allowed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                _LicenseFound();

            }
            else
            {
                MessageBox.Show("No License With This Data Please Enter Right Input !",
                    "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFilterBy.Focus();
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            CreateApp();
            if (!_App.SaveApplication())
            {
                return;
            }
          
            result.IsActive = true;
            if (MessageBox.Show("Are You Sure To you want to Release this licesne", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_DetainLicense.ReleaseLicense(DateTime.Now,
                     GlobalUser.CurrentUser.UserID,
                _App.ApplicationID)&& result.SaveLicense())                       //DateTime?  →  DateTime   ❌
                                                                                 //int?       →  int        ❌
                {
                    MessageBox.Show("Detained License Released Successfully");
                    lbAppID.Text = _App.ApplicationID.ToString();
                    LLShowLicenseInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show(" License is Not Released .");
                }
            }
            else
            {
                return;
            }
        }

        private void LLShowLicesneHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormOfLicenseHistory frm = new FormOfLicenseHistory(_Driver.PersonID);
            frm.ShowDialog();
        }

        private void LLShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormOfLicenseInfo frm = new FormOfLicenseInfo(_DetainLicense.LicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
