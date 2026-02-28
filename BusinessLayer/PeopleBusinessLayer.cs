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

namespace PeopleBusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {SecondName} {ThirdName} {LastName}".Trim();
            }
        }
        public string Gender { get; set; }

        public short GenderByte { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityCountryID { get; set; }
        public string Nationality { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }

        // Default constructor (AddNew mode)
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Nationality = "";
            this.NationalityCountryID = -1;
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.ImagePath = "";

            Mode = enMode.AddNew;
        }

       
        private clsPerson(int personID, string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, string gender,DateTime dateofbirth, string nationality, 
            string phone, string email,string address)
        {
            this.PersonID = personID;
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.Gender = gender;
            this.DateOfBirth = dateofbirth;
            this.Nationality = nationality;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;

            Mode = enMode.Update;
        }
        // Private constructor (Update mode)
        private clsPerson(int personID, string nationalNo, string firstName, string secondName,
                 string thirdName, string lastName, DateTime dateOfBirth, byte gendor,
                 string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            GenderByte = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            Mode = enMode.Update;
        }


        //Sometimes you want to search by PersonID, sometimes by NationalNo, or Name, etc.
        // If personId was just int, you’d always have to pass a value(like 0), and the code would think 0 is a real ID.
        // int?="personId can be an int value or null"
        public static DataTable FindPersonInfo(int? personId = null, string nationalNo = null, string firstName = null,
   string secondName = null, string thirdName = null, string lastName = null, string gendor =null , DateTime? dateofbirth = null, string nationality = null
   , string phone = null, string email = null,string address=null)

        {
            return clsPeopleDataAccess.GetPersonInfo(personId, nationalNo, firstName, secondName, thirdName, lastName, gendor,
             dateofbirth, nationality, phone, email, address);
        }
        public static clsPerson FindByID(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            string Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            int NationalityCountryID = -1;
            if (clsPeopleDataAccess.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson FindByNationalNo(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            string Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            int NationalityCountryID = -1,PersonID=-1;
            if (clsPeopleDataAccess.GetPersonInfoByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {

                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }





        private bool _AddNewPerson ()
        {
            this.PersonID = clsPeopleDataAccess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName,this.DateOfBirth,
                this.GenderByte, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPeopleDataAccess.UpdatePerson(this.PersonID,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth,
                this.GenderByte, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                  return _UpdatePerson();

            }




            return false;
        }
        public static bool PersonExistByPersonID(int PersonID)
        {
            return clsPeopleDataAccess.IsPersonExistByPersonID(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleDataAccess.GetAllPeople();
        }
       

        public static DataTable GetAllCountries()
        {
            return clsPeopleDataAccess.GetAllCountries();
        }
      
        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleDataAccess.DeletePerson(PersonID);
        }

    }
}