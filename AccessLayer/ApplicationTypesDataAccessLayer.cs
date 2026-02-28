using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTypesDataAccessLayer
{
    public class ClsApplicationTypesDataAccess
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                ApplicationTypeID AS ID, 
                ApplicationTypeTitle AS Title, 
                ApplicationFees AS Fees
            FROM ApplicationTypes";

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
                    // Optional: log error
                }
            }

            return dt;
        }
           public static bool UpdateApplicationType(int ApplicationTypeID, string Title, decimal Fees)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
UPDATE ApplicationTypes
SET 
    ApplicationTypeTitle = @Title,
    ApplicationFees = @Fees
WHERE ApplicationTypeID = @ApplicationTypeID;";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Fees", Fees);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;  // Update failed
                }
            }

            return (rowsAffected > 0);
        }
        public static bool GetApplicationTypeByID(
        int ApplicationTypeID,
        ref string ApplicationTypeTitle,
        ref decimal ApplicationFees)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToDecimal(reader["ApplicationFees"]);
                }

                reader.Close();
            }
            catch
            {
                isFound = false;
            }

            return isFound;
        }
    }


}