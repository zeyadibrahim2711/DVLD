using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace PeopleDataAccessLayer
{
    public class clsPeopleDataAccess
    {
        public static DataTable GetAllPeople()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = " SELECT * from vvvv_People\r\n";

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
        public static int CountPeople()
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int TotalPeople = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = " SELECT COUNT(PersonID)  from vvvv_People\r\n;";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int Total))
                {
                    TotalPeople = Total;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TotalPeople;
        }
        public static bool GetPersonInfo(ref int? PersonId, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName,
      ref string LastName, ref string Gendor,ref DateTime? DateOfBirth ,ref string Nationality, ref string Phone, ref string Email,ref string Address)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 * FROM vvvv_People WHERE 1=1";

            if (PersonId != null)
                query += " AND PersonID = @PersonID";
            if (!string.IsNullOrEmpty(NationalNo))
                query += " AND NationalNo = @NationalNo";
            if (!string.IsNullOrEmpty(FirstName))
                query += " AND FirstName = @FirstName";
            if (!string.IsNullOrEmpty(SecondName))
                query += " AND SecondName = @SecondName";
            if (!string.IsNullOrEmpty(ThirdName))
                query += " AND ThirdName = @ThirdName";
            if (!string.IsNullOrEmpty(LastName))
                query += " AND LastName = @LastName";
            if (!string.IsNullOrEmpty(Gendor))
                query += " AND Gendor = @Gendor";
            if (DateOfBirth!=null)
                query += " AND DateOfBirth = @DateOfBirth";
            if (!string.IsNullOrEmpty(Nationality))
                query += " AND Nationality = @Nationality";
            if (!string.IsNullOrEmpty(Phone))
                query += " AND Phone = @Phone";
            if (!string.IsNullOrEmpty(Email))
                query += " AND Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);

            if (PersonId != null)
                command.Parameters.AddWithValue("@PersonID", PersonId);
            if (!string.IsNullOrEmpty(NationalNo))
                command.Parameters.AddWithValue("@NationalNo", NationalNo);
            if (!string.IsNullOrEmpty(FirstName))
                command.Parameters.AddWithValue("@FirstName", FirstName);
            if (!string.IsNullOrEmpty(SecondName))
                command.Parameters.AddWithValue("@SecondName", SecondName);
            if (!string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            if (!string.IsNullOrEmpty(LastName))
                command.Parameters.AddWithValue("@LastName", LastName);
            if (!string.IsNullOrEmpty(Gendor))
                command.Parameters.AddWithValue("@Gendor", Gendor);
            if (DateOfBirth!=null)
                command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            if (!string.IsNullOrEmpty(Nationality))
                command.Parameters.AddWithValue("@Nationality", Nationality);
            if (!string.IsNullOrEmpty(Phone))
                command.Parameters.AddWithValue("@Phone", Phone);
            if (!string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonId = Convert.ToInt32(reader["PersonID"]);
                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();
                    Gendor = reader["Gendor"].ToString();
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Nationality = reader["Nationality"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();
                    Address = reader["Address"].ToString();

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        
        }
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "SELECT CountryName FROM Countries";

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
        public static bool GetCountryInfoByName(string CountryName, ref int ID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["CountryID"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
                             string LastName, DateTime DateOfBirth, short Gendor, string Address,
                             string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
    INSERT INTO People 
        (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
    VALUES 
        (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
    SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);

           
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);

            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

         
            if (!string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName,
                                string ThirdName, string LastName, DateTime DateOfBirth, short Gendor,
                                string Address, string Phone, string Email, int NationalityCountryID,
                                string ImagePath)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"
UPDATE People
SET 
    NationalNo = @NationalNo,
    FirstName = @FirstName,
    SecondName = @SecondName,
    ThirdName = @ThirdName,
    LastName = @LastName,
    DateOfBirth = @DateOfBirth,
    Gendor = @Gendor,
    Address = @Address,
    Phone = @Phone,
    Email = @Email,
    NationalityCountryID = @NationalityCountryID,
    ImagePath = @ImagePath
WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);

            // Parameters
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (!string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Optional: Log or handle error
                // Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }



        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName,
        ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
        ref byte Gendor, ref string Address, ref string Phone, ref string Email,
        ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = Convert.ToByte(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";
                }
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            return isFound;
        }
        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM People 
                     WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery(); // returns how many rows were deleted
            }
            catch (Exception ex)
            {
                // Optionally log the error
                // Console.WriteLine("Error deleting person: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            // If rowsAffected > 0 → at least one row was deleted successfully
            return (rowsAffected > 0);
        }
        public static bool IsPersonExistByPersonID(int PersonID)
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


    }
}