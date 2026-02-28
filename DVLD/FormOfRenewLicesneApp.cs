using ApplicationsBusinessLayer;
using ApplicationTyoesBusinessLayer;
using DriversBusinessLayer;
using InternationalLicenseBusinessLayer;
using LicenseClassesBusinessLayer;
using LicensesBusinessLayer;
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
    public partial class FormOfRenewLicesneApp : Form
    {
        ClsLicense _newLicense;
        ClsDriver _Driver;
        public FormOfRenewLicesneApp()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            lbAppDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lbAppFees.Text = ClsApplicationTypes.Find((int)ClsApplicationTypes.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lbCreatedBy.Text = GlobalUser.CurrentUser.UserName.ToString();
            LLShowNewLicenseInfo.Enabled = false;
            LLShowLicesneHistory.Enabled = false;
            btnRenew.Enabled = false;
        }
        private void _LicenseFound()
        {
            _Driver = ClsDriver.FindByDriverID(result.DriverID);
            driverLicenseDetailsUC1.LoadDriverLicenseInfo(result.LicenseID);
            lbOldLicenseID.Text = result.LicenseID.ToString();
            lbIssueDate.Text = result.IssueDate.ToShortDateString();
            lbExpirationDate.Text = result.ExpirationDate.ToShortDateString();
            lbLicenseFees.Text = ClsApplicationTypes.Find((int)ClsApplicationTypes.enApplicationType.NewDrivingLicense).Fees.ToString();
            lbTotalFees.Text =(Convert.ToDecimal(lbAppFees.Text) + Convert.ToDecimal(lbLicenseFees.Text)).ToString();
            LLShowLicesneHistory.Enabled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormOfRenewLicesneApp_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            ClsApplication _App = new ClsApplication();
            _App.ApplicantPersonID = _Driver.PersonID;
            _App.ApplicationDate = DateTime.Now;
            _App.ApplicationTypeID = (int)ClsApplicationTypes.enApplicationType.RenewDrivingLicense;
            _App.ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
            _App.LastStatusDate = DateTime.Now;
            _App.PaidFees = ClsApplicationTypes.Find((int)ClsApplicationTypes.enApplicationType.RenewDrivingLicense).Fees;
            _App.CreatedByUserID = GlobalUser.CurrentUser.UserID;
            if (!_App.SaveApplication())
            {
                return;
            }
            _newLicense = new ClsLicense();
            _newLicense.ApplicationID = _App.ApplicationID;
            _newLicense.DriverID = _Driver.DriverID;
            _newLicense.LicenseClass =result.LicenseClass;
            _newLicense.IssueDate = DateTime.Now;
            _newLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.FindLicenseClassByID(result.LicenseClass).DefaultValidityLength);
            _newLicense.Notes = string.IsNullOrWhiteSpace(tbNotes.Text) ? null : tbNotes.Text;
            _newLicense.PaidFees = (result.PaidFees);
            _newLicense.IsActive = true;
            _newLicense.IssueReason = ClsLicense.enIssueReason.Renew;
            _newLicense.CreatedByUserID =result.CreatedByUserID;

            result.IsActive = false;
            if (MessageBox.Show("Are You Sure To you want to renew this licesne", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_newLicense.SaveLicense() && result.SaveLicense())
                {
                    MessageBox.Show("License Renewed Successfully With ID = " + _newLicense.LicenseID);
                    lbRLAppID.Text = _App.ApplicationID.ToString();
                    lbRenewLicenseID.Text = _newLicense.LicenseID.ToString();
                    LLShowNewLicenseInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show(" License is Not Renewed  .");
                }
            }
            else
            {
                return;
            }
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
                if (ClsLicense.IsLicenseActive(result.LicenseID,result.LicenseClass))
                {
                    if (!ClsLicense.IsLicenseExpired(result.LicenseID))
                    {
                        if (ClsLicense.IsLicenseActive(result.LicenseID,result.LicenseClass))
                            MessageBox.Show("Selected Licesne is not yet expired it will expire on " + result.ExpirationDate.ToShortDateString(),
                                "Not Allowed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        btnRenew.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Selected Licesne is not active ",
                   "Not Allowed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _LicenseFound();
            }
            else
            {
                MessageBox.Show("No License With This Data Please Enter Right Input !", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFilterBy.Focus();
            }
        }

        private void LLShowLicesneHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormOfLicenseHistory frm = new FormOfLicenseHistory(_Driver.PersonID);
            frm.ShowDialog();
        }

        private void LLShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormOfLicenseInfo frm = new FormOfLicenseInfo(_newLicense.LicenseID);
            frm.ShowDialog();
        }
    }
}
