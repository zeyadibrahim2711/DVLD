using ApplicationTypesDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApplicationTyoesBusinessLayer
{
    public class ClsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        private ClsApplicationTypes(int applicationTypeID, string title, decimal fees)
        {
            ApplicationTypeID = applicationTypeID;
            Title = title;
            Fees = fees;
        }
        public static DataTable GetAllApplicationTypes()
        {
            return ClsApplicationTypesDataAccess.GetAllApplicationTypes();
        }

        
        public static ClsApplicationTypes Find(int applicationTypeID)
        {
            string title = "";
            decimal fees = 0;

            if (ClsApplicationTypesDataAccess.GetApplicationTypeByID(applicationTypeID,ref title,ref fees))
            {
                return new ClsApplicationTypes(applicationTypeID, title, fees);
            }
            else
            {
                return null;
            }
        }
        public bool _UpdateApplicationType()
        {
            return ClsApplicationTypesDataAccess.UpdateApplicationType(this.ApplicationTypeID, this.Title, this.Fees);
        }
    }
}
