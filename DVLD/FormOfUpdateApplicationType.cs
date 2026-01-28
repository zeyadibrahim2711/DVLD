using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationTyoesBusinessLayer;

namespace DVLD_Ep1
{
    public partial class FormOfUpdateApplicationType : Form
    {

        ClsApplicationTypes _AppType;
        int _AppTypeID;
        public FormOfUpdateApplicationType(int AppTypeID)
        {

            InitializeComponent();
            _AppTypeID = AppTypeID;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            _AppType = ClsApplicationTypes.Find(_AppTypeID);
            if (_AppType!=null)
            {
                lbIDinside.Text = _AppType.ApplicationTypeID.ToString();
                tbTitle.Text = _AppType.Title;
                tbFees.Text = _AppType.Fees.ToString();
            }
        }

        private void FormOfUpdateApplicationType_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _AppType.Title = tbTitle.Text;
            _AppType.Fees = Convert.ToDecimal(tbFees.Text);
            _AppType._UpdateApplicationType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
