using ApplicationDataAccessLayer;
using ApplicationsBusinessLayer;
using LocalDrivingLicenseApplicationDataAccessLayer;
using PeopleBusinessLayer;
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppointmentDataAccessLayer;
using UsersDataAccessLayer;

namespace TestAppiontmentBusinessLayer
{
    public class ClsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }


        public ClsTestAppointment()
        {
            TestAppointmentID = -1;
            TestTypeID = -1;
            LocalDrivingLicenseApplicationID = -1;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            IsLocked = false;
            Mode = enMode.AddNew;
        }
        private ClsTestAppointment(int testAppointmentID, int testTypeID,int localDrivingLicenseApplicationID,
            DateTime appointmentDate, decimal paidFees,int createdByUserID,bool isLocked)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.IsLocked = isLocked;

            Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = ClsTestAppointmentDataAccess.AddNewTestAppointment( this.TestTypeID,this.LocalDrivingLicenseApplicationID,
this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);

            return (this.TestAppointmentID != -1);
        }


        private bool _UpdateTestAppointment()
        {
            return ClsTestAppointmentDataAccess.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID,
this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked);
        }


        public bool SaveTestAppointment()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTestAppointment();
                default:
                    return false;
            }
        }

        public static ClsTestAppointment FindTestAppointmentByID(int TestAppointmentID)
        {
            int TestTypeID = -1; int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0; int CreatedByUserID = -1; bool IsLocked = false;
          
           
            if (ClsTestAppointmentDataAccess.GetTestAppointmentByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate,
                ref PaidFees, ref CreatedByUserID, ref IsLocked))
            {

                return new ClsTestAppointment(TestAppointmentID, TestTypeID,  LocalDrivingLicenseApplicationID,  AppointmentDate,
                 PaidFees,  CreatedByUserID, IsLocked);
            }
            else
            {
                return null;
            }
        }
        public static ClsTestAppointment FindLatestTestAppointmentForLocalIDAndTestTypeID(int LocalDrivingLicenseApplicationID,int TestTypeID )
        {
            int TestAppointmentID=-1;
           
            DateTime AppointmentDate = DateTime.Now; decimal PaidFees = 0; int CreatedByUserID = -1; bool IsLocked = false;


            if (ClsTestAppointmentDataAccess.GetLatestTestAppointmentForLocalIDAndTestTypeID(ref TestAppointmentID,TestTypeID,  LocalDrivingLicenseApplicationID, ref AppointmentDate,
                ref PaidFees, ref CreatedByUserID, ref IsLocked))
            {

                return new ClsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate,
                 PaidFees, CreatedByUserID, IsLocked);
            }
            else
            {
                return null;
            }
        }


        public static DataTable FindTestAppointment(int rowscount, int localDrivingLicenseApplicationID,int testTypeID)
        {
            return ClsTestAppointmentDataAccess.FindTestAppointment(rowscount, localDrivingLicenseApplicationID,testTypeID);
        }
        public static int CountTestAppointmentinDGV (int rowscount ,  int localDrivingLicenseApplicationID)
        {
            return ClsTestAppointmentDataAccess.CountRowsinDGV(rowscount,localDrivingLicenseApplicationID);
        }


        public static bool IsTestAppointmentExist(int localDrivingLicenseApplicationID)
        {
            return ClsTestAppointmentDataAccess.IsPersonHaveActiveTestAppointment(localDrivingLicenseApplicationID);
        }


        public static int CountTestAppointmentExist(
      int localDrivingLicenseApplicationID,
      string className,
      string fullName,
      int testTypeID)
        {
            return ClsTestAppointmentDataAccess.CountTestAppointmentExist(
                localDrivingLicenseApplicationID,
                className,
                fullName,
                testTypeID);
        }

        public static int CountPassedTests(int LocalDrivingLicenseApplicationID)
        {
            return ClsTestAppointmentDataAccess.CountPassedTests(LocalDrivingLicenseApplicationID);
        }

    }
}
