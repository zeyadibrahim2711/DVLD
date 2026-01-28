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
    public partial class FormOfUserDetails : Form
    {
        public FormOfUserDetails(int UserID, int PersonID,string Title)
        {
            InitializeComponent();
            if (Title!=null)
            {
                lbTitle.Text = Title;
            }

            personDetalisUC1.LoadPersonInfo(PersonID);
            userDetailsUC1.LoadUserInfo(UserID);
        }

        private void personDetalisUC1_Load(object sender, EventArgs e)
        {

        }

        private void userDetailsUC1_Load(object sender, EventArgs e)
        {

        }

        private void FormOfUserDetails_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
