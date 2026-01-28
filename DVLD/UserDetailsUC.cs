using CountriesBusinessLayer;
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
    public partial class UserDetailsUC : UserControl
    {
        private clsUser _User;
        public UserDetailsUC()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }
        private void _FillUserInfo()
        {
            lbUseridinside.Text = _User.UserID.ToString();
            lbUserNameinside.Text = _User.UserName;
            lbIsActiveinside.Text = _User.IsActive ? "Yes" : "NO";
        }

        private void UserDetailsUC_Load(object sender, EventArgs e)
        {

        }
    }
}
