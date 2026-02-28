using ApplicationDataAccessLayer;
using ApplicationsBusinessLayer;
using LocalDrivingLicenseApplicationDataAccessLayer;
using PeopleBusinessLayer;
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppointmentDataAccessLayer;
using TestDataAccessLayer;
using UsersDataAccessLayer;

namespace TestAppiontmentBusinessLayer
{
    public class ClsTest
    {
        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }


        public enum enTestResult { Fail = 0, Pass = 1 };

        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public enTestResult TestResult { get; set; }

        public ClsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = enTestResult.Pass;
            Notes = "";
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        private ClsTest(int testID, int testAppointmentID, enTestResult testResult,
                 string notes, int createdByUserID)
        {
            this.TestID = testID;
            this.TestAppointmentID = testAppointmentID;
            this.TestResult = testResult;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            this.TestID = ClsTestDataAccess.AddNewTest(this.TestAppointmentID, (int)this.TestResult,
this.Notes, this.CreatedByUserID);

            return (this.TestID != -1);
        }


        private bool _UpdateTest()
        {
            return ClsTestDataAccess.UpdateTest(this.TestID, this.TestAppointmentID, (int)this.TestResult,
this.Notes, this.CreatedByUserID);
        }


        public bool SaveTest()
        {
           
               
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
            {
                return false;
            }

                  
               
        }

        public static ClsTest FindTestByID(int TestID)
        {
            int TestAppointmentID = -1;
            int TestResults = -1;
            string Notes = string.Empty;
            int CreatedByUserID = -1;



            if (ClsTestDataAccess.GetTestByID(TestID, ref TestAppointmentID, ref TestResults,
          ref Notes, ref CreatedByUserID))
            {
                return new ClsTest(TestID, TestAppointmentID, (enTestResult)TestResults, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static ClsTest FindTestByTestAppointmentID(int testAppointmentID)
        {
            int TestID = -1;
            int TestResults = -1;
            string Notes = string.Empty;
            int CreatedByUserID = -1;

            if (ClsTestDataAccess.GetTestByTestAppointmentID(ref TestID, testAppointmentID, ref TestResults, ref Notes, ref CreatedByUserID))
            {
                return new ClsTest(TestID, testAppointmentID, (enTestResult)TestResults, Notes, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static bool IsTestExistByAppointmentID (int testAppointmentID)
        {
            return ClsTestDataAccess.IsTestExist(testAppointmentID);
        }

        public static bool IsTestPassedByAppointmentID(int testAppointmentID)
        {
            return ClsTestDataAccess.IsTestPassed(testAppointmentID);
        }

        public static bool IsTestPassedByLocalIDandTestType(int localDrivingLicenseApplicationID, int testTypeID)
        {
            return ClsTestDataAccess.IsTestPassedByLocalIDAndTestType(localDrivingLicenseApplicationID,testTypeID);
        }

        public static int GetTakenTestsCount(int localDrivingLicenseApplicationID,int testTypeID)
        {
           
            if (localDrivingLicenseApplicationID <= 0)
                return 0;

            if (testTypeID <= 0)
                return 0;

           
            return ClsTestDataAccess.GetTakenTestsCount(localDrivingLicenseApplicationID, testTypeID);
        }


    }
}
