using InternationalLicenseDataAccessLayer;
using LicenseDataAccessLayer;
using LocalDrivingLicenseApplicationDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LicensesBusinessLayer.ClsLicense;

namespace InternationalLicenseBusinessLayer
{
    public class ClsInternationalLicense
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        // Constructor (Add New)
        public ClsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = true;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        // Constructor (Update / Load From DB)
        private ClsInternationalLicense(int internationalLicenseID, int applicationID, int driverID,
            int issuedUsingLocalLicenseID, DateTime issueDate, 
            DateTime expirationDate,bool isActive, int createdByUserID)
        {
            this.InternationalLicenseID = internationalLicenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = ClsInternationalLicenseDataAccess.AddNewInternationalLicense(
                ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                IssueDate, ExpirationDate, IsActive,CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            return ClsInternationalLicenseDataAccess.UpdateInternationalLicense(
               InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                IssueDate, ExpirationDate, 
               IsActive,CreatedByUserID);
        }
        public bool SaveInternationalLicense()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateInternationalLicense();

                default:
                    return false;
            }
        }
        public static ClsInternationalLicense FindInternationalLicenseByID(int InternationalLicenseID)
        {
            int applicationID = -1;
            int driverID = -1;
            int issuedUsingLocalLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;

            if (ClsInternationalLicenseDataAccess.GetInternationalLicenseInfo(
                InternationalLicenseID,
                ref applicationID,
                ref driverID,
                ref issuedUsingLocalLicenseID,
                ref issueDate,
                ref expirationDate,
                ref isActive,
                ref createdByUserID))
            {
                return new ClsInternationalLicense(
                    InternationalLicenseID,
                    applicationID,
                    driverID,
                    issuedUsingLocalLicenseID,
                    issueDate,
                    expirationDate,
                    isActive,
                    createdByUserID);
            }

            return null; // Not Found
        }

        public static ClsInternationalLicense FindInternationalLicenseByAppID(int AppID)
        {
            int internationalLicenseID = -1;
            int driverID = -1;
            int issuedUsingLocalLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;

            if (ClsInternationalLicenseDataAccess.FindInternationalLicenseByAppID(
                ref internationalLicenseID,
                AppID,
                ref driverID,
                ref issuedUsingLocalLicenseID,
                ref issueDate,
                ref expirationDate,
                ref isActive,
                ref createdByUserID))
            {
                return new ClsInternationalLicense(
                    internationalLicenseID,
                    AppID,
                    driverID,
                    issuedUsingLocalLicenseID,
                    issueDate,
                    expirationDate,
                    isActive,
                    createdByUserID);
            }

            return null; // Not Found
        }
        public static ClsInternationalLicense FindInternationalLicenseByDriverID(int DriverID)
        {
            int internationalLicenseID = -1;
            int applicationID = -1;
            int issuedUsingLocalLicenseID = -1;
            DateTime issueDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now;
            bool isActive = false;
            int createdByUserID = -1;

            if (ClsInternationalLicenseDataAccess.FindInternationalLicenseByDriverID(
                ref internationalLicenseID,
                ref applicationID,
                 DriverID,
                ref issuedUsingLocalLicenseID,
                ref issueDate,
                ref expirationDate,
                ref isActive,
                ref createdByUserID))
            {
                return new ClsInternationalLicense(
                    internationalLicenseID,
                    applicationID,
                    DriverID,
                    issuedUsingLocalLicenseID,
                    issueDate,
                    expirationDate,
                    isActive,
                    createdByUserID);
            }

            return null; // Not Found
        }


        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            return ClsInternationalLicenseDataAccess.DeleteInternationalLicense(InternationalLicenseID);
        }

        public static bool ExistsInternationalLicense(int InternationalLicenseID)
        {
            return ClsInternationalLicenseDataAccess.IsInternationalLicenseExist(InternationalLicenseID);
        }
        public static bool ExistsInternationalLicenseByDriverID(int DriverID)
        {
            return ClsInternationalLicenseDataAccess.IsInternationalLicenseExistByDriverID(DriverID);
        }


        public static bool ExistsInternationalLicenseByAppID(int AppID)
        {
            return ClsInternationalLicenseDataAccess.IsInternationalLicenseExistByAppID(AppID);
        }
        public static DataTable FindAllInternationalLicensesForDriver(int DriverID)
        {
            return ClsInternationalLicenseDataAccess.GetAllInternationalDrivingLicenseForDriver(DriverID);
        }
        public static DataTable GetAllInternationalDrivingLicenseApplications()
        {
            return ClsInternationalLicenseDataAccess.GetAllInternationalDrivingLicenseApplications();
        }

        public static DataTable FindInternationalLicense(
    int? internationalLicenseID = null,
    int? applicationID = null,
    int? driverID = null,
    int? localLicenseID = null,
    DateTime? issueDate = null,
    DateTime? expirationDate = null,
    bool? isActive = null)
        {
            return ClsInternationalLicenseDataAccess
                .FindInternationalLicenses(
                    internationalLicenseID,
                    applicationID,
                    driverID,
                    localLicenseID,
                    issueDate,
                    expirationDate,
                    isActive);
        }
    }

}
