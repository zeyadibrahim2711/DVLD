using DriversBusinessLayer;
using InternationalLicenseBusinessLayer;
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

namespace DVLD_Ep1
{
    public partial class FormOfinternationalLicenseApp : Form
    {
        public FormOfinternationalLicenseApp()
        {
            InitializeComponent();
        }
        private void _RefreshInternationalDrivingLicenseApplicationList()
        {
            DataTable dt = ClsInternationalLicense.GetAllInternationalDrivingLicenseApplications();
            dvgGetAllRecordsForInternationalDrivingLicenseApplication.DataSource = dt;
            lbRecordsNum.Text = dt.Rows.Count.ToString();
        }



        private void FormOfinternationalLicenseApp_Load(object sender, EventArgs e)
        {
            _RefreshInternationalDrivingLicenseApplicationList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 0)
            {
                tbFilterBy.Visible = true;
            }
            if (cbFilterBy.SelectedIndex == 0)
            {
                tbFilterBy.Visible = false;
            }
        }

        private void btnAddNewInternationalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            FormOfAddInternationalDrivigLicenseApp frm = new FormOfAddInternationalDrivigLicenseApp();
            frm.ShowDialog();
            _RefreshInternationalDrivingLicenseApplicationList();
        }
        string previousvalue = "";
        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterValue = tbFilterBy.Text;

            DataTable result = null;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // Int.License ID
                    if (int.TryParse(filterValue, out int intlicenseId))
                        result = ClsInternationalLicense.FindInternationalLicense(internationalLicenseID: intlicenseId);
                    break;

                case 2: // Application ID

                    if (int.TryParse(filterValue, out int appId))
                        result = ClsInternationalLicense.FindInternationalLicense(applicationID: appId);
                    break;

                case 3: // DriverID
                    if (int.TryParse(filterValue, out int driverId))
                        result = ClsInternationalLicense.FindInternationalLicense(driverID: driverId);
                    break;

                case 4: // L.Licesne ID
                    if (int.TryParse(filterValue, out int LlicenseId))
                        result = ClsInternationalLicense.FindInternationalLicense(localLicenseID: LlicenseId);
                    break;

                default:
                    result = null;
                    break;
            }

            if (result != null)
                dvgGetAllRecordsForInternationalDrivingLicenseApplication.DataSource = result;
            else
                dvgGetAllRecordsForInternationalDrivingLicenseApplication.DataSource = null;



            if (filterValue.Length < previousvalue.Length)
            {
                dvgGetAllRecordsForInternationalDrivingLicenseApplication.DataSource = ClsInternationalLicense.GetAllInternationalDrivingLicenseApplications();
            }

            previousvalue = filterValue;

        }

        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsDriver driver = ClsDriver.FindByDriverID((int)dvgGetAllRecordsForInternationalDrivingLicenseApplication.CurrentRow.Cells[2].Value);
            FormOfPersonDetails frm = new FormOfPersonDetails(driver.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfInternationalLicenseInfo frm = new FormOfInternationalLicenseInfo((int)dvgGetAllRecordsForInternationalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsDriver driver = ClsDriver.FindByDriverID((int)dvgGetAllRecordsForInternationalDrivingLicenseApplication.CurrentRow.Cells[2].Value);
            FormOfLicenseHistory frm = new FormOfLicenseHistory(driver.PersonID);
            frm.ShowDialog();
        }
    }


}
