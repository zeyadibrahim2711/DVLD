using DetainedLicenseDataAccessLayer;
using LicenseDataAccessLayer;
using LicensesBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LicensesBusinessLayer.ClsLicense;
using static System.Net.Mime.MediaTypeNames;

namespace DetainLicensesBusinessLayer
{
  
        public class ClsDetainedLicense
        {
            public enum enMode { AddNew = 0, Update = 1 }
            public enMode Mode = enMode.AddNew;

            public int DetainID { get; set; }
            public int LicenseID { get; set; }

            public DateTime DetainDate { get; set; }
            public decimal FineFees { get; set; }

            public int CreatedByUserID { get; set; }

            public bool IsReleased { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public int? ReleasedByUserID { get; set; }
            public int? ReleaseApplicationID { get; set; }

          //Add New
            public ClsDetainedLicense()
            {
                DetainID = -1;
                LicenseID = -1;

                DetainDate = DateTime.Now;
                FineFees = 0;

                CreatedByUserID = -1;

                IsReleased = false;
                ReleaseDate = null;
                ReleasedByUserID = null;
                ReleaseApplicationID = null;

                Mode = enMode.AddNew;
            }

            private ClsDetainedLicense(
                int detainID,
                int licenseID,
                DateTime detainDate,
                decimal fineFees,
                int createdByUserID,
                bool isReleased,
                DateTime? releaseDate,
                int? releasedByUserID,
                int? releaseApplicationID)
            {
                this.DetainID = detainID;
                this.LicenseID = licenseID;

                this.DetainDate = detainDate;
                this.FineFees = fineFees;
                this.CreatedByUserID = createdByUserID;

                this.IsReleased = isReleased;
                this.ReleaseDate = releaseDate;
                this.ReleasedByUserID = releasedByUserID;
                this.ReleaseApplicationID = releaseApplicationID;

                Mode = enMode.Update;
            }
            private bool _AddNewDetain()
            {
                this.DetainID = ClsDetainedLicenseDataAccess.AddNewDetain(
                    LicenseID,
                    DetainDate,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID);

                return (DetainID != -1);
            }

            public bool Save()
            {
                if (Mode == enMode.AddNew)
                {
                    if (_AddNewDetain())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                }

                return false; 
            }
            public static DataTable FindDetainedLicenses(
   int? detainID = null,
int? nationalNO = null,
bool? isReleased = null,
int? releaseApplicationID = null,
 string fullName = null)
            {
                return ClsDetainedLicenseDataAccess
                    .FindDetainedLicense(
                        detainID,
                       nationalNO,
                        isReleased,
                        releaseApplicationID,
                        fullName);
           // DataTable vs Constructor

            }
            public bool ReleaseLicense(DateTime ReleaseDate ,int ReleasedByUserID,int ReleaseApplicationID)
            {
                if (IsReleased)
                
                    return false;
                
                if (ClsDetainedLicenseDataAccess.ReleaseDetainedLicense(DetainID, ReleaseDate, ReleasedByUserID, ReleaseApplicationID))
                {
                    IsReleased = true;
                    this.ReleaseDate = ReleaseDate;
                    this.ReleasedByUserID = ReleasedByUserID;
                    this.ReleaseApplicationID = ReleaseApplicationID;
                    return true;
                }
                else
                {
                    return false;
                }            
            }
        public static ClsDetainedLicense FindDetainedLicenseByLicense(int LicenseID)
        {
            int detainID = -1;
            DateTime detainDate = DateTime.Now;
            decimal fineFees = 0;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime? releaseDate = null;         
            int? releasedByUserID = null;         
            int? releaseApplicationID = null;     

            if (ClsDetainedLicenseDataAccess.FindDetainByLicenseID(LicenseID,ref detainID,
                ref detainDate, ref fineFees,
                ref createdByUserID, ref isReleased, ref releaseDate,
                ref releasedByUserID, ref releaseApplicationID))
            {
                return new ClsDetainedLicense(detainID,LicenseID,detainDate, fineFees, createdByUserID,
                    isReleased, releaseDate,
                    releasedByUserID, releaseApplicationID
                );
            }

            return null; // Not Found
        }
        public static bool IsLicenseDetained(int LicenseID)
            {
                return ClsDetainedLicenseDataAccess.IsLicenseDetain(LicenseID);
            }
        public static bool IsLicenseDetainedByDetID(int DetainID)
        {
            return ClsDetainedLicenseDataAccess.IsLicenseDetainByDetainID(DetainID);
        }

        public static DataTable FindAllDetainedLicense()
            {
                return ClsDetainedLicenseDataAccess.GetAllDetainLicense();
            }

           

        }
    
}
