using DVLD_Ep1.Properties;
using PeopleBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DVLD_Ep1;
using CountriesBusinessLayer;


namespace DVLD_Ep1
{
    public partial class FormOfAddEditNewPerson : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _PersonID;
        clsPerson _Person;
        public FormOfAddEditNewPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            if (_PersonID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
                _Mode = enMode.Update;
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsPerson.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        private void LoadData()
        {
            _FillCountriesInComoboBox();
            cbCountry.SelectedIndex = 0;
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            if (_Mode==enMode.AddNew)
            {
                lbMode.Text = "Add New Perosn ";
                _Person = new clsPerson();
                return;
            }
            _Person = clsPerson.FindByID(_PersonID);

            lbMode.Text = "Update Person";
            lbPersonID2.Text = _Person.PersonID.ToString();
            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbNationalNumber.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.GenderByte == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountriesBusinessLayer.FindCountryByID(_Person.NationalityCountryID).CountryName);

            if (_Person.ImagePath!=null)
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }


            tbAddress.Text = _Person.Address;
        }
        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath!=pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath!="")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later  
                    }
                }
                if (pbPersonImage.ImageLocation!="")
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();
                    if (ClsUtl.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }


        private void FormOfAddEditNewPerson_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbNationalNumber_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!_HandlePersonImage())
            {
                return;
            }
            _Person.FirstName = tbFirstName.Text;
            _Person.SecondName = tbSecondName.Text;
            _Person.ThirdName = tbThirdName.Text;
            _Person.LastName = tbLastName.Text;
            _Person.GenderByte = (short)((rbMale.Checked == true) ? 0 : 1);
            _Person.NationalityCountryID = clsCountriesBusinessLayer.FindCountryByName(cbCountry.Text).CountryID;
            _Person.Phone = tbPhone.Text;
            _Person.Email = tbEmail.Text;
            _Person.Address = tbAddress.Text;
            _Person.NationalNo = tbNationalNumber.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = null;
            //Without else, the old image path would stay, which is incorrect.


            if (_Person.Save())

                MessageBox.Show("Data Saved Successfully.");
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            _Mode = enMode.Update;
            lbMode.Text = "Update Person";
            lbPersonID2.Text = _Person.PersonID.ToString();
        }

        private void tbNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            if (clsPerson.Find(null, tbNationalNumber.Text) != null)
            {
                e.Cancel = true;
                tbNationalNumber.Focus();
                errorProvider1.SetError(tbNationalNumber, "National Number is Used For Another Person");
            }
            else 
            {
                e.Cancel = false;
                errorProvider1.SetError(tbNationalNumber, "");
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Resources.Female_512;
            }
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (tbEmail.Text.Contains("@gmail.com")||tbEmail.Text==null)
            {
                e.Cancel = false;
                errorProvider1.SetError(tbEmail, "");
            }
            else
            {
                e.Cancel = true;
                tbEmail.Focus();
                errorProvider1.SetError(tbEmail, "Invalid Address Format !");
            }
        }

        private void llOpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                 pbPersonImage.Load(selectedFilePath);
               // llRemoveImage.Visible = true;
                // ...
            }
        }

        private void llOpenFileDialog_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(selectedFilePath);
                // llRemoveImage.Visible = true;
                // ...
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

