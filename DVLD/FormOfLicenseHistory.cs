using DriversBusinessLayer;
using InternationalLicenseBusinessLayer;
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
    public partial class FormOfLicenseHistory : Form
    {
        clsPerson _Person;

        int _PersonID;
        public FormOfLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {
            _Person = clsPerson.FindByID(_PersonID);
           
            if (_Person==null)
            {
                return;
            }
            ClsDriver _Driver = ClsDriver.FindByPersonID(_PersonID);
            gbFilter.Enabled = false;
            cbFilterBy.SelectedIndex = 1;
            tbFilterBy.Text = _Person.PersonID.ToString();
            personDetalisUC1.LoadPersonInfo(_Person.PersonID);

            DataTable dtForLicenseHistory= ClsLicense.FindAllLocalDrivingLicenseForDriver(_Driver.DriverID);

            dgvLocalLicenseHistory.DataSource = dtForLicenseHistory;
            lbRecordsNum.Text = dtForLicenseHistory.Rows.Count.ToString();

            DataTable dt = ClsInternationalLicense.FindAllInternationalLicensesForDriver(_Driver.DriverID);

            if (dt.Rows.Count == 0)
            {
                return;
            }

            dgvInternationalLicenseHistory.DataSource = dt;
            lbNationalLicenseRecordNum.Text = dt.Rows.Count.ToString();
        }



        private void FormOfLicenseHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfLicenseInfo frm = new FormOfLicenseInfo((int)dgvLocalLicenseHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormOfInternationalLicenseInfo frm = new FormOfInternationalLicenseInfo((int)dgvInternationalLicenseHistory.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
