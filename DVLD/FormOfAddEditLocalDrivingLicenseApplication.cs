using ApplicationsBusinessLayer;
using CountriesBusinessLayer;
using LicenseClassesBusinessLayer;
using LocalDrivingLicenseApplicationBuisnessLayer;
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
using UsersBusinessLayer;

namespace DVLD_Ep1
{
    public partial class FormOfAddEditLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _LocalID;
        ClsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public static string DateToShort(DateTime Dt1)
        {
            return Dt1.ToString("dd/MMM/yyyy");
        }
        public FormOfAddEditLocalDrivingLicenseApplication(int LocalID)
        {

            InitializeComponent();
            _LocalID = LocalID;
            _Mode = enMode.Update;
        }
        public FormOfAddEditLocalDrivingLicenseApplication()
        {

            InitializeComponent();
            _Mode = enMode.AddNew;
            
        }
        private void UpdateMood()
        {
            lbMode.Text = "Update Local Driving License Application";
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LocalID);
            groupBox2.Enabled = false;
            personDetalisUC1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lbDLApplicationIDInside.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbApplicationDateInside.Text = DateToShort(_LocalDrivingLicenseApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lbApplicationFeesinside.Text = "15";
            lbCreatedByinside.Text = GlobalUser.CurrentUser.UserName;

        }
        private void CreateNewLocalDrivingLicense(int VlicenseClassID, int PersonID)
        {
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicantPersonID = PersonID;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = 15;
            _LocalDrivingLicenseApplication.LicenseClassID = VlicenseClassID;
            _LocalDrivingLicenseApplication.ApplicationStatus = ClsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.CreatedByUserID = GlobalUser.CurrentUser.UserID;
        }
        private void _FillLicensesClassesInComoboBox()
        {
            DataTable dtLicensesClasses = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow row in dtLicensesClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }
        private void LoadData()
        {
            _FillLicensesClassesInComoboBox();
            cbLicenseClass.SelectedIndex = 2;
             lbApplicationFeesinside.Text = "15";
            lbCreatedByinside.Text = GlobalUser.CurrentUser.UserName;
            if (_Mode == enMode.AddNew)
            {

                lbMode.Text = "New Local Driving License Application ";
                lbApplicationDateInside.Text = DateToShort(DateTime.Now);
                _LocalDrivingLicenseApplication = new ClsLocalDrivingLicenseApplication();
                return;
            }
            UpdateMood();
        }

        private void FormOfAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        clsPerson result = null;
        private void btnPersonSearch_Click(object sender, EventArgs e)
        {
            // 1: PersonID, 2: NationalNo, 3: FirstName, 4: SecondName, 
            // 5: ThirdName, 6: LastName, 7: Gendor, 
            // 8: DateOfBirth, 9: Nationality, 10: Phone, 11: Email

            string filterValue = tbFilterBy.Text;



            switch (cbFilterBy.SelectedIndex)
            {
                case 1: // PersonID
                    if (int.TryParse(filterValue, out int personId))
                        result = clsPerson.FindByID(personId);
                    else
                        result = null;
                    break;

                case 2: // NationalNo
                    result = clsPerson.FindByNationalNo(filterValue);
                    break;
                default: // All or unhandled
                    result = null;
                    break;
            }

            if (result != null)
                personDetalisUC1.LoadPersonInfo(result.PersonID);
            else
            {
                MessageBox.Show("No Person With This Data Please Enter Right Input !", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFilterBy.Focus();
            }

        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form frm = new FormOfAddEditNewPerson(-1);
            frm.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (result==null)
            {
                MessageBox.Show("You Must Select a Person", "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
                tabControl1.SelectedTab = tabPage2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int VlicenseClassID= clsLicenseClass.FindLicenseClassByClassName(cbLicenseClass.Text).LicenseClassID;
            int PersonID = (_Mode == enMode.AddNew)
         ? result.PersonID
         : ClsLocalDrivingLicenseApplication.FindLocalDrivingLicenseApplicationByID(_LocalID).ApplicantPersonID;


            if (ClsLocalDrivingLicenseApplication.DoesNewApplicationExist(PersonID, VlicenseClassID))
            {
                MessageBox.Show("This person already has a NEW application for this license class.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CreateNewLocalDrivingLicense(VlicenseClassID, PersonID);


            if (_LocalDrivingLicenseApplication.SaveLocalDrivingLicenseApplication())

                MessageBox.Show("Data Saved Successfully.");
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
                return;
            }

            _Mode = enMode.Update;
            lbMode.Text = "Update Local Driving License Application";
            lbDLApplicationIDInside.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personDetalisUC1_Load(object sender, EventArgs e)
        {

        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
