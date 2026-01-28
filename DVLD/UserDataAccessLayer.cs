using PeopleDataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace UsersDataAccessLayer
{
    public class clsUsersDataAccess
    {
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM vUsers";

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
        public static int CountUsers()
        {
            int totalUsers = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT COUNT(UserID) FROM vUsers";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int total))
                {
                    totalUsers = total;
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return totalUsers;
        }
        public static bool GetUserInfo(ref int? UserID,
    ref int? PersonID, ref string FullName, ref string Username, ref bool? IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 * FROM vUsers WHERE 1=1";

            // Build conditions
            if (UserID != null)
                query += " AND UserID = @UserID";

            if (PersonID != null)
                query += " AND PersonID = @PersonID";

            if (!string.IsNullOrEmpty(FullName))
                query += " AND FullName = @FullName";

            if (!string.IsNullOrEmpty(Username))
                query += " AND Username = @Username";

            if (IsActive != null)
                query += " AND IsActive = @IsActive";

            SqlCommand command = new SqlCommand(query, connection);

            // Add parameters
            if (UserID != null)
                command.Parameters.AddWithValue("@UserID", UserID);

            if (PersonID != null)
                command.Parameters.AddWithValue("@PersonID", PersonID);

            if (!string.IsNullOrEmpty(FullName))
                command.Parameters.AddWithValue("@FullName", FullName);

            if (!string.IsNullOrEmpty(Username))
                command.Parameters.AddWithValue("@Username", Username);

            if (IsActive != null)
                command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = Convert.ToInt32(reader["UserID"]);
                    PersonID = Convert.ToInt32(reader["PersonID"]);
                    FullName = reader["FullName"].ToString();
                    Username = reader["Username"].ToString();
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                }
                else
                {
                    isFound = false;
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
        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
INSERT INTO Users (PersonID, UserName, Password, IsActive)
VALUES (@PersonID, @UserName, @Password, @IsActive);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }
    
   
       

        

        public static bool UpdateUser(int UserID, int PersonID, string UserName,
                                      string Password, bool IsActive)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
UPDATE Users
SET 
    PersonID = @PersonID,
    UserName = @UserName,
    Password = @Password,
    IsActive = @IsActive
WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

       

        public static bool GetUserInfoByUserName(ref int UserID, ref int PersonID,
                 string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }

            return isFound;
        }
        public static bool GetUserInfoByUserID( int UserID, ref int PersonID,
               ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }

            return isFound;
        }
        public static bool GetUserInfoByPersonID(ref int UserID, int PersonID,
               ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }

            return isFound;
        }


        public static bool GetUserInfoByUserPassword(ref int UserID, ref int PersonID,
             ref  string UserName,  string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }

            return isFound;
        }
        public static bool GetUserInfoByIsActive(ref int UserID, ref int PersonID,
           ref string UserName,ref string Password, bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE IsActive = @IsActive";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }

            return isFound;
        }


        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "DELETE FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool IsUserExist(string UserName,string Password)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName and Password = @Password and " +
                "IsActive = 1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool IsUserExistByUserID(int UserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Users WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);

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
        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT Found = 1 FROM Users WHERE PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
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

            return isFound;
        }
        public static bool UpdatePassword(int userID, string oldPassword, string newPassword)
        {
            bool isUpdated = false;

            using (SqlConnection connection =
                   new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Users
                         SET Password = @NewPassword
                         WHERE UserID = @UserID AND Password = @OldPassword";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewPassword", newPassword);
                command.Parameters.AddWithValue("@OldPassword", oldPassword);
                command.Parameters.AddWithValue("@UserID", userID);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    isUpdated = (rowsAffected > 0);
                }
                catch
                {
                    isUpdated = false;
                }
            }

            return isUpdated;
        }


    }


}
