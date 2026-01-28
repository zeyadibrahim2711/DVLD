using System;
using System.Data;
using LicenseClassesDataAccessLayer;

namespace LicenseClassesBusinessLayer
{
    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        // ---------------------------------------------------------
        // Constructor (Add New)
        // ---------------------------------------------------------
        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;

            Mode = enMode.AddNew;
        }

        // ---------------------------------------------------------
        // Private Constructor (Used internally by Find)
        // ---------------------------------------------------------
        private clsLicenseClass(
            int licenseClassID,
            string className,
            string classDescription,
            int minimumAllowedAge,
            int defaultValidityLength,
            decimal classFees)
        {
            this.LicenseClassID = licenseClassID;
            this.ClassName = className;
            this.ClassDescription = classDescription;
            this.MinimumAllowedAge = minimumAllowedAge;
            this.DefaultValidityLength = defaultValidityLength;
            this.ClassFees = classFees;

            Mode = enMode.Update;
        }

        // ---------------------------------------------------------
        // Find by ID
        // ---------------------------------------------------------
        public static clsLicenseClass FindLicenseClassByID(int LicenseClassID)
        {
            string className = "";
            string classDescription = "";
            int minimumAllowedAge = 18;
            int defaultValidityLength = 10;
            decimal classFees = 0;

            if (clsLicenseClassesDataAccess.GetLicenseClassInfo(
                LicenseClassID,
                ref className,
                ref classDescription,
                ref minimumAllowedAge,
                ref defaultValidityLength,
                ref classFees
            ))
            {
                return new clsLicenseClass(
                    LicenseClassID,
                    className,
                    classDescription,
                    minimumAllowedAge,
                    defaultValidityLength,
                    classFees
                );
            }

            return null; // Not found
        }
        public static clsLicenseClass FindLicenseClassByClassName(string ClassName)
        {
            int licenseClassID = -1;
            string classDescription = "";
            int minimumAllowedAge = 18;
            int defaultValidityLength = 10;
            decimal classFees = 0;

            if (clsLicenseClassesDataAccess.GetLicenseClassInfoByName(
                ClassName,
                ref licenseClassID,
                ref classDescription,
                ref minimumAllowedAge,
                ref defaultValidityLength,
                ref classFees))
            {
                return new clsLicenseClass(
                    licenseClassID,
                    ClassName,
                    classDescription,
                    minimumAllowedAge,
                    defaultValidityLength,
                    classFees
                );
            }

            return null;
        }


        // ---------------------------------------------------------
        // Get All License Classes
        // ---------------------------------------------------------
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClasses();
        }

        // ---------------------------------------------------------
        // Add New Record
        // ---------------------------------------------------------
        private bool _AddNewLicenseClass()
        {
            int newID = clsLicenseClassesDataAccess.AddNewLicenseClass(
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees
            );

            if (newID != -1)
            {
                this.LicenseClassID = newID;
                return true;
            }

            return false;
        }

        // ---------------------------------------------------------
        // Update Existing Record
        // ---------------------------------------------------------
        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassesDataAccess.UpdateLicenseClass(
                this.LicenseClassID,
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees
            );
        }

        // ---------------------------------------------------------
        // Save (Add or Update)
        // ---------------------------------------------------------
        public bool SaveLicenseClass()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicenseClass();

                default:
                    return false;
            }
        }

        // ---------------------------------------------------------
        // Delete
        // ---------------------------------------------------------
        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            return clsLicenseClassesDataAccess.DeleteLicenseClass(LicenseClassID);
        }

        // ---------------------------------------------------------
        // Exists
        // ---------------------------------------------------------
        public static bool ExistsLicenseClass(int LicenseClassID)
        {
            return clsLicenseClassesDataAccess.IsLicenseClassExist(LicenseClassID);
        }
    }
}
