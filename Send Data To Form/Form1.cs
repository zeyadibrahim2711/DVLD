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

namespace Send_Data_To_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSendData_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            if (int.TryParse(txtPersonID.Text, out PersonID))//If the conversion succeeds → it returns true.
            {                                                // If the conversion fails(e.g., user typed "abc") → it returns false instead of throwing an error.
                Form frm = new Form2(PersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("PersonID should be a number!");
                txtPersonID.Focus();
            }
        }
    }
}
