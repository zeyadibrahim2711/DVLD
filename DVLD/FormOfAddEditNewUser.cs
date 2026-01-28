using CountriesBusinessLayer;
using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusinessLayer;
using static System.Windows.Forms.AxHost;

namespace DVLD_Ep1
{
    public partial class FormOfAddEditNewUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _UserID;
        clsUser _User;

        public FormOfAddEditNewUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;//To use that ID later in the form (loading data, updating user),
                             // you must store it in a class-level field, which is _UserID.
            if (_UserID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
                _Mode = enMode.Update;
        }
        private void LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                lbMode.Text = "Add New User ";
                _User = new clsUser();
                return;
            }
            _User = clsUser.FindByUserID(_UserID);


            lbMode.Text = "Update User";
            groupBox2.Enabled = false;
            personDetalisUC1.LoadPersonInfo(_User.PersonID);

            // Fill textboxes
            lbUserIDInside.Text = _UserID.ToString();
            tbUserName.Text = _User.UserName;
            tbPassword.Text = _User.Password;
            tbConfirmPassword.Text = _User.Password; // confirm password gets the same value

            // If you also have IsActive
            if (_User.IsActive)
                cbIsActive.Checked = true;
            else
                cbIsActive.Checked = false;

            //// If user is linked to person
            //if (_User.PersonID > 0)
            //{
            //    tbPersonID.Text = _User.PersonID.ToString();
            //    tbFullName.Text = clsPerson.FindByID(_User.PersonID).FullName;
            //}

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormOfAddEditNewUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                _User.PersonID = result.PersonID;
            }

            _User.UserName = tbUserName.Text;
            _User.Password = tbPassword.Text;

            // Confirm password check
            if (tbPassword.Text == tbConfirmPassword.Text)
            {
                _User.Password = tbPassword.Text;
            }
            else
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            // IsActive from checkbox
            _User.IsActive = cbIsActive.Checked?true:false;

            if (_User.Save())

                MessageBox.Show("Data Saved Successfully.");
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            _Mode = enMode.Update;
            lbMode.Text = "Update User";
            lbUserIDInside.Text = _User.UserID.ToString();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form frm = new FormOfAddEditNewPerson(-1);
            frm.ShowDialog();
        }
        clsPerson result = null;
        private void btnPersonSearch_Click(object sender, EventArgs e)
        {
            // 1: PersonID, 2: NationalNo, 3: FirstName, 4: SecondName, 
            // 5: ThirdName, 6: LastName, 7: Gendor, 
            // 8: DateOfBirth, 9: Nationality, 10: Phone, 11: Email

            string filterValue = tbFilterBy.Text;

            

            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // PersonID
                    if (int.TryParse(filterValue, out int personId))
                        result = clsPerson.Find(personId);
                    else
                        result = null;
                    break;

                case 2: // NationalNo
                    result = clsPerson.Find(null, filterValue);
                    break;

                case 3: // FirstName
                    result = clsPerson.Find(null, null, filterValue);
                    break;

                case 4: // SecondName
                    result = clsPerson.Find(null, null, null, filterValue);
                    break;

                case 5: // ThirdName
                    result = clsPerson.Find(null, null, null, null, filterValue);
                    break;

                case 6: // LastName
                    result = clsPerson.Find(null, null, null, null, null, filterValue);
                    break;

                case 7: // Gendor
                        result = clsPerson.Find(null, null, null, null, null, null, filterValue);
                    break;

                case 8: // DateOfBirth
                    if (DateTime.TryParse(filterValue, out DateTime dob))
                        result = clsPerson.Find(null, null, null, null, null, null, null, dob);
                    else
                        result = null;
                    break;

                case 9: // Nationality
                    result = clsPerson.Find(null, null, null, null, null, null, null, null, filterValue);
                    break;

                case 10: // Phone
                    result = clsPerson.Find(null, null, null, null, null, null, null, null, null, filterValue);
                    break;

                case 11: // Email
                    result = clsPerson.Find(null, null, null, null, null, null, null, null, null, null, filterValue);
                    break;

                default: // All or unhandled
                    result = clsPerson.Find();
                    break;
            }


            if (result != null)
                personDetalisUC1.LoadPersonInfo(result.PersonID);
            else
            {
                MessageBox.Show("No Person With This Data Please Enter Right Input !", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFilterBy.Focus();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUser.isUserExistByPersonID(result.PersonID))
            {
                MessageBox.Show("Selected Person already has a user, choose another person ","Selected Another Person",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                tabControl1.SelectedTab = tabPage2;
        }
    }
}
