using ApplicationsBusinessLayer;
using ApplicationTyoesBusinessLayer;
using DriversBusinessLayer;
using InternationalLicenseBusinessLayer;
using LicenseClassesBusinessLayer;
using LicensesBusinessLayer;
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
using UsersBusinessLayer;

namespace DVLD_Ep1
{
    public partial class FormOfAddInternationalDrivigLicenseApp : Form
    {
        ClsInternationalLicense _internationalLicense;
        ClsDriver _Driver;
        public FormOfAddInternationalDrivigLicenseApp()
        {
            InitializeComponent();
        }
        private void driverLicenseDetailsUC1_Load(object sender, EventArgs e)
        {

        }
        private void _LicenseFound()
        {
            _Driver = ClsDriver.FindByDriverID(result.DriverID);
            driverLicenseDetailsUC1.LoadDriverLicenseInfo(result.LicenseID);
            lbLLicenseID.Text = result.LicenseID.ToString();
            LLShowLicesneHistory.Enabled = true;
        }
        private void LoadData()
        {
            lbAppDate.Text = DateTime.Now.ToShortDateString();
            lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lbExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lbFees.Text = ClsApplicationTypes.Find((int)ClsApplicationTypes.enApplicationType.NewInternationalLicense).Fees.ToString();
            lbCreatedBy.Text = GlobalUser.CurrentUser.UserID.ToString();
            LLShowLicenseInfo.Enabled = false;
            LLShowLicesneHistory.Enabled = false;
            btnIssue.Enabled = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

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
                if (ClsInternationalLicense.ExistsInternationalLicenseByDriverID(result.DriverID))
                {
                    _internationalLicense = ClsInternationalLicense.FindInternationalLicenseByDriverID(result.DriverID);
                    MessageBox.Show("Person already has an active international licesne with ID =  " + _internationalLicense.InternationalLicenseID,
                        "Not Allowed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LLShowLicenseInfo.Enabled = true;
                }
                else
                {
                    btnIssue.Enabled = true;
                }
                _LicenseFound();
            }
            else
            {
                MessageBox.Show("No License With This Data Please Enter Right Input !", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFilterBy.Focus();
            }
        }

        private void FormOfAddInternationalDrivigLicenseApp_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            ClsApplication App = new ClsApplication();
            App.ApplicantPersonID =_Driver.PersonID;
            App.ApplicationDate = DateTime.Now;
            App.ApplicationTypeID = (int)ClsApplicationTypes.enApplicationType.NewInternationalLicense;
            App.ApplicationStatus = ClsApplication.enApplicationStatus.New;
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = ClsApplicationTypes.Find((int)ClsApplicationTypes.enApplicationType.NewInternationalLicense).Fees;
            App.CreatedByUserID = GlobalUser.CurrentUser.UserID;
            if (!App.SaveApplication())
            {
                return;
            }
            _internationalLicense = new ClsInternationalLicense();
            _internationalLicense.ApplicationID = App.ApplicationID;
            _internationalLicense.DriverID = result.DriverID;
            _internationalLicense.IssuedUsingLocalLicenseID = result.LicenseID;
            _internationalLicense.IssueDate = DateTime.Now;
            _internationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _internationalLicense.IsActive = true;
            _internationalLicense.CreatedByUserID = GlobalUser.CurrentUser.UserID;
            if (MessageBox.Show("Are You Sure To you want to issue this licesne", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_internationalLicense.SaveInternationalLicense())
                {
                    MessageBox.Show("International License issued successsfully with ID = " + _internationalLicense.InternationalLicenseID,"Licesne Issued",MessageBoxButtons.OK);
                    lbILAppID.Text = App.ApplicationID.ToString();
                    lbILLicenseID.Text = _internationalLicense.InternationalLicenseID.ToString();
                    btnIssue.Enabled = false;
                    LLShowLicenseInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("International License is Not issued  .");
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
            FormOfInternationalLicenseInfo frm = new FormOfInternationalLicenseInfo(_internationalLicense.InternationalLicenseID);
            frm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}