using DriversDataAccessLayer;
using LocalDrivingLicenseApplicationDataAccessLayer;
using System;
using System.Data;

namespace DriversBusinessLayer
{
    public class ClsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

       
        public ClsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

   
        private ClsDriver(int driverID, int personID,
                          int createdByUserID, DateTime createdDate)
        {
            DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;

            Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            this.DriverID =
                ClsDriversDataAccess.AddNewDriver(
                    this.PersonID,
                    this.CreatedByUserID,
                    this.CreatedDate);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return ClsDriversDataAccess.UpdateDriver(
                this.DriverID,
                this.PersonID,
                this.CreatedByUserID,
                this.CreatedDate);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDriver();

                default:
                    return false;
            }
        }

      
        public static ClsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (ClsDriversDataAccess.GetDriverInfoByID(
                DriverID,
                ref PersonID,
                ref CreatedByUserID,
                ref CreatedDate))
            {
                return new ClsDriver(DriverID, PersonID,
                                     CreatedByUserID, CreatedDate);
            }

            return null;
        }

      
        public static ClsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (ClsDriversDataAccess.GetDriverInfoByPersonID(
                PersonID,
                ref DriverID,
                ref CreatedByUserID,
                ref CreatedDate))
            {
                return new ClsDriver(DriverID, PersonID,
                                     CreatedByUserID, CreatedDate);
            }

            return null;
        }
        public static DataTable FindDrivers( int? DriverID = null,int? PersonID = null,
    string NationalNo = null,string FullName = null)
        {
            return ClsDriversDataAccess.FindDrivers(DriverID, PersonID,
                NationalNo,FullName);
        }



        public static bool DriverExistByPersonID(int PersonID)
        {
            return ClsDriversDataAccess.IsDriverExistByPersonID(PersonID);
        }

        public static DataTable FindAllDrivers()
        {
            return ClsDriversDataAccess.GetAllDrivers();
        }
    
    }
}
