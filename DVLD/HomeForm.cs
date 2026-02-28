using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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

            FormOfDrivers frm = new FormOfDrivers();
            frm.MdiParent = this;//This new form (frm) should open inside the parent form (this),
                                 //not as a separate window.
            frm.Show();
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
            FormOfRealseDetainLicense frm = new FormOfRealseDetainLicense(-1);
            frm.ShowDialog();
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

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfAddInternationalDrivigLicenseApp frm = new FormOfAddInternationalDrivigLicenseApp();
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfinternationalLicenseApp frm = new FormOfinternationalLicenseApp();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfRenewLicesneApp frm = new FormOfRenewLicesneApp();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfReplacementLicense frm = new FormOfReplacementLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfDetainLicense frm = new FormOfDetainLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOfListDetainLicenses frm = new FormOfListDetainLicenses();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
