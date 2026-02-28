using DriversBusinessLayer;
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

namespace DVLD_Ep1
{
    public partial class FormOfDrivers : Form
    {
        public FormOfDrivers()
        {
            InitializeComponent();
        }

        private void _RefreshDriversList()
        {
            DataTable dt = ClsDriver.FindAllDrivers();
            dgvGetAllDrivers.DataSource = dt;
            lbRecordsNum.Text = dt.Rows.Count.ToString();
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

        private void FormOfDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDriversList();
            cbFilterBy.SelectedIndex = 0;
            tbFilterBy.Visible = false;
        }

        string previousvalue = "";
        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterValue = tbFilterBy.Text;

            DataTable result = null;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // Driver ID
                    if (int.TryParse(filterValue, out int driverId))
                        result = ClsDriver.FindDrivers(DriverID: driverId);
                    break;
                case 2: // Driver ID
                    if (int.TryParse(filterValue, out int personId))
                        result = ClsDriver.FindDrivers(PersonID: personId);
                    break;

                case 3: // National No
                    result = ClsDriver.FindDrivers(NationalNo: filterValue);
                    break;

                case 4: // Full Name
                    result = ClsDriver.FindDrivers(FullName: filterValue);
                    break;

                default:
                    result = null;
                    break;
            }

            if (result != null)
                dgvGetAllDrivers.DataSource = result;
            else
                dgvGetAllDrivers.DataSource = null;


            // لو المستخدم مسح حرف يرجع كل البيانات
            if (filterValue.Length < previousvalue.Length)
            {
                dgvGetAllDrivers.DataSource = ClsDriver.FindAllDrivers();
            }

            previousvalue = filterValue;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
