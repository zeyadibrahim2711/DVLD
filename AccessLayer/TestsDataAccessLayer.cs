using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestDataAccessLayer
{
    public class ClsTestDataAccess
    {
        public static int AddNewTest(int TestAppointmentID, int TestResult,
 string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Tests
(TestAppointmentID, TestResult, Notes, CreatedByUserID)
VALUES
(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestResult", TestResult);
                command.Parameters.AddWithValue("@Notes",(object)Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        TestID = insertedID;
                    }
                }
                catch
                {
                    TestID = -1;
                }
            }

            return TestID;
        }
        public static bool UpdateTest(int TestID, int TestAppointmentID, int TestResults,
 string Notes, int CreatedByUserID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
UPDATE Tests SET
    TestAppointmentID = @TestAppointmentID,
    TestResults = @TestResults,
    Notes = @Notes,
    CreatedByUserID = @CreatedByUserID
WHERE TestID = @TestID";




                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestID", TestID);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestResults", TestResults);
                command.Parameters.AddWithValue("@Notes", Notes);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }

            }
            return rowsAffected > 0;
        }


        public static bool GetTestByID(int TestID, ref int TestAppointmentID, ref int TestResults,
 ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Tests WHERE TestID = @TestID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        TestAppointmentID = (int)reader["TestAppointmentID"];
                        TestResults = (int)reader["TestResults"];
                        Notes = reader["Notes"] == DBNull.Value ? string.Empty : reader["Notes"].ToString();
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }

                    reader.Close();
                }
                catch
                {
                    isFound = false;
                }
            }

            return isFound;
        }





        public static bool GetTestByTestAppointmentID(ref int TestID,int TestAppointmentID, ref int TestResults,
ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Tests WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        TestID = (int)reader["TestID"];
                        TestResults = (int)reader["TestResults"];
                        Notes = reader["Notes"] == DBNull.Value ? string.Empty : reader["Notes"].ToString();
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }

                    reader.Close();
                }
                catch
                {
                    isFound = false;
                }
            }

            return isFound;
        }


        public static bool IsTestExist(int TestAppointmentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM Tests WHERE  TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static bool IsTestPassed(int TestAppointmentID)
        {
            bool isPassed = false;

            SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
        SELECT 1
        FROM Tests
        WHERE TestAppointmentID = @TestAppointmentID
        AND TestResult = 1"; // 1 = Pass

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isPassed = reader.HasRows;

                reader.Close();
            }
            catch
            {
                isPassed = false;
            }
            finally
            {
                connection.Close();
            }

            return isPassed;
        }


        public static bool IsTestPassedByLocalIDAndTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool isPassed = false;

            SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
     SELECT  1
    FROM TestAppointments TA
    INNER JOIN Tests T
        ON T.TestAppointmentID = TA.TestAppointmentID
    WHERE
        TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
        AND TA.TestTypeID = @TestTypeID
        AND T.TestResult = 0"; 

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isPassed = reader.HasRows;

                reader.Close();
            }
            catch
            {
                isPassed = false;
            }
            finally
            {
                connection.Close();
            }

            return isPassed;
        }


        public static int GetTakenTestsCount(int localDrivingLicenseApplicationID,int testTypeID)
        {
            int count = 0;

            string query = @"
        SELECT ISNULL((
            SELECT TakenTestsCount
            FROM vw_Local_TestType_TakenTests_Count
            WHERE LocalDrivingLicenseApplicationID = @LocalID
              AND TestTypeID = @TestTypeID), 0);";

            using (SqlConnection conn =new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@LocalID", SqlDbType.Int).Value = localDrivingLicenseApplicationID;
                cmd.Parameters.Add("@TestTypeID", SqlDbType.Int).Value = testTypeID;

                conn.Open();
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return count;
        }

    }


}

