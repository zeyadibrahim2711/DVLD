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
    public partial class CalculatorUC : UserControl
    {
       // A User Control in C# is a reusable component that
       // combines multiple existing controls (like Button, TextBox, Label, etc.) into a single unit.
        public CalculatorUC()
        {
            InitializeComponent();
        }


        //If you want to allow the parent form (the form that uses your control) to access or modify some values inside your User Control,
        //you must expose them as public properties.
        public float Result
        {
            get { return (float)Convert.ToDouble(lbResults.Text);}
            set { lbResults.Text = value.ToString(); }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lbResults.Text = (int.Parse(textBox1.Text) + int.Parse(textBox2.Text)).ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            lbResults.Text = "";
        }
    }
}
