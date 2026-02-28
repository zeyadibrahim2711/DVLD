using LicenseClassesDataAccessLayer;
using LicenseDataAccessLayer;
using LocalDrivingLicenseApplicationBuisnessLayer;
using LocalDrivingLicenseApplicationDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensesBusinessLayer
{
    public class ClsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4
        };

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set; }
        public decimal PaidFees { get; set; }

        public bool IsActive { get; set; }
        public bool IsDetained { get; set; }
        public enIssueReason IssueReason { get; set; }

        public int CreatedByUserID { get; set; }

        public ClsLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = true;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private ClsLicense(int licenseID, int applicationID, int driverID, int licenseClass,
                           DateTime issueDate, DateTime expirationDate, string notes,
                           decimal paidFees, bool isActive, enIssueReason issueReason,
                           int createdByUserID)
        {
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.LicenseClass = licenseClass;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = ClsLicenseDataAccess.AddNewLicense(
                ApplicationID, DriverID, LicenseClass,
                IssueDate, ExpirationDate, Notes,
                PaidFees, IsActive, (byte)IssueReason,
                CreatedByUserID);

            return (LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return ClsLicenseDataAccess.UpdateLicense(
                LicenseID, ApplicationID, DriverID, LicenseClass,
                IssueDate, ExpirationDate, Notes,
                PaidFees, IsActive, (byte)IssueReason,
                CreatedByUserID);
        }
        public bool SaveLicense()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicense();

                default:
                    return false;
            }
        }
        public static ClsLicense FindLicenseByID(int LicenseID)
        {
            int applicationID = -1;
            int driverID = -1;
            int licenseClass = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            string notes = "";
            decimal paidFees = 0;
            bool isActive = false;
            byte issueReason = 1;
            int createdByUserID = -1;

            if (ClsLicenseDataAccess.GetLicenseInfo( LicenseID, ref applicationID,
                ref driverID, ref licenseClass,
                ref issueDate, ref expirationDate,ref notes,
                ref paidFees,   ref isActive,
                ref issueReason,  ref createdByUserID
            ))
            {
                return new ClsLicense( LicenseID, applicationID,driverID,licenseClass, issueDate, expirationDate,
                    notes,paidFees, isActive,(enIssueReason)issueReason,createdByUserID
                );
            }

            return null; // Not Found
        }

        public static ClsLicense FindLicenseByAppID(int AppID)
        {
            int LicenseID = -1;
            int driverID = -1;
            int licenseClass = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            string notes = "";
            decimal paidFees = 0;
            bool isActive = false;
            byte issueReason = 1;
            int createdByUserID = -1;

            if (ClsLicenseDataAccess.FindLicenseByAppID(ref LicenseID,  AppID,
                ref driverID, ref licenseClass,
                ref issueDate, ref expirationDate, ref notes,
                ref paidFees, ref isActive,
                ref issueReason, ref createdByUserID
            ))
            {
                return new ClsLicense(LicenseID, AppID, driverID, licenseClass, issueDate, expirationDate,
                    notes, paidFees, isActive, (enIssueReason)issueReason, createdByUserID
                );
            }

            return null; // Not Found
        }



        public static bool DeleteLicense(int LicenseID)
        {
            return ClsLicenseDataAccess.DeleteLicense(LicenseID);
        }

      
        public static bool ExistsLicense(int LicenseID)
        {
            return ClsLicenseDataAccess.IsLicenseExist(LicenseID);
        }

        public static bool IsLicenseExpired(int LicenseID)
        {
            return ClsLicenseDataAccess.IsLicenseExpire(LicenseID);
        }


        public static bool IsLicenseActive(int LicenseID, int LicenseClass)
        {
            return ClsLicenseDataAccess.IsLicenseActive(LicenseID, LicenseClass);
        }


        public static bool ExistsLicenseByAppID(int AppID)
        {
            return ClsLicenseDataAccess.IsLicenseExistByAppID(AppID);
        }

        public static bool CanIssueLicense(int localAppID)
        {
           
            ClsLocalDrivingLicenseApplication local =
                ClsLocalDrivingLicenseApplication
                .FindLocalDrivingLicenseApplicationByID(localAppID);

            if (local == null)
                return false;

            bool licenseExists = ExistsLicenseByAppID(local.ApplicationID);

            return !licenseExists;
        }

        public static DataTable FindAllLocalDrivingLicenseForDriver(int DriverID)
        {
            return ClsLicenseDataAccess.GetAllLocalDrivingLicenseForDriver(DriverID);
        }

      


    }
}
