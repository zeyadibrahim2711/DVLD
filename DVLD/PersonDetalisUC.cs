using CountriesBusinessLayer;
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
    public partial class PersonDetalisUC : UserControl
    {
        private clsPerson _Person;
        public PersonDetalisUC()
        {
            InitializeComponent();

        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.FindByID(PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }


        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
          
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblFullName.Text = _Person.FullName;
            lblGendor.Text = _Person.GenderByte == 0 ? "Male" : "Female";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountriesBusinessLayer.FindCountryByID(_Person.NationalityCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            if (_Person.ImagePath != null)
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }
        }
        private void PersonDetalisUC_Load(object sender, EventArgs e)
        {

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormOfAddEditNewPerson frm = new FormOfAddEditNewPerson(_Person.PersonID);
            frm.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
