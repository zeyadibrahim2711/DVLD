using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleBusinessLayer;

namespace DVLD_Ep1
{
    public partial class PeopleManagementForm : Form
    {
        private void _RefreshPeopleList()
        {
            DataTable dt= clsPerson.GetAllPeople();
            dvgGetAllRecords.DataSource = dt;
            lbRecordsNum.Text = dt.Rows.Count.ToString();
        }
        public PeopleManagementForm()
        {
            InitializeComponent();
        }
        private void PeopleManagementForm_Load(object sender, EventArgs e)
        {
            
            _RefreshPeopleList();
            
            cbFilterBy.SelectedIndex = 0;
            tbFilterBy.Visible = false;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex!=0)
            {
                tbFilterBy.Visible = true;
            }
            if (cbFilterBy.SelectedIndex==0)
            {
                tbFilterBy.Visible = false;
            }
            dvgGetAllRecords.DataSource = clsPerson.GetAllPeople();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string previousvalue = "";
        private void tbFilterBy_TextChanged(object sender, EventArgs e)
        
        {
            // 1: PersonID, 2: NationalNo, 3: FirstName, 4: SecondName, 
            // 5: ThirdName, 6: LastName, 7: Gendor, 
            // 8: DateOfBirth, 9: Nationality, 10: Phone, 11: Email

            string filterValue = tbFilterBy.Text;
           
            DataTable result = null;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // PersonID
                    if (int.TryParse(filterValue, out int personId))
                        result = clsPerson.FindPersonInfo(personId:personId);
                    else
                        result = null;
                    break;

                case 2: // NationalNo
                    result = clsPerson.FindPersonInfo(nationalNo: filterValue);
                    break;

                case 3: // FirstName
                    result = clsPerson.FindPersonInfo(firstName: filterValue);
                    break;

                case 4: // SecondName
                    result = clsPerson.FindPersonInfo(secondName: filterValue);
                    break;

                case 5: // ThirdName
                    result = clsPerson.FindPersonInfo(thirdName: filterValue);
                    break;

                case 6: // LastName
                    result = clsPerson.FindPersonInfo(lastName: filterValue);
                    break;

                case 7: // Gendor
                  
                        result = clsPerson.FindPersonInfo(gendor:filterValue);
                    break;

                case 8: // DateOfBirth
                    if (DateTime.TryParse(filterValue, out DateTime dob))
                        result = clsPerson.FindPersonInfo(dateofbirth: dob);
                    else
                        result = null;
                    break;

                case 9: // Nationality
                    result = clsPerson.FindPersonInfo(nationality:filterValue);
                    break;

                case 10: // Phone
                    result = clsPerson.FindPersonInfo(phone: filterValue);
                    break;

                case 11: // Email
                    result = clsPerson.FindPersonInfo(email: filterValue);
                    break;

                default: // All or unhandled
                    result = clsPerson.FindPersonInfo();
                    break;
            }


            if (result != null)
            {
                dvgGetAllRecords.DataSource = result;
            }
            else
            {
                dvgGetAllRecords.DataSource = null;
            }


            if (filterValue.Length < previousvalue.Length)
            {
                dvgGetAllRecords.DataSource = clsPerson.GetAllPeople();
            }
            previousvalue = filterValue;

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form frm = new FormOfAddEditNewPerson(-1);
            frm.ShowDialog();
            _RefreshPeopleList();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfPersonDetails frm = new FormOfPersonDetails((int)dvgGetAllRecords.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfAddEditNewPerson frm = new FormOfAddEditNewPerson((int)dvgGetAllRecords.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete Person[" + dvgGetAllRecords.CurrentRow.Cells[0].Value + "]", "Confirm Delete ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dvgGetAllRecords.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Person is Not Deleted .");
                }
            }
        }

        private void dvgGetAllRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
