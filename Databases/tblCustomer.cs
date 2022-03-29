using iAccess.Objects.Customers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblCustomer
    {
        public const string TBL_NAME = "tblCustomer";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_SortOrder = "SortOrder";
        public const string TBL_COL_Name = "Name";
        public const string TBL_COL_Code = "Code";
        public const string TBL_COL_Description = "Description";
        public const string TBL_COL_Email = "Email";
        public const string TBL_COL_Phone = "Phone";
        public const string TBL_COL_Address = "Address";
        public const string TBL_COL_FingerData1 = "FingerData1";
        public const string TBL_COL_FingerData2 = "FingerData2";
        public const string TBL_COL_FingerData3 = "FingerData3";
        public const string TBL_COL_FingerData4 = "FingerData4";
        public const string TBL_COL_FingerData5 = "FingerData5";
        public const string TBL_COL_FingerData6 = "FingerData6";
        public const string TBL_COL_FingerData7 = "FingerData7";
        public const string TBL_COL_FingerData8 = "FingerData8";
        public const string TBL_COL_FingerData9 = "FingerData9";
        public const string TBL_COL_FingerData10 = "FingerData10";
        public const string TBL_COL_FaceData = "FaceData";
        public const string TBL_COL_MainCardID = "MainCardID";
        public const string TBL_COL_SecondaryCardID = "SecondaryCardID";
        public const string TBL_COL_DepartmentID = "DepartmentID";

        public static string GetCMD = $@"SELECT {TBL_COL_ID}, {TBL_COL_Name}, {TBL_COL_Code}, {TBL_COL_Description}, {TBL_COL_Email},
                                                {TBL_COL_Phone}, {TBL_COL_Address}, {TBL_COL_FingerData1}, {TBL_COL_FingerData2},
                                                {TBL_COL_FingerData3}, {TBL_COL_FingerData4}, {TBL_COL_FingerData5}, {TBL_COL_FingerData6},
                                                {TBL_COL_FingerData7}, {TBL_COL_FingerData8}, {TBL_COL_FingerData9}, {TBL_COL_FingerData10},
                                                {TBL_COL_FaceData}, {TBL_COL_MainCardID}, {TBL_COL_SecondaryCardID}, {TBL_COL_DepartmentID}
                                         FROM {TBL_NAME}
                                         ORDER BY {TBL_COL_SortOrder}";
        //Get
        public static CustomerCollection LoadCustomer(CustomerCollection customers)
        {
            customers.Clear();
            DataTable dtCustomer = Staticpool.mdb.FillData(GetCMD);
            if (dtCustomer != null)
            {
                if (dtCustomer.Rows.Count > 0)
                {
                    foreach(DataRow row in dtCustomer.Rows)
                    {
                        Customer customer = new Customer()
                        {
                            ID = row[TBL_COL_ID].ToString(),
                            Name = row[TBL_COL_Name].ToString(),
                            Code = row[TBL_COL_Code].ToString(),
                            Description = row[TBL_COL_Description].ToString(),
                            Email = row[TBL_COL_Email].ToString(),
                            Phone = row[TBL_COL_Phone].ToString(),
                            Address = row[TBL_COL_Address].ToString(),
                            Finger1 = row[TBL_COL_FingerData1].ToString(),
                            Finger2 = row[TBL_COL_FingerData2].ToString(),
                            Finger3 = row[TBL_COL_FingerData3].ToString(),
                            Finger4 = row[TBL_COL_FingerData4].ToString(),
                            Finger5 = row[TBL_COL_FingerData5].ToString(),
                            Finger6 = row[TBL_COL_FingerData6].ToString(),
                            Finger7 = row[TBL_COL_FingerData7].ToString(),
                            Finger8 = row[TBL_COL_FingerData8].ToString(),
                            Finger9 = row[TBL_COL_FingerData9].ToString(),
                            Finger10 = row[TBL_COL_FingerData10].ToString(),
                            FaceData = row[TBL_COL_FaceData].ToString(),
                            MainCardID = row[TBL_COL_MainCardID].ToString(),
                            SecondaryCardID = row[TBL_COL_SecondaryCardID].ToString(),
                            DepartmentID = row[TBL_COL_DepartmentID].ToString(),
                        };
                        customers.Add(customer);
                    }
                    return customers;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(Customer customer)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}(
                                  {TBL_COL_Name}, {TBL_COL_Code}, {TBL_COL_Description}, {TBL_COL_Email},
                                  {TBL_COL_Phone}, {TBL_COL_Address}, {TBL_COL_FingerData1}, {TBL_COL_FingerData2},
                                  {TBL_COL_FingerData3}, {TBL_COL_FingerData4}, {TBL_COL_FingerData5}, {TBL_COL_FingerData6},
                                  {TBL_COL_FingerData7}, {TBL_COL_FingerData8}, {TBL_COL_FingerData9}, {TBL_COL_FingerData10},
                                  {TBL_COL_FaceData}, {TBL_COL_MainCardID}, {TBL_COL_SecondaryCardID}, {TBL_COL_DepartmentID})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{customer.Name}',N'{customer.Code}',N'{customer.Description}','{customer.Email}',
                                          '{customer.Phone}',N'{customer.Address}','{customer.Finger1}','{customer.Finger2}',
                                          '{customer.Finger3}','{customer.Finger4}','{customer.Finger5}','{customer.Finger6}',
                                          '{customer.Finger7}','{customer.Finger8}','{customer.Finger9}','{customer.Finger10}',
                                          '{customer.FaceData}','{customer.MainCardID}','{customer.SecondaryCardID}','{customer.DepartmentID}'
                                         )
                                  Select * from @generated_keys";


            DataTable dtbLastID = Staticpool.mdb.FillData(insertCMD);
            if ((dtbLastID == null))
            {
                dtbLastID = Staticpool.mdb.FillData(insertCMD);
                if ((dtbLastID == null))
                {
                    return "";
                }
            }
            return dtbLastID.Rows[0][TBL_COL_ID].ToString();
        }
        //Modify
        public static bool Modify(Customer customer, string ID)
        {
            string UpdateCMD = $@"UPDATE {TBL_NAME} 
                                  SET {TBL_COL_Name} = N'{customer.Name}',
                                      {TBL_COL_Code} = N'{customer.Code}',
                                      {TBL_COL_Description} = N'{customer.Description}',
                                      {TBL_COL_Email} = N'{customer.Email}',
                                      {TBL_COL_Phone} = N'{customer.Phone}',
                                      {TBL_COL_Address} = N'{customer.Address}',
                                      {TBL_COL_FingerData1} = '{customer.Finger1}',
                                      {TBL_COL_FingerData2} = '{customer.Finger2}',
                                      {TBL_COL_FingerData3} = '{customer.Finger3}',
                                      {TBL_COL_FingerData4} = '{customer.Finger4}',
                                      {TBL_COL_FingerData5} = '{customer.Finger5}',
                                      {TBL_COL_FingerData6} = '{customer.Finger6}',
                                      {TBL_COL_FingerData7} = '{customer.Finger7}',
                                      {TBL_COL_FingerData8} = '{customer.Finger8}',
                                      {TBL_COL_FingerData9} = '{customer.Finger9}',
                                      {TBL_COL_FingerData10} = '{customer.Finger10}',
                                      {TBL_COL_FaceData} = '{customer.FaceData}',
                                      {TBL_COL_MainCardID} = '{customer.MainCardID}',
                                      {TBL_COL_SecondaryCardID} = '{customer.SecondaryCardID}',
                                      {TBL_COL_DepartmentID} = '{customer.DepartmentID}'
                                  WHERE {TBL_COL_ID} = '{ID}'";
            if (!Staticpool.mdb.ExecuteCommand(UpdateCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(UpdateCMD))
                {
                    return false;
                }
            }
            return true;
        }
        //Delete
        public static bool Delete(string customerID)
        {
            if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{customerID}'"))
            {
                if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{customerID}'"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
