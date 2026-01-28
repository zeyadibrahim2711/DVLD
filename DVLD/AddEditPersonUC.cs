using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeopleBusinessLayer;


namespace DVLD_Ep1
{
    public partial class AddEditPersonUC : UserControl
    {
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsPerson.GetAllCountries();
            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        public AddEditPersonUC()
        {
            InitializeComponent();
        }

        private void AddEditPersonUC_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            _FillCountriesInComoboBox();
            cbCountry.SelectedIndex = 89;
        }
    }
}
