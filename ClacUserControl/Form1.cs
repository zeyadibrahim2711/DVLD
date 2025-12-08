using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClacUserControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculatorUC1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculatorUC1.Visible = true;
        }

        private void btnShowReslut_Click(object sender, EventArgs e)
        {
            MessageBox.Show(calculatorUC1.Result.ToString());
        }
    }
}
