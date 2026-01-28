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
    public partial class FormOfSechudleVisionTest : Form
    {
        public FormOfSechudleVisionTest(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            InitializeComponent();
            secudleTest1.LoadTestAppointmentInfo(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        private void secudleTest1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
