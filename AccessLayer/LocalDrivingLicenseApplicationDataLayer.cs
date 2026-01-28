using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDrivingLicenseApplicationDataAccessLayer
{
    public class ClsLocalDrivingLicenseApplicationDataAccess
    {
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM vvwLocalDrivingLicenseApplications";

            SqlCommand command = new SqlCommand(query, connection);

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
        public static int CountLocalDrivingLicenseApplications()
        {
            int totalLocalDrivingLicenseApplications = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "\tselect Count (*) from vvwLocalDrivingLicenseApplications";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int total))
                {
                    totalLocalDrivingLicenseApplications = total;
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return totalLocalDrivingLicenseApplications;
        }
        public static DataTable FindSingleLocalDrivingLicenseApplication( int? AppID = null,string DrivingClass = null,
    string NationalNo = null,string FullName = null,
    DateTime? ApplicationDate = null,int? PassedTests = null,string Status = null)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            
                string query = @"SELECT * FROM vvwLocalDrivingLicenseApplications WHERE 1=1";

                // Dynamic conditions
                if (AppID != null)
                    query += " AND [LdL.AppID] = @AppID";

                if (!string.IsNullOrEmpty(DrivingClass))
                    query += " AND [Driving Class] = @DrivingClass";

                if (!string.IsNullOrEmpty(NationalNo))
                    query += " AND [National No] = @NationalNo";

                if (!string.IsNullOrEmpty(FullName))
                    query += " AND [Full Name] = @FullName";

                if (ApplicationDate != null)
                    query += " AND [Application Date] = @AppDate";

                if (PassedTests != null)
                    query += " AND [Passed Tests] = @PassedTests";

                if (!string.IsNullOrEmpty(Status))
                    query += " AND [Status] = @Status";

                SqlCommand command = new SqlCommand(query, connection);

                // Add parameters
                if (AppID != null)
                    command.Parameters.AddWithValue("@AppID", AppID);

                if (!string.IsNullOrEmpty(DrivingClass))
                    command.Parameters.AddWithValue("@DrivingClass", DrivingClass);

                if (!string.IsNullOrEmpty(NationalNo))
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                if (!string.IsNullOrEmpty(FullName))
                    command.Parameters.AddWithValue("@FullName", FullName);

                if (ApplicationDate != null)
                    command.Parameters.AddWithValue("@AppDate", ApplicationDate);

                if (PassedTests != null)
                    command.Parameters.AddWithValue("@PassedTests", PassedTests);

                if (!string.IsNullOrEmpty(Status))
                    command.Parameters.AddWithValue("@Status", Status);

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


        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
VALUES (@ApplicationID, @LicenseClassID);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    ID = insertedID;
            }
            catch (Exception)
            {
             
            }
            finally { connection.Close(); }

            return ID;
        }
        public static bool UpdateLocalDrivingLicenseApplication(int LocalID, int ApplicationID, int LicenseClassID)
        {
            int rows = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
UPDATE LocalDrivingLicenseApplications
SET ApplicationID = @ApplicationID,
    LicenseClassID = @LicenseClassID
WHERE LocalDrivingLicenseApplicationID = @LocalID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalID", LocalID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                rows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally { connection.Close(); }

            return (rows > 0);
        }
        public static bool GetLocalDrivingLicenseApplicationByID(int LocalID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query =
                "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalID", LocalID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    found = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                found= false;
            }
            finally { connection.Close(); }

            return found;
        }
        public static bool GetLocalDrivingLicenseApplicationByIDForControl(int LocalID, ref int ApplicationID, ref int LicenseClassID,ref int PassedTests)
        {
            bool found = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
        SELECT *,
               (
                   SELECT COUNT(*)
                   FROM Tests
                   JOIN TestAppointments 
                        ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                   WHERE TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                     AND Tests.TestResult = 1
               ) AS PassedTests
        FROM LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalID;";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalID", LocalID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    found = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                    PassedTests = (int)reader["PassedTests"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                found = false;
            }
            finally { connection.Close(); }

            return found;
        }
        public static bool DeleteLocalDrivingLicenseApplicationByID(int LocalID)
        {
            int rows = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query ="DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalID", LocalID);

            try
            {
                connection.Open();
                rows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally { connection.Close(); }

            return (rows > 0);
        }
        public static bool CheckNewApplication(int personId, int licenseClassId)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 1
            FROM LocalDrivingLicenseApplications AS L
            JOIN Applications AS A 
                ON A.ApplicationID = L.ApplicationID
            WHERE A.ApplicantPersonID = @PersonID
              AND L.LicenseClassID = @LicenseClassID
              AND A.ApplicationStatus = 1; ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", personId);
                command.Parameters.AddWithValue("@LicenseClassID", licenseClassId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                        exists = true;

                    reader.Close();
                }
                catch
                {
                    exists = false;
                }
            }

            return exists;
        }


    }

}
