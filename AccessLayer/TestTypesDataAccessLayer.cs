using PeopleDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace TestTypesDataAccessLayer
{
    public class ClsTestTypesDataAccess
    {
      
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
                SELECT 
                    TestTypeID AS ID,
                    TestTypeTitle AS Title,
                    TestTypeDescription AS Description,
                    TestTypeFees AS Fees
                FROM TestTypes";

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
            }

            return dt;
        }

      
        public static int CountTestTypes()
        {
            int total = -1;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT COUNT(TestTypeID) FROM TestTypes";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int count))
                        total = count;
                }
                catch
                {
                }
            }

            return total;
        }

    
        public static bool UpdateTestType(int TestTypeID, string Title, string Description, decimal Fees)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
                UPDATE TestTypes
                SET
                    TestTypeTitle = @Title,
                    TestTypeDescription = @Description,
                    TestTypeFees = @Fees
                WHERE TestTypeID = @TestTypeID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Description", Description);
                command.Parameters.AddWithValue("@Fees", Fees);

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

            return (rowsAffected > 0);
        }

        
        public static bool GetTestTypeByID(
            int TestTypeID,
            ref string Title,
            ref string Description,
            ref decimal Fees)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

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
    }
}
