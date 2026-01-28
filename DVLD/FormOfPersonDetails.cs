using PeopleBusinessLayer;
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
    public partial class FormOfPersonDetails : Form
    {
        
        public FormOfPersonDetails(int PersonID)
        {

            InitializeComponent();
            personDetalisUC1.LoadPersonInfo(PersonID);
        }

        private void FormOfPersonDetails_Load(object sender, EventArgs e)
        {
           
        }

        private void addEditPersonUC1_Load(object sender, EventArgs e)
        {

        }

        private void personDetalisUC1_Load(object sender, EventArgs e)
        {

        }
    }
}
