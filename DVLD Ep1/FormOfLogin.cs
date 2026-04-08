using Microsoft.Win32;
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
    public partial class FormOfLogin : Form
    {
        clsUser _User; 
        public FormOfLogin()
        {
            InitializeComponent();
        }
        string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";

        string valueName = "User Name";
        string valueName2 = "Password";
        string valueName3 = "Remember Me";

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                int rememberMe = Convert.ToInt32(Registry.GetValue(KeyPath, valueName3, 0));

                if (rememberMe == 1)
                {
                    txtUserName.Text = Registry.GetValue(KeyPath, valueName, "") as string;
                    txtPassword.Text = Registry.GetValue(KeyPath, valueName2, "") as string;
                    chRemeberMe.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading saved data: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsUser.isUserExistByUserNameAndPassword(txtUserName.Text, txtPassword.Text))
                {
                    _User = clsUser.FindByUserName(txtUserName.Text);

                    if (chRemeberMe.Checked)
                    {
                        Registry.SetValue(KeyPath, valueName, txtUserName.Text, RegistryValueKind.String);
                        Registry.SetValue(KeyPath, valueName2, txtPassword.Text, RegistryValueKind.String);
                        Registry.SetValue(KeyPath, valueName3, 1, RegistryValueKind.DWord);
                    }
                    else
                    {
                        Registry.SetValue(KeyPath, valueName, "", RegistryValueKind.String);
                        Registry.SetValue(KeyPath, valueName2, "", RegistryValueKind.String);
                        Registry.SetValue(KeyPath, valueName3, 0, RegistryValueKind.DWord);
                    }

                    GlobalUser.CurrentUser = _User;

                    this.Hide();
                    HomeForm frm = new HomeForm(_User);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("User is not exist.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
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
