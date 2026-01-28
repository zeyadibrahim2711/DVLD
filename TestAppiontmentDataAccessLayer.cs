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

        public static DataTable FindTestAppointment(int RowsCount)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
        SELECT TOP (@RowsCount) *
        FROM vw_TestAppointmentsBasic
        ORDER BY AppointmentID DESC;
        ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RowsCount", RowsCount);

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
        }

        public static int CountTestExist(
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
        FROM CheckExesitingTests
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

    }

}
