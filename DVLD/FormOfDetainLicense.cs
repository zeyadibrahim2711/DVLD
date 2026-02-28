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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Ep1
{
    public partial class FormOfDetainLicense : Form
    {
        ClsDetainedLicense _DetainLicense;
        ClsDriver _Driver;
        
        public FormOfDetainLicense()
        {
            InitializeComponent();
         
        }
        private void LoadData()
        {
          
            
                lbDetainDate.Text = DateTime.Now.ToShortDateString();
                lbCreatedBy.Text = GlobalUser.CurrentUser.UserName.ToString();
                LLShowLicenseInfo.Enabled = false;
                LLShowLicesneHistory.Enabled = false;
                btnDetain.Enabled = false;
            
          
        }
        private void _LicenseFound()
        {

            
            
                _Driver = ClsDriver.FindByDriverID(result.DriverID);
                driverLicenseDetailsUC1.LoadDriverLicenseInfo(result.LicenseID);
                lbLicenseID.Text = result.LicenseID.ToString();
                LLShowLicesneHistory.Enabled = true;

         
        }
        private void FormOfDetainLicense_Load(object sender, EventArgs e)
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
                if (!ClsDetainedLicense.IsLicenseDetained(result.LicenseID))
                {
                    btnDetain.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Selected Licesne is already Detained ",
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

        private void btnDetain_Click(object sender, EventArgs e)
        {
            _DetainLicense = new ClsDetainedLicense();
            _DetainLicense.LicenseID = result.LicenseID;
            _DetainLicense.DetainDate = DateTime.Now;
            _DetainLicense.FineFees =string.IsNullOrWhiteSpace(tbFineFess.Text) ? 0 : decimal.Parse(tbFineFess.Text);
            _DetainLicense.CreatedByUserID = result.CreatedByUserID;
            _DetainLicense.IsReleased = false;
            _DetainLicense.ReleaseDate = null;
            _DetainLicense.ReleasedByUserID= null;
            _DetainLicense.ReleaseApplicationID = null;
            result.IsActive = false;
            if (MessageBox.Show("Are You Sure To you want to renew this licesne", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (_DetainLicense.Save() && result.SaveLicense())
                {
                    MessageBox.Show("License Detained Successfully With ID = " + _DetainLicense.DetainID);
                    lbDetainID.Text =_DetainLicense.DetainID.ToString();
                    LLShowLicenseInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show(" License is Not Detained .");
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
