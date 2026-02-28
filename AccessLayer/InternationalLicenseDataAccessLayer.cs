using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalLicenseDataAccessLayer
{
    public class ClsInternationalLicenseDataAccess
    {
        public static int AddNewInternationalLicense(int ApplicationID,
    int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
    bool IsActive, int CreatedByUserID)
        {
            int newID = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
    INSERT INTO InternationalLicenses
    (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
    VALUES
    (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);

    SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    newID = insertedID;
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return newID;
        }
        public static bool UpdateInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID,
    int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate,
    bool IsActive, int CreatedByUserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
    UPDATE InternationalLicenses
    SET 
        ApplicationID = @ApplicationID,
        DriverID = @DriverID,
        IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID,
        IssueDate = @IssueDate,
        ExpirationDate = @ExpirationDate,
        IsActive = @IsActive,
        CreatedByUserID = @CreatedByUserID
    WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
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
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "DELETE FROM Licenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

        public static bool IsInternationalLicenseExist(int InternationalLicenseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM InternationalLicenses WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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
        public static bool IsInternationalLicenseExistByDriverID(int DriverID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM InternationalLicenses WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

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

        public static bool IsInternationalLicenseExistByAppID(int AppID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM InternationalLicenses WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", AppID);

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
        public static bool GetInternationalLicenseInfo(int InternationalLicenseID, ref int ApplicationID, ref int DriverID,
    ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate,
    ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                        InternationalLicenseID,
                        ApplicationID,
                        DriverID,
                        IssuedUsingLocalLicenseID,
                        IssueDate,
                        ExpirationDate,
                        IsActive,
                        CreatedByUserID
                     FROM InternationalLicenses
                     WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }

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

        public static bool FindInternationalLicenseByAppID(ref int InternationalLicenseID, int ApplicationID, ref int DriverID,
    ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate,
    ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                        InternationalLicenseID,
                        ApplicationID,
                        DriverID,
                        IssuedUsingLocalLicenseID,
                        IssueDate,
                        ExpirationDate,
                        IsActive,
                        CreatedByUserID
                     FROM InternationalLicenses
                     WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    InternationalLicenseID = Convert.ToInt32(reader["InternationalLicenseID"]);
                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }

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
        public static bool FindInternationalLicenseByDriverID(ref int InternationalLicenseID, ref int ApplicationID, int DriverID,
   ref int IssuedUsingLocalLicenseID, ref DateTime IssueDate,
   ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                        InternationalLicenseID,
                        ApplicationID,
                        DriverID,
                        IssuedUsingLocalLicenseID,
                        IssueDate,
                        ExpirationDate,
                        IsActive,
                        CreatedByUserID
                     FROM InternationalLicenses
                     WHERE DriverID = @DriverID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    InternationalLicenseID = Convert.ToInt32(reader["InternationalLicenseID"]);
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                }

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
        public static DataTable GetAllInternationalDrivingLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM vwInternationalDrivingLicenseApplications";

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
        public static DataTable FindInternationalLicenses(
      int? internationalLicenseID = null,
      int? applicationID = null,
      int? driverID = null,
      int? localLicenseID = null,
      DateTime? issueDate = null,
      DateTime? exprationDate = null,
      bool? isActive = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * 
                         FROM vwInternationalDrivingLicenseApplications 
                         WHERE 1=1";

                if (internationalLicenseID != null)
                    query += " AND [Int.License ID] = @IntLicenseID";

                if (applicationID != null)
                    query += " AND [Application ID] = @ApplicationID";

                if (driverID != null)
                    query += " AND [DriverID] = @DriverID";

                if (localLicenseID != null)
                    query += " AND [L.License ID] = @LocalLicenseID";

                if (issueDate != null)
                    query += " AND [Issue Date] = @IssueDate";

                if (isActive != null)
                    query += " AND [IS Active] = @IsActive";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (internationalLicenseID != null)
                        command.Parameters.AddWithValue("@IntLicenseID", internationalLicenseID);

                    if (applicationID != null)
                        command.Parameters.AddWithValue("@ApplicationID", applicationID);

                    if (driverID != null)
                        command.Parameters.AddWithValue("@DriverID", driverID);

                    if (localLicenseID != null)
                        command.Parameters.AddWithValue("@LocalLicenseID", localLicenseID);

                    if (issueDate != null)
                        command.Parameters.AddWithValue("@IssueDate", issueDate);

                    if (isActive != null)
                        command.Parameters.AddWithValue("@IsActive", isActive);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }

            return dt;
        }


        public static DataTable GetAllInternationalDrivingLicenseForDriver(int DriverID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "select * from fnGetInternationalDriverLicenses(@DriverID);";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

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
    }
     
}
