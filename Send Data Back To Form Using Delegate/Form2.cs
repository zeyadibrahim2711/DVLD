using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Send_Data_Back_To_Form_Using_Delegate
{
    public partial class Form2 : Form
    {
        //  // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);
        //   A rule:
        //"If I call you, your method must look like this (object sender, int value)."
        //any method must look like (object, int).



        // Declare an event using the delegate
        public DataBackEventHandler DataBack;
        //A “list” where methods can subscribe.



        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int PersonID = int.Parse(txtPersonID.Text);

            // Trigger the event to send data back to Form1
            DataBack?.Invoke(this, PersonID);
            //Invoke means “run all the methods in the event list.” if not null             
            //The variable that can be null here is the event itself → DataBack.           




            //Check if the event DataBack has any methods (subscribers) attached.
            // If no one subscribed → DataBack is null.
            //If someone subscribed → DataBack is not null.
            //If it’s not null, call(run) all the subscribed methods one by one, passing the parameters(this, PersonID).
            //So yes: Invoke = run all subscribed methods.


            this.Close();

        }
    }
}
