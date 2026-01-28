using ApplicationTyoesBusinessLayer;
using ApplicationTypesDataAccessLayer;
using System;
using System.Data;
using TestTypesDataAccessLayer;

namespace BusinessLayer
{
    public class ClsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        

     

        
        private ClsTestType(int id, string title, string description, decimal fees)
        {
            TestTypeID = id;
            TestTypeTitle = title;
            TestTypeDescription = description;
            TestTypeFees = fees;
        }
      
        public static DataTable GetAllTestTypes()
        {
            return ClsTestTypesDataAccess.GetAllTestTypes();
        }

       
        public static int Count()
        {
            return ClsTestTypesDataAccess.CountTestTypes();
        }

        public static ClsTestType Find(int testTypeID)
        {
            string title = "";
            string description = "";
            decimal fees = 0;

            if (ClsTestTypesDataAccess.GetTestTypeByID(testTypeID, ref title,ref description, ref fees))
            {
                return new ClsTestType(testTypeID, title, description,fees);
            }
            else
            {
                return null;
            }
        }

    }
}