using DetainLicensesBusinessLayer;
using DriversBusinessLayer;
using InternationalLicenseBusinessLayer;
using LicensesBusinessLayer;
using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Ep1
{
    public partial class FormOfListDetainLicenses : Form
    {
        public FormOfListDetainLicenses()
        {
            InitializeComponent();
        }
        private void _RefreshDetainedLicenseList()
        {
           DataTable dt = ClsDetainedLicense.FindAllDetainedLicense();
            dvgGetAllRecordsDetainedLicense.DataSource = dt;
            lbRecordsNum.Text = dt.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormOfListDetainLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDetainedLicenseList();
        }
        private void _HideOrShowReleaseMenuStrip()
        {
            if (dvgGetAllRecordsDetainedLicense.CurrentRow == null)
                return;
            int DetainID =( int )dvgGetAllRecordsDetainedLicense
                        .CurrentRow.Cells[0].Value;
            if (ClsDetainedLicense.IsLicenseDetainedByDetID(DetainID))
            {
                releaseDToolStripMenuItem.Enabled = true;
            }
            else
            {
                releaseDToolStripMenuItem.Enabled =false;
            }
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
        string previousvalue = "";
        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterValue = tbFilterBy.Text;

            DataTable result = null;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // Detain ID
                    if (int.TryParse(filterValue, out int detainid))
                        result = ClsDetainedLicense.FindDetainedLicenses(detainID: detainid);//Named Arguments (name:value)
                    break;

                case 2: // Is Released

                    if (bool.TryParse(filterValue, out bool isreleased))
                        result = ClsDetainedLicense.FindDetainedLicenses(isReleased: isreleased);
                    break;

                case 3: // National No
                    if (int.TryParse(filterValue, out int nationalNo))
                        result = ClsDetainedLicense.FindDetainedLicenses(nationalNO: nationalNo);
                    break;

                case 4: // Full Name

                    result = ClsDetainedLicense.FindDetainedLicenses(fullName:filterValue);
                    break;
                case 5: // Release App ID
                    if (int.TryParse(filterValue, out int releaseAppID))
                        result = ClsDetainedLicense.FindDetainedLicenses(releaseApplicationID: releaseAppID);//Named Arguments (name:value)
                    break;

                default:
                    result = null;
                    break;
            }

            if (result != null)
                dvgGetAllRecordsDetainedLicense.DataSource = result;
            else
                dvgGetAllRecordsDetainedLicense.DataSource = null;



            if (filterValue.Length < previousvalue.Length)
            {
                dvgGetAllRecordsDetainedLicense.DataSource = ClsDetainedLicense.FindAllDetainedLicense();
            }

            previousvalue = filterValue;

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            FormOfRealseDetainLicense frm = new FormOfRealseDetainLicense(-1);
            frm.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            FormOfDetainLicense frm = new FormOfDetainLicense();
            frm.ShowDialog();
        }

        private void ShowPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.FindByNationalNo((string)dvgGetAllRecordsDetainedLicense.CurrentRow.Cells[7].Value);
            FormOfPersonDetails frm = new FormOfPersonDetails(person.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfLicenseInfo frm = new FormOfLicenseInfo((int)dvgGetAllRecordsDetainedLicense.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.FindByNationalNo((string)dvgGetAllRecordsDetainedLicense.CurrentRow.Cells[7].Value);
            FormOfLicenseHistory frm = new FormOfLicenseHistory(person.PersonID);
            frm.ShowDialog();
        }

        private void releaseDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfRealseDetainLicense frm = new FormOfRealseDetainLicense((int)dvgGetAllRecordsDetainedLicense.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void dvgGetAllRecordsDetainedLicense_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dvgGetAllRecordsDetainedLicense.ClearSelection();
                dvgGetAllRecordsDetainedLicense.Rows[e.RowIndex].Selected = true;
                dvgGetAllRecordsDetainedLicense.CurrentCell =
                    dvgGetAllRecordsDetainedLicense.Rows[e.RowIndex].Cells[0];

                _HideOrShowReleaseMenuStrip();
            }
        }
    }
}
