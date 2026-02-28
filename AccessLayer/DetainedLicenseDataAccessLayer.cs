using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetainedLicenseDataAccessLayer
{

    public class ClsDetainedLicenseDataAccess
    {
        public static int AddNewDetain(
    int LicenseID,
    DateTime DetainDate,
    decimal FineFees,
    int CreatedByUserID,
    bool IsReleased,
    DateTime? ReleaseDate,
    int? ReleasedByUserID,
    int? ReleaseApplicationID)
        {
            int newID = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
INSERT INTO DetainedLicenses
(LicenseID, DetainDate, FineFees, CreatedByUserID,
 IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)

VALUES
(@LicenseID, @DetainDate, @FineFees, @CreatedByUserID,
 @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);

SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);



            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleaseDate", (object)ReleaseDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", (object)ReleasedByUserID ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", (object)ReleaseApplicationID ?? DBNull.Value);

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

        public static bool ReleaseDetainedLicense(
    int DetainID,
    DateTime ReleaseDate,
    int ReleasedByUserID,
    int ReleaseApplicationID)
        {
            int rowsAffected = 0;

            SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
UPDATE DetainedLicenses
SET
    IsReleased = 1,
    ReleaseDate = @ReleaseDate,
    ReleasedByUserID = @ReleasedByUserID,
    ReleaseApplicationID = @ReleaseApplicationID
WHERE DetainID = @DetainID
AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
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
        public static DataTable FindDetainedLicense(int? detainID = null,
int? nationalNO = null,
bool? isReleased = null,
int? releaseApplicationID = null,
 string fullName = null)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"SELECT * 
                         FROM vwDetainedLicense
                         WHERE 1=1";
            if (detainID != null)
                query += " AND [D.ID] = @DetainID";

            if (nationalNO != null)
                query += " AND [N.NO] = @nationalNo";

            if (fullName != null)
                query += " AND [FullName] = @FullName";

            if (isReleased != null)
                query += " AND [Is Released] = @IsReleased";

            if (releaseApplicationID != null)
                query += " AND [ReleaseApp.ID] = @ReleaseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            if (detainID != null)
                command.Parameters.AddWithValue("@DetainID", detainID);

            if (nationalNO != null)
                command.Parameters.AddWithValue("@nationalNo", nationalNO);

            if (fullName != null)
                command.Parameters.AddWithValue("@FullName", fullName);

            if (isReleased != null)
                command.Parameters.AddWithValue("@IsReleased", isReleased);

            if (releaseApplicationID != null)
                command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);
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
        public static bool FindDetainByID(
    int DetainID,
    ref int LicenseID,
    ref DateTime DetainDate,
    ref decimal FineFees,
    ref int CreatedByUserID,
    ref bool IsReleased,
    ref DateTime? ReleaseDate,
    ref int? ReleasedByUserID,
    ref int? ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    LicenseID = Convert.ToInt32(reader["LicenseID"]);
                    DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees = Convert.ToDecimal(reader["FineFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                    ReleaseDate = reader["ReleaseDate"] == DBNull.Value
                        ? (DateTime?)null
                        : Convert.ToDateTime(reader["ReleaseDate"]);

                    ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value
                        ? (int?)null
                        : Convert.ToInt32(reader["ReleasedByUserID"]);

                    ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value
                        ? (int?)null
                        : Convert.ToInt32(reader["ReleaseApplicationID"]);
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
        public static bool FindDetainByLicenseID(
    int LicenseID,
    ref int DetainID,
    ref DateTime DetainDate,
    ref decimal FineFees,
    ref int CreatedByUserID,
    ref bool IsReleased,
    ref DateTime? ReleaseDate,
    ref int? ReleasedByUserID,
    ref int? ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection =
                new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT TOP 1 *\r\nFROM DetainedLicenses\r\nWHERE LicenseID = @LicenseID\r\nORDER BY DetainID DESC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    DetainID = Convert.ToInt32(reader["DetainID"]);
                    DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                    FineFees = Convert.ToDecimal(reader["FineFees"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                    ReleaseDate = reader["ReleaseDate"] == DBNull.Value
                        ? (DateTime?)null
                        : Convert.ToDateTime(reader["ReleaseDate"]);

                    ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value
                        ? (int?)null
                        : Convert.ToInt32(reader["ReleasedByUserID"]);

                    ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value
                        ? (int?)null
                        : Convert.ToInt32(reader["ReleaseApplicationID"]);
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

        public static bool IsLicenseDetain(int LicenseID)
        {
            bool isDetain = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
IF EXISTS (
    SELECT 1 
    FROM DetainedLicenses
    WHERE LicenseID = @LicenseID
    AND IsReleased = 0
)
    SELECT 1
ELSE
    SELECT 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object scalarResult = command.ExecuteScalar();

                if (scalarResult != null && int.TryParse(scalarResult.ToString(), out int value))
                {
                    isDetain = (value == 1);
                }
            }
            catch
            {
                isDetain = false;
            }
            finally
            {
                connection.Close();
            }

            return isDetain;
        }
        public static bool IsLicenseDetainByDetainID(int DetainID)
        {
            bool isDetain = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
IF EXISTS (
    SELECT 1 
    FROM DetainedLicenses
    WHERE DetainID = @DetainID
    AND IsReleased = 0
)
    SELECT 1
ELSE
    SELECT 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();

                object scalarResult = command.ExecuteScalar();

                if (scalarResult != null && int.TryParse(scalarResult.ToString(), out int value))
                {
                    isDetain = (value == 1);
                }
            }
            catch
            {
                isDetain = false;
            }
            finally
            {
                connection.Close();
            }

            return isDetain;
        }
        public static DataTable GetAllDetainLicense()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "Select * from vwDetainedLicense;";

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
    }
      
}
