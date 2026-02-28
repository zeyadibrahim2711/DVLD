using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestAppointmentDataAccessLayer
{
    public class ClsTestAppointmentDataAccess
    {
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
 DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int TestAppointmentID = -1;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
INSERT INTO TestAppointments
(TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
VALUES
(@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);
SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);


                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        TestAppointmentID = insertedID;
                    }
                }
                catch
                {
                    TestAppointmentID = -1;
                }
            }

            return TestAppointmentID;
        }
        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
 DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
UPDATE TestAppointments SET
    TestTypeID = @TestTypeID,
    LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
    AppointmentDate = @AppointmentDate,
    PaidFees = @PaidFees,
    CreatedByUserID = @CreatedByUserID,
    IsLocked = @IsLocked
WHERE TestAppointmentID = @TestAppointmentID";



                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", IsLocked);


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


        public static bool GetTestAppointmentByID(int TestAppointmentID,ref int TestTypeID,ref int LocalDrivingLicenseApplicationID,
 ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID,ref bool IsLocked)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;

                        TestTypeID = (int)reader["TestTypeID"];
                        LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                        AppointmentDate = (DateTime)reader["AppointmentDate"];
                        // Safe conversion with smallmoney
                        PaidFees = Convert.ToDecimal(reader["PaidFees"].ToString());
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsLocked = (bool)reader["IsLocked"];
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


        public static bool GetLatestTestAppointmentForLocalIDAndTestTypeID(ref int TestAppointmentID,  int TestTypeID,  int LocalDrivingLicenseApplicationID,
ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT Top 1 *  FROM TestAppointments Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
and TestTypeID= @TestTypeID
 order by TestAppointmentID desc";

                SqlCommand command = new SqlCommand(query, connection);
             
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;

                        TestAppointmentID = (int)reader["TestAppointmentID"];
                        AppointmentDate = (DateTime)reader["AppointmentDate"];
                        // Safe conversion with smallmoney
                        PaidFees = Convert.ToDecimal(reader["PaidFees"].ToString());
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        IsLocked = (bool)reader["IsLocked"];
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


        public static DataTable FindTestAppointment(int RowsCount, int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"    
SELECT TOP (@RowsCount) TestAppointmentID as AppointmentID,AppointmentDate,PaidFees,IsLocked
FROM TestAppointments
Where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
and TestTypeID=@TestTypeID
ORDER BY AppointmentID DESC;
;;
        ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RowsCount", RowsCount);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
//            تحط null لو الفلتر اختياري
// ما تحطش null لو القيمة إجبارية عشان الكويري تشتغل منطقيًا
        }

        public static int CountRowsinDGV(int RowsCount, int LocalDrivingLicenseApplicationID)
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
        SELECT COUNT(*)
        FROM (
          
SELECT TOP (@RowsCount) TestAppointmentID as AppointmentID,AppointmentDate,PaidFees,IsLocked
FROM TestAppointments
Where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
ORDER BY AppointmentID DESC
        ) AS T;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RowsCount", RowsCount);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                count = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }


        public static bool GetTestByID(
           int TestTypeID,
           ref string Title,
           ref string Description,
           ref decimal Fees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;

                        Title = reader["TestTypeTitle"].ToString();
                        Description = reader["TestTypeDescription"].ToString();

                        // Safe conversion with smallmoney
                        Fees = Convert.ToDecimal(reader["TestTypeFees"].ToString());
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

        public static int CountTestAppointmentExist(
    int localDrivingLicenseApplicationID,
    string className,
    string fullName,
    int testTypeID)
        {
            int count = 0;

            using (SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
        SELECT COUNT(*)
        FROM CheckExistingTests
        WHERE [LdL.AppID] = @LocalDrivingLicenseApplicationID
          AND [Driving Class] = @ClassName
          AND [Full Name] = @FullName
          AND [TestTypes] = @TestTypeID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID",
                                                    localDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@ClassName", className);
                    command.Parameters.AddWithValue("@FullName", fullName);
                    command.Parameters.AddWithValue("@TestTypeID", testTypeID);

                    try
                    {
                        connection.Open();
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        count = 0;
                    }
                }
            }

            return count;
        }

        public static bool IsPersonHaveActiveTestAppointment( int localDrivingLicenseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT 1 FROM TestAppointments WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and IsLocked != 1 ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

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
            }

            return isFound;
        }


        public static int CountPassedTests(int LocalDrivingLicenseApplicationID)
        {
            int count = 0;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*)
                         FROM Tests T
                         INNER JOIN TestAppointments TA
                         ON TA.TestAppointmentID = T.TestAppointmentID
                         WHERE TA.LocalDrivingLicenseApplicationID = @ID
                         AND T.TestResult = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", LocalDrivingLicenseApplicationID);

                connection.Open();
                count = (int)command.ExecuteScalar();
            }

            return count;
        }



    }

}


