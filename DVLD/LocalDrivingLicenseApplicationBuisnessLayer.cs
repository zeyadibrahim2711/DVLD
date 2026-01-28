using ApplicationsBusinessLayer;
using LocalDrivingLicenseApplicationDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDataAccessLayer;


namespace LocalDrivingLicenseApplicationBuisnessLayer
{
    public class ClsLocalDrivingLicenseApplication:ClsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }

        public ClsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            ApplicationID = -1;
            LicenseClassID = -1;
            Mode = enMode.AddNew;
        }
   
        private ClsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            Mode = enMode.Update;
        }
        public static ClsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationByID(int LocalID)
        {
            int AppID = -1, ClassID = -1;

            if (ClsLocalDrivingLicenseApplicationDataAccess.GetLocalDrivingLicenseApplicationByID(LocalID, ref AppID, ref ClassID))
                return new ClsLocalDrivingLicenseApplication(LocalID, AppID, ClassID);

            else
                return null;
        }
        private bool _AddNewLocalDrivingLicenseApplication()
        {
           this.LocalDrivingLicenseApplicationID = ClsLocalDrivingLicenseApplicationDataAccess.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return ClsLocalDrivingLicenseApplicationDataAccess.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return ClsLocalDrivingLicenseApplicationDataAccess.GetAllLocalDrivingLicenseApplications();
        }
        public static int CountTotalLocalDrivingLicenseApplications()
        {
            return ClsLocalDrivingLicenseApplicationDataAccess.CountLocalDrivingLicenseApplications();
        }
        public bool SaveLocalDrivingLicenseApplication()
        {
            base.Mode = (ClsApplication.enMode)Mode;
            if (!base.SaveApplication())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
                default:
                    return false;
            }
        }
        public static DataTable FindSingleLocalDrivingApp(int? AppID = null,string DrivingClass = null, string NationalNo = null,
       string FullName = null, DateTime? ApplicationDate = null,
       int? PassedTests = null, string Status = null)
        {
            return ClsLocalDrivingLicenseApplicationDataAccess.FindSingleLocalDrivingLicenseApplication(AppID, DrivingClass, NationalNo,
                FullName, ApplicationDate, PassedTests,Status);
        }
       
        
            public static bool DoesNewApplicationExist(int personId, int licenseClassId)
            {
                return ClsLocalDrivingLicenseApplicationDataAccess.CheckNewApplication(personId, licenseClassId);
            }
        

    }
}
