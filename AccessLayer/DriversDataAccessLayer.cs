using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriversDataAccessLayer
{
    public class ClsDriversDataAccess
    {
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;

            using (SqlConnection connection =
                   new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
IF NOT EXISTS (SELECT 1 FROM Drivers WHERE PersonID = @PersonID)
BEGIN
    INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
    VALUES (@PersonID, @CreatedByUserID, @CreatedDate);

    SELECT SCOPE_IDENTITY();
END
ELSE
BEGIN
    SELECT DriverID FROM Drivers WHERE PersonID = @PersonID;
END";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null &&
                            int.TryParse(result.ToString(), out int insertedID))
                        {
                            DriverID = insertedID;
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }

            return DriverID;
        }
        public static bool UpdateDriver(int DriverID, int PersonID,
                                int CreatedByUserID, DateTime CreatedDate)
        {
            int rowsAffected = 0;

            using (SqlConnection connection =
                   new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
UPDATE Drivers
SET 
    PersonID = @PersonID,
    CreatedByUserID = @CreatedByUserID,
    CreatedDate = @CreatedDate
WHERE DriverID = @DriverID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool GetDriverInfoByID(int DriverID,
    ref int PersonID,
    ref int CreatedByUserID,
    ref DateTime CreatedDate)
        {
            bool isFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            PersonID = (int)reader["PersonID"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            CreatedDate = (DateTime)reader["CreatedDate"];
                        }

                        reader.Close();
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static bool GetDriverInfoByPersonID(int PersonID,
    ref int DriverID,
    ref int CreatedByUserID,
    ref DateTime CreatedDate)
        {
            bool isFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT DriverID, CreatedByUserID, CreatedDate
                         FROM Drivers
                         WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            DriverID = (int)reader["DriverID"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            CreatedDate = (DateTime)reader["CreatedDate"];
                        }

                        reader.Close();
                    }
                    catch (Exception)
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }


        public static bool IsDriverExistByPersonID(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT 1 FROM Drivers WHERE PersonID = @PersonID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);

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
            }

            return isFound;
        }


        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = " select * from vwListDrivers;";

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
      
        public static DataTable FindDrivers(int? DriverID = null, int? PersonID = null,
    string NationalNo = null, string FullName = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"SELECT * FROM vwListDrivers WHERE 1=1";

                // Dynamic Conditions
                if (DriverID != null)
                    query += " AND [Driver ID] = @DriverID";

                if (PersonID != null)
                    query += " AND [Person ID] = @PersonID";

                if (!string.IsNullOrEmpty(NationalNo))
                    query += " AND [National No.] = @NationalNo";

                if (!string.IsNullOrEmpty(FullName))
                    query += " AND [Full Name] = @FullName";

                SqlCommand command = new SqlCommand(query, connection);

                // Add Parameters
                if (DriverID != null)
                    command.Parameters.AddWithValue("@DriverID", DriverID);

                if (PersonID != null)
                    command.Parameters.AddWithValue("@PersonID", PersonID);

                if (!string.IsNullOrEmpty(NationalNo))
                    command.Parameters.AddWithValue("@NationalNo", NationalNo);

                if (!string.IsNullOrEmpty(FullName))
                    command.Parameters.AddWithValue("@FullName", FullName);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        dt.Load(reader);

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Log error if needed
                }
            }

            return dt;
        }




    }
}
