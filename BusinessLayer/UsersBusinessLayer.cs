using PeopleBusinessLayer;
using PeopleDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UsersDataAccessLayer;

namespace UsersBusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public bool IsActive { get; set; }

        // This would typically come from a JOIN with the People table
        public string FullName { get; set; }

        // Default constructor (AddNew mode)
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.FullName = "";
            Mode = enMode.AddNew;
        }

        // Constructor for Update mode (when loading from database)
        private clsUser(int userID, int personID, string userName,
                        string password, bool isActive)
        {
            this.UserID = userID;
            this.PersonID = personID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            Mode = enMode.Update;
        }


        // Constructor for Search mode (when loading from database)
        private clsUser (int userID, int personID, string fullName, bool isActive, string userName)
        {
            UserID = userID;
            PersonID = personID;
            FullName= fullName;
            UserName = userName;
            IsActive = isActive;
            Mode = enMode.Update;
        }



        public static clsUser Find(int? userID = null, int? personID = null, string fullname=null,string userName = null, bool? isActive = null)
        {
            if (clsUsersDataAccess.GetUserInfo(ref userID, ref personID, ref fullname,
                ref userName, ref isActive))
            {
                return new clsUser(userID ?? -1, personID ?? -1, fullname,
                    isActive ?? false,userName);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindByUserName(string userName)
        {
            int personID = -1;
            int userID = -1;
            string password = "";
            bool isActive=false;

            if (clsUsersDataAccess.GetUserInfoByUserName(
               ref userID, ref personID, userName, ref password, ref isActive))
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }
        public static clsUser FindByUserID(int userID)
        { 
            int personID = -1;
            string userName = "";
            string password = "";
            bool isActive = false;

            if (clsUsersDataAccess.GetUserInfoByUserID(
                userID, ref personID,ref userName, ref password, ref isActive))
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }
        public static clsUser FindByPersonID(int personID)
        {
            int userID = -1;
            string userName = "";
            string password = "";
            bool isActive = false;

            if (clsUsersDataAccess.GetUserInfoByPersonID(
                ref userID,  personID, ref userName, ref password, ref isActive))
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindByPassword(string password)
        {
            int userID = -1;
            int personID = -1;
            string userName = "";
            bool isActive = false;

            if (clsUsersDataAccess.GetUserInfoByUserPassword(
               ref userID, ref personID,ref userName, password, ref isActive))
            {
                return new clsUser(userID, personID, userName, password, isActive);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUsersDataAccess.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUsersDataAccess.UpdateUser(this.UserID,this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateUser();//When you update a user, there is no extra logic after calling _UpdateUser().

                default:
                    return false;  // More explicit
            }
        }
        public static bool isUserExistByUserNameAndPassword(string userName, string password)
        {
            return clsUsersDataAccess.IsUserExist(userName,password);
        }
        public static bool isUserExistByUserID(int UserID)
        {
            return clsUsersDataAccess.IsUserExistByUserID(UserID);
        }
        public static bool isUserExistByPersonID(int PersonID)
        {
            return clsUsersDataAccess.IsUserExistByPersonID(PersonID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }
        public static DataTable ConvertUserToDataTable(clsUser user)
        {
            if (user == null)
                return null;

            DataTable dt = clsUsersDataAccess.GetAllUsers().Clone();

            DataRow row = dt.NewRow();

            row["UserID"] = user.UserID;
            row["PersonID"] = user.PersonID;
            row["FullName"] = user.FullName;
            row["UserName"] = user.UserName;
            row["IsActive"] = user.IsActive;

            dt.Rows.Add(row);

            return dt;
        }

        public static int TotalUsersNumber()
        {
            return clsUsersDataAccess.CountUsers();
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersDataAccess.DeleteUser(UserID);
        }
        public  bool ChangePassword(int userID, string oldPassword, string newPassword)
        {
            return clsUsersDataAccess.UpdatePassword(userID, oldPassword, newPassword);
        }
    }


}
