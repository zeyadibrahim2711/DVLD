using LocalDrivingLicenseApplicationBuisnessLayer;
using ApplicationsBusinessLayer;
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
using static System.Net.Mime.MediaTypeNames;
using LicensesBusinessLayer;

namespace DVLD_Ep1
{
    public partial class FormOfLocalDrivingLicenseApplication : Form
    {
        enum TestStatus
        {
            Vision = 0,
            Written = 1,
            Street = 2,
            PassedAll = 3

        }

        private void _SetDefultValueForMenuItems()
        {
            sechudleVisionTestToolStripMenuItem.Enabled = false;
            sechudleWrittenTestToolStripMenuItem.Enabled = false;
            sechudleStreetTestToolStripMenuItem.Enabled = false;
            issueDrivigLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = false;
        }

        private void _MenuAfterIssueLicense()
        {
            showLicenseToolStripMenuItem.Enabled = true;
            EditApplicationToolStripMenuItem.Enabled = false;
            DeleteApplicationToolStripMenuItem.Enabled = false;
            CancelApplicationToolStripMenuItem.Enabled = false;
            SechudleTestsToolStripMenuItem.Enabled = false;
        }

        private void _RefreshLocalDrivingLicenseApplicationList()
        {
            DataTable dt = ClsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dvgGetAllRecordsForLocalDrivingLicenseApplication.DataSource = dt;
            lbRecordsNum.Text = dt.Rows.Count.ToString();
        }
       
       
        public FormOfLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void _HandleTestsMenuStrip()
        {
            if (dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow == null)
                return;

            TestStatus status = (TestStatus)
       dvgGetAllRecordsForLocalDrivingLicenseApplication
       .CurrentRow.Cells[5].Value;



            _SetDefultValueForMenuItems();

           
            switch (status)
            {
                case TestStatus.Vision:
                    sechudleVisionTestToolStripMenuItem.Enabled = true;
                    break;

                case TestStatus.Written:
                    sechudleWrittenTestToolStripMenuItem.Enabled = true;
                    break;

                case TestStatus.Street:
                    sechudleStreetTestToolStripMenuItem.Enabled = true;
                    break;

                case TestStatus.PassedAll:
                    int localid= ((int)
                        dvgGetAllRecordsForLocalDrivingLicenseApplication
                        .CurrentRow.Cells[0].Value);
                    if (ClsLicense.CanIssueLicense(localid))
                    {
                        issueDrivigLicenseToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        _MenuAfterIssueLicense();
                    }

                        break;
            }
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

                case 2: // National No
                    result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(NationalNo: filterValue);
                    break;

                case 3: // Full Name
                    result = ClsLocalDrivingLicenseApplication.FindSingleLocalDrivingApp(FullName: filterValue);
                    break;

                case 4: // Status
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

       

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.
                FindLocalDrivingLicenseApplicationByID((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            FormOfInfoOfLocalDrivingLicenseApplication frm = new FormOfInfoOfLocalDrivingLicenseApplication
                (local.LocalDrivingLicenseApplicationID, local.ApplicationID);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationList();
        }

        private void EditApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfAddEditLocalDrivingLicenseApplication frm = new FormOfAddEditLocalDrivingLicenseApplication
                ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationList();
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete Local Driving License Application [" 
                + dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value + "]", "Confirm Delete ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ClsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication
                    ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Local Driving License Application Deleted Successfully.");
                    _RefreshLocalDrivingLicenseApplicationList();
                }
                else
                {
                    MessageBox.Show("Local Driving License Application is Not Deleted .");
                }
            }
        }

        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            FormOfAddEditLocalDrivingLicenseApplication frm = new FormOfAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationList();
        }

        private void CancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID
                ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are You Sure To Cancel Local Driving License Application ["
                + dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value + "]", "Confirm Cancel ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ClsLocalDrivingLicenseApplication.CancelApplication(local.ApplicationID))
                {
                    MessageBox.Show("Local Driving License Application Cancelled Successfully.");
                    _RefreshLocalDrivingLicenseApplicationList();
                }
                else
                {
                    MessageBox.Show("Local Driving License Application is Not Cancelled  .");
                }
            }
        }

        private void showPersonLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID
             ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            FormOfLicenseHistory frm = new FormOfLicenseHistory(local.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void sechudleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID
                ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            VisionTestAppiontment frm = new VisionTestAppiontment(local.LocalDrivingLicenseApplicationID, local.ApplicationID,1);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationList();
        }

        private void dvgGetAllRecordsForLocalDrivingLicenseApplication_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dvgGetAllRecordsForLocalDrivingLicenseApplication.ClearSelection();
                dvgGetAllRecordsForLocalDrivingLicenseApplication.Rows[e.RowIndex].Selected = true;
                dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentCell =
                    dvgGetAllRecordsForLocalDrivingLicenseApplication.Rows[e.RowIndex].Cells[0];

                _HandleTestsMenuStrip();
            }
        }

        private void sechudleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID
              ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            VisionTestAppiontment frm = new VisionTestAppiontment(local.LocalDrivingLicenseApplicationID, local.ApplicationID,2);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationList();
        }

        private void sechudleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID
           ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            VisionTestAppiontment frm = new VisionTestAppiontment(local.LocalDrivingLicenseApplicationID, local.ApplicationID, 3);
            frm.ShowDialog();
            if (local.PassedTests==3)
            {
                ClsLocalDrivingLicenseApplication.MakeApplicationComplete(local.ApplicationID);
            }
            _RefreshLocalDrivingLicenseApplicationList();
        }

        private void issueDrivigLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID
            ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            Issue_Driver_License_For_The_First_Time frm = new Issue_Driver_License_For_The_First_Time(local.LocalDrivingLicenseApplicationID, local.ApplicationID);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationList();
            issueDrivigLicenseToolStripMenuItem.Enabled = false;
            showLicenseToolStripMenuItem.Enabled = true;
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID
           ((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);

            ClsLicense license = ClsLicense.FindLicenseByAppID(local.ApplicationID);

            FormOfLicenseInfo frm = new FormOfLicenseInfo(license.LicenseID);
            frm.ShowDialog();

        }
    }
}