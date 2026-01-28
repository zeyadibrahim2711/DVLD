using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDataAccessLayer
{
    public class ClsApplicationDataAccess
    {
        public static int AddNewApplication(int ApplicantPersonID,DateTime ApplicationDate, int ApplicationTypeID,
            byte ApplicationStatus,DateTime LastStatusDate, decimal PaidFees,int CreatedByUserID)
        {
            int ApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
INSERT INTO Applications
(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
VALUES 
(@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        ApplicationID = insertedID;
                    }
                }
                catch
                {
                    ApplicationID = -1;
                }
            }

            return ApplicationID;
        }

        public static bool UpdateApplication( int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
    int ApplicationTypeID, byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
UPDATE Applications SET
ApplicantPersonID = @ApplicantPersonID,
ApplicationDate = @ApplicationDate,
ApplicationTypeID = @ApplicationTypeID,
ApplicationStatus = @ApplicationStatus,
LastStatusDate = @LastStatusDate,
PaidFees = @PaidFees,
CreatedByUserID = @CreatedByUserID
WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
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
        public static bool GetApplicationByID( int ApplicationID, ref int ApplicantPersonID,
   ref DateTime ApplicationDate, ref int ApplicationTypeID, ref byte ApplicationStatus,
    ref DateTime LastStatusDate,ref decimal PaidFees,ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;

                        ApplicantPersonID = (int)reader["ApplicantPersonID"];
                        ApplicationDate = (DateTime)reader["ApplicationDate"];
                        ApplicationTypeID = (int)reader["ApplicationTypeID"];
                        ApplicationStatus = (byte)reader["ApplicationStatus"];
                        LastStatusDate = (DateTime)reader["LastStatusDate"];
                        PaidFees = Convert.ToDecimal(reader["PaidFees"]);
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

        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool CancelApplication(int ApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "update Applications  Set ApplicationStatus=2    WHERE ApplicationID = @ApplicationID;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM Applications WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
        public static bool IsPersonHaveApplicationNotCancelled(int ApplicationPersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM Applications WHERE ApplicationPersonID = @ApplicationPersonID and ApplicationStatus != 1 ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationPersonID", ApplicationPersonID);

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


    }
}
