using System;
using System.Data;
using System.Data.SqlClient;
using PeopleDataAccessLayer;

namespace LicenseClassesDataAccessLayer
{
    public class clsLicenseClassesDataAccess
    {
        // -------------------------------------------------------
        // 1) Get All License Classes
        // -------------------------------------------------------
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = " Select ClassName from LicenseClasses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dt.Load(reader);

                reader.Close();
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool GetLicenseClassInfoByName(
    string ClassName,
    ref int LicenseClassID,
    ref string classDescription,
    ref int minimumAllowedAge,
    ref int defaultValidityLength,
    ref decimal classFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseClassID = (int)reader["LicenseClassID"];
                    classDescription = (string)reader["ClassDescription"];
                    minimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    defaultValidityLength = (byte)reader["DefaultValidityLength"];
                    classFees = (decimal)reader["ClassFees"];
                }

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        // -------------------------------------------------------
        // 2) Get License Class By ID
        // -------------------------------------------------------
        public static bool GetLicenseClassInfo(
            int LicenseClassID,
            ref string ClassName,
            ref string ClassDescription,
            ref int MinimumAllowedAge,
            ref int DefaultValidityLength,
            ref decimal ClassFees
            )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();
                    MinimumAllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt32(reader["DefaultValidityLength"]);
                    ClassFees = Convert.ToDecimal(reader["ClassFees"]);
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

        // -------------------------------------------------------
        // 3) Add New License Class
        // -------------------------------------------------------
        public static int AddNewLicenseClass(
            string ClassName,
            string ClassDescription,
            int MinimumAllowedAge,
            int DefaultValidityLength,
            decimal ClassFees
            )
        {
            int newID = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
INSERT INTO LicenseClasses
(ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees)
VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);

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

        // -------------------------------------------------------
        // 4) Update License Class
        // -------------------------------------------------------
        public static bool UpdateLicenseClass(
            int LicenseClassID,
            string ClassName,
            string ClassDescription,
            int MinimumAllowedAge,
            int DefaultValidityLength,
            decimal ClassFees
            )
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
UPDATE LicenseClasses
SET 
    ClassName = @ClassName,
    ClassDescription = @ClassDescription,
    MinimumAllowedAge = @MinimumAllowedAge,
    DefaultValidityLength = @DefaultValidityLength,
    ClassFees = @ClassFees
WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);

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

        // -------------------------------------------------------
        // 5) Delete License Class
        // -------------------------------------------------------
        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "DELETE FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        // -------------------------------------------------------
        // 6) Check if exists
        // -------------------------------------------------------
        public static bool IsLicenseClassExist(int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found = 1 FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
    }
}
