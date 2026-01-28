using LocalDrivingLicenseApplicationBuisnessLayer;
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
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            FormOfInfoOfLocalDrivingLicenseApplication frm = new FormOfInfoOfLocalDrivingLicenseApplication(local.LocalDrivingLicenseApplicationID, local.ApplicationID);
            frm.ShowDialog();
        }

        private void EditApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfAddEditLocalDrivingLicenseApplication frm = new FormOfAddEditLocalDrivingLicenseApplication((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLocalDrivingLicenseApplicationList();
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete Local Driving License Application [" + dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value + "]", "Confirm Delete ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (ClsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value))
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
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are You Sure To Cancel Local Driving License Application [" + dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value + "]", "Confirm Cancel ", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
          
        }

        private void sechudleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsLocalDrivingLicenseApplication local = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID((int)dvgGetAllRecordsForLocalDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            VisionTestAppiontment frm = new VisionTestAppiontment(local.LocalDrivingLicenseApplicationID, local.ApplicationID);
            frm.ShowDialog();
        }
    }
}