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
using LocalDrivingLicenseApplicationBuisnessLayer;

namespace DVLD_Ep1
{
    public partial class FormOfLocalDrivingLicenseApplication : Form
    {
        private void _RefreshLocalDrivingLicenseApplicationList()
        {
            dvgGetAllRecordsForLocalDrivingLicenseApplication.DataSource=ClsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            lbRecordsNum.Text = ClsLocalDrivingLicenseApplication.CountTotalLocalDrivingLicenseApplications().ToString();
        }
        public FormOfLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void FormOfLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _RefreshLocalDrivingLicenseApplicationList();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            FormOfAddEditLocalDrivingLicenseApplication frm = new FormOfAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationList();
        }
        string previousvalue = "";

        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterValue = tbFilterBy.Text;

            DataTable result = null;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // LdL.AppID
                    if (int.TryParse(filterValue, out int appId))
                        result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(AppID: appId);
                    break;

                case 2: // Driving Class
                    result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(DrivingClass: filterValue);
                    break;

                case 3: // National No
                    result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(NationalNo: filterValue);
                    break;

                case 4: // Full Name
                    result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(FullName: filterValue);
                    break;

                case 5: // Application Date
                    if (DateTime.TryParse(filterValue, out DateTime date))
                        result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(ApplicationDate: date);
                    break;

                case 6: // Passed Tests
                    if (int.TryParse(filterValue, out int passed))
                        result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(PassedTests: passed);
                    break;

                case 7: // Status
                    result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(Status: filterValue);
                    break;

                default:
                    result = null;
                    break;
            }


           
            if (result != null)
                dvgGetAllRecordsForLocalDrivingLicenseApplication.DataSource = result;
            else
                dvgGetAllRecordsForLocalDrivingLicenseApplication.DataSource = null;


         
            if (filterValue.Length < previousvalue.Length)
            {
                dvgGetAllRecordsForLocalDrivingLicenseApplication.DataSource = ClsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            }

            previousvalue = filterValue;

        }

    }
}
