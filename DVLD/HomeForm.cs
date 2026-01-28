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
    public partial class HomeForm : Form
    {
        clsUser _User;
        public HomeForm(clsUser user )
        {
            _User = user;
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeopleManagementForm frm = new PeopleManagementForm();
            frm.MdiParent = this;//This new form (frm) should open inside the parent form (this),
                                 //not as a separate window.
            frm.Show();

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersManagementForm frm = new UsersManagementForm();
            frm.MdiParent = this;//This new form (frm) should open inside the parent form (this),
                                 //not as a separate window.
            frm.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfUserDetails frm = new FormOfUserDetails(_User.UserID, _User.PersonID, "Current User Information");
            frm.ShowDialog();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfChangePassword frm = new FormOfChangePassword(_User.UserID, _User.PersonID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
            this.Close();
        }

        private void relaseDetainToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfApplicationTypes frm = new FormOfApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfTestTypes frm = new FormOfTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfAddEditLocalDrivingLicenseApplication frm = new FormOfAddEditLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfLocalDrivingLicenseApplication frm = new FormOfLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }
    }
}
