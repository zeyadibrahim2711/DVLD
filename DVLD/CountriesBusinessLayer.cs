using CountriesDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CountriesBusinessLayer
{
    public class clsCountriesBusinessLayer
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode { get; set; }

        // Default constructor (AddNew mode)
        public clsCountriesBusinessLayer()
        {
            this.CountryID = -1;
            this.CountryName = "";
            Mode = enMode.AddNew;
        }

        // Private constructor (used internally when reading from DB)
        private clsCountriesBusinessLayer(int countryID, string countryName)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
            Mode = enMode.Update;
        }

        // Static Find method (reads a country by ID)
        public static clsCountriesBusinessLayer FindCountryByID(int CountryID)
        {
            string countryName = "";

            bool isFound = clsCountriesDataAccess.GetCountryInfoByID(CountryID, ref countryName);

            if (isFound)
                return new clsCountriesBusinessLayer(CountryID, countryName);
            else
                return null;
        }
        public static clsCountriesBusinessLayer FindCountryByName(string countryName)
        {
            int CountryID =0;

            bool isFound = clsCountriesDataAccess.GetCountryInfoByName(ref CountryID, countryName);

            if (isFound)
                return new clsCountriesBusinessLayer(CountryID, countryName);
            else
                return null;
        }
    }
}
