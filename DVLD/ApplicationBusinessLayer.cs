using ApplicationDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsBusinessLayer
{
    public class ClsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

       
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public enApplicationStatus ApplicationStatus { set; get; }

        public ClsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private ClsApplication(int applicationID, int applicantPersonID, DateTime applicationDate,
                          int applicationTypeID, enApplicationStatus applicationStatus, DateTime lastStatusDate,
                          decimal paidFees, int createdByUserID)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }
        private bool _AddNewApplication()
        {
            this.ApplicationID = ClsApplicationDataAccess.AddNewApplication(ApplicantPersonID, ApplicationDate,ApplicationTypeID,
              (byte)  ApplicationStatus, LastStatusDate, PaidFees,CreatedByUserID);

            return (ApplicationID != -1);
        }
        private bool _UpdateApplication()
        {
            return ClsApplicationDataAccess.UpdateApplication(ApplicationID,ApplicantPersonID, ApplicationDate, ApplicationTypeID,
               (byte)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }
        public bool SaveApplication()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateApplication();

                default:
                    return false;
            }
        }
        public static ClsApplication FindApplicationByID(int ApplicationID)
        {
            int applicantPersonID = -1;
            DateTime applicationDate = DateTime.Now;
            int applicationTypeID = -1;
            byte applicationStatus = 1;
            DateTime lastStatusDate = DateTime.Now;
            decimal paidFees = 0;
            int createdByUserID = -1;

            bool isFound = ClsApplicationDataAccess.GetApplicationByID(
                ApplicationID, ref applicantPersonID,ref applicationDate,ref applicationTypeID,ref applicationStatus,
    ref lastStatusDate,ref paidFees, ref createdByUserID);

            if (isFound)
            {
                return new ClsApplication(ApplicationID, applicantPersonID, applicationDate, applicationTypeID,(enApplicationStatus)applicationStatus,
lastStatusDate, paidFees, createdByUserID);
            }

            return null;
        }


        public static bool DeleteApplication(int applicationID)
        {
            return ClsApplicationDataAccess.DeleteApplication(applicationID);
        }

        public static bool IsApplicationExist(int applicationID)
        {
            return ClsApplicationDataAccess.IsApplicationExist(applicationID);
        }

    }
}
