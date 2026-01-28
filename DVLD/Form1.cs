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
    public partial class Form1 : Form
    {
        clsUser _User; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                txtUserName.Text = Properties.Settings.Default.SavedUserName;
                txtPassword.Text = Properties.Settings.Default.SavedPassword;
                chRemeberMe.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (clsUser.isUserExistByUserNameAndPassword(txtUserName.Text, txtPassword.Text))
            {
                _User = clsUser.FindByUserName(txtUserName.Text);
                if (chRemeberMe.Checked)
                {
                    Properties.Settings.Default.SavedUserName = txtUserName.Text;
                    Properties.Settings.Default.SavedPassword = txtPassword.Text;
                    Properties.Settings.Default.RememberMe =true;
                }
                else
                {
                    Properties.Settings.Default.SavedUserName = "";
                    Properties.Settings.Default.SavedPassword = "";
                    Properties.Settings.Default.RememberMe = false;
                }
                Properties.Settings.Default.Save();
                GlobalUser.CurrentUser = _User;

                this.Hide();
                HomeForm frm = new HomeForm(_User);
                frm.Show();
            }
            else
            {
                MessageBox.Show("User is not exist .");
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
