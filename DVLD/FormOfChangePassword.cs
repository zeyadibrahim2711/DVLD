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
    public partial class FormOfChangePassword : Form
    {
        clsUser _User;


        public FormOfChangePassword(int userid, int personid)
        {
            InitializeComponent();
            _User = clsUser.FindByUserID(userid);
            userDetailsUC1.LoadUserInfo(userid);
            personDetalisUC1.LoadPersonInfo(personid);
        }

        private void personDetalisUC1_Load(object sender, EventArgs e)
        {

        }

        private void FormOfChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            _User.Password = tbNewPassword.Text;

            // Confirm password check
            if (tbNewPassword.Text == tbConfirmNewPassword.Text)
            {
                _User.Password = tbNewPassword.Text;
            }
            else
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            if (_User.ChangePassword(_User.UserID, tbCurrentPassword.Text, _User.Password))
            {
                MessageBox.Show("Data Saved Successfully.");
            }   
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
