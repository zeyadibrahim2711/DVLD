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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace DVLD_Ep1
{
    public partial class UsersManagementForm : Form
    {
        public UsersManagementForm()
        {
            InitializeComponent();
        }
        private void _RefreshUsersList()
        {
            DataTable dt = clsUser.GetAllUsers();
            dvgGetAllRecordsForUsers.DataSource = dt;
            lbRecordsNum.Text = dt.Rows.Count.ToString();
        }

        private void UsersManagementForm_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            
            cbFilterBy.SelectedIndex = 0;
            tbFilterBy.Visible = false;
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
            // 1: UserID
            // 2: PersonID
            // 3: FullName
            // 4: UserName
            // 5: IsActive

            // Focus on  it .
            string filterValue = tbFilterBy.Text;

            clsUser result = null;

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // UserID
                    if (int.TryParse(filterValue, out int userId))
                        result = clsUser.Find(userId);
                    break;


                case 2: // PersonID
                    if (int.TryParse(filterValue, out int personId))
                        result = clsUser.Find(null, personId);
                    break;

                case 3: // FullName
                    result = clsUser.Find(null, null,filterValue);
                    break;

                case 4: // UserName
                    result = clsUser.Find(null, null, null, filterValue);
                    break;

                case 5: // IsActive
                    if (bool.TryParse(filterValue, out bool active))
                        result = clsUser.Find(null, null, null, null, active);
                    break;

                default:
                    result = null;
                    break;
            }

            
            if (result != null)
                dvgGetAllRecordsForUsers.DataSource = clsUser.ConvertUserToDataTable(result);
            else
                dvgGetAllRecordsForUsers.DataSource = null;


            
            if (filterValue.Length < previousvalue.Length)
            {
                dvgGetAllRecordsForUsers.DataSource = clsUser.GetAllUsers();
            }

            previousvalue = filterValue;

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            FormOfAddEditNewUser frm = new FormOfAddEditNewUser(-1);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfUserDetails frm = new FormOfUserDetails((int)dvgGetAllRecordsForUsers.CurrentRow.Cells[0].Value,(int)dvgGetAllRecordsForUsers.CurrentRow.Cells[1].Value,null);
            frm.ShowDialog();
        }

        private void dvgGetAllRecordsForUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfAddEditNewUser frm = new FormOfAddEditNewUser(-1);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfAddEditNewUser frm = new FormOfAddEditNewUser((int)dvgGetAllRecordsForUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete User[" + dvgGetAllRecordsForUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dvgGetAllRecordsForUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.");
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("User is Not Deleted .");
                }
            }
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfChangePassword frm = new FormOfChangePassword((int)dvgGetAllRecordsForUsers.CurrentRow.Cells[0].Value, (int)dvgGetAllRecordsForUsers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
