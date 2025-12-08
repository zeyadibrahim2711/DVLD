using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Send_Data_Back_To_Form_Using_Delegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenForm2_Click(object sender, EventArgs e)
        {

            Form2 frm2 = new Form2();

            // Form2 frm2; → Create an empty variable named frm2.

            //new Form2(); → Create a new Form2 object in memory.

            //= → Connect frm2 to that new object.


            //Here, the variable type is Form2.
            // That means frm2 knows about all the special things inside Form2
            // (like your custom event DataBack, custom controls, etc.).



            // Form frm2 = new Form2();
            //This is allowed because every Form2 is also a Form.
            //Now, the variable type is only Form (the base class).
            //frm2 will only know about the standard Form members(like.ShowDialog(), .Close(), etc.).
            //❌ You will not be able to access frm2.DataBack because DataBack is specific to Form2, not to the base Form.




            frm2.DataBack += Form2_DataBack;// Subscribe to the event
            frm2.ShowDialog();
        }
        private void Form2_DataBack(object sender,int PersonID)
        {
            // Handle the data received from Form2
            textBox1.Text = PersonID.ToString();
        }
    }
}
