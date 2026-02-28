using ApplicationsBusinessLayer;
using ApplicationTyoesBusinessLayer;
using DriversBusinessLayer;
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
using static ApplicationTyoesBusinessLayer.ClsApplicationTypes;

namespace DVLD_Ep1
{
    public partial class FormOfReplacementLicense : Form
    {
        ClsLicense _newLicense;
        ClsDriver _Driver;
        public FormOfReplacementLicense()
        {
            InitializeComponent();
        }
       
        private void UpdateReplacementData()
        {
            lbAppFees.Text=rbLostLicesne.Checked?
               ClsApplicationTypes.Find((int)enApplicationType.ReplaceLostDrivingLicense).Fees.ToString()
             : ClsApplicationTypes.Find((int)enApplicationType.ReplaceDamagedDrivingLicense).Fees.ToString();
        }

        private void LoadData()
        {
            lbAppDate.Text = DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = GlobalUser.CurrentUser.UserName.ToString();
            UpdateReplacementData();
            LLShowNewLicenseInfo.Enabled = false;
            LLShowLicesneHistory.Enabled = false;
            btnIssueReplacement.Enabled = false;
        }
        private void _LicenseFound()
        {
            _Driver = ClsDriver.FindByDriverID(result.DriverID);
            driverLicenseDetailsUC1.LoadDriverLicenseInfo(result.LicenseID);
            lbOldLicenseID.Text = result.LicenseID.ToString();
            LLShowLicesneHistory.Enabled = true;
        }
      


        private void FormOfReplacementLicense_Load(object sender, EventArgs e)
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
                if (ClsLicense.IsLicenseActive(result.LicenseID,result.LicenseClass))
                {
                    btnIssueReplacement.Enabled = true;
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

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            ClsApplication _App = new ClsApplication();
            _App.ApplicantPersonID = _Driver.PersonID;
            _App.ApplicationDate = DateTime.Now;
            _App.ApplicationTypeID = rbLostLicesne.Checked ? (int)ClsApplicationTypes.enApplicationType.ReplaceLostDrivingLicense
                : (int)ClsApplicationTypes.enApplicationType.ReplaceDamagedDrivingLicense;
            _App.ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
            _App.LastStatusDate = DateTime.Now;
            _App.PaidFees = ClsApplicationTypes.Find(_App.ApplicationTypeID).Fees;
            _App.CreatedByUserID = GlobalUser.CurrentUser.UserID;
            if (!_App.SaveApplication())
            {
                return;
            }
            _newLicense = new ClsLicense();
            _newLicense.ApplicationID = _App.ApplicationID;
            _newLicense.DriverID = _Driver.DriverID;
            _newLicense.LicenseClass = result.LicenseClass;
            _newLicense.IssueDate = DateTime.Now;
            _newLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClass.FindLicenseClassByID(result.LicenseClass).DefaultValidityLength);
            _newLicense.PaidFees =0;
            _newLicense.IsActive = true;
            _newLicense.IssueReason = rbLostLicesne.Checked ? ClsLicense.enIssueReason.ReplacementForLost
                : ClsLicense.enIssueReason.ReplacementForDamaged;
            _newLicense.CreatedByUserID = result.CreatedByUserID;

            result.IsActive = false;
            if (MessageBox.Show("Are You Sure To you want to Issue a replacement for this licesne", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_newLicense.SaveLicense() && result.SaveLicense())
                {
                    MessageBox.Show("License Renewed Successfully With ID = " + _newLicense.LicenseID);
                    lbLRAppID.Text = _App.ApplicationID.ToString();
                    lbReplacedLicenseID.Text = _newLicense.LicenseID.ToString();
                    LLShowNewLicenseInfo.Enabled = true;
                    groupBox2.Enabled = false;
                }
                else
                {
                    MessageBox.Show(" License is Not Replaced  .");
                }
            }
            else
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReplacementData();
        }

        private void rbLostLicesne_CheckedChanged(object sender, EventArgs e)
        {
            UpdateReplacementData();
        }
    }
}
