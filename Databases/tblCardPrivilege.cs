using iAccess.Objects.Customers.Cards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblCardPrivilege
    {
        public const string TBL_NAME = "tblCardPrivilege";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_SortOrder = "SortOrder";
        public const string TBL_COL_Name = "Name";
        public const string TBL_COL_Code = "Code";
        public const string TBL_COL_Description = "Description";
        public const string TBL_COL_ControllerDoorIDs = "ControllerDoorIDs";
        public const string TBL_COL_TimezoneID = "TimezoneID";

        public static string GetCMD = $@"SELECT {TBL_COL_ID},{TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description},{TBL_COL_ControllerDoorIDs},{TBL_COL_TimezoneID}
                                         FROM {TBL_NAME}
                                         ORDER BY {TBL_COL_SortOrder}";
        //GET
        public static CardPrivilegeCollection LoadDataCardPrivilege(CardPrivilegeCollection cardPrivileges)
        {
            cardPrivileges.Clear();
            DataTable dtCardPrivilege = Staticpool.mdb.FillData(GetCMD);
            if (dtCardPrivilege != null)
            {
                if (dtCardPrivilege.Rows.Count > 0)
                {
                    foreach(DataRow row in dtCardPrivilege.Rows)
                    {
                        CardPrivilege cardPrivilege = new CardPrivilege();
                        cardPrivilege.ID = row[TBL_COL_ID].ToString();
                        cardPrivilege.Name = row[TBL_COL_Name].ToString();
                        cardPrivilege.Code = row[TBL_COL_Code].ToString();
                        cardPrivilege.Description = row[TBL_COL_Description].ToString();
                        cardPrivilege.TimezoneID = row[TBL_COL_TimezoneID].ToString();

                        List<string> ControllerDoorIDs = row[TBL_COL_ControllerDoorIDs].ToString().Split(',').ToList();
                        foreach(string ControllerDoorID in ControllerDoorIDs)
                        {
                            cardPrivilege.ControllerDoorIDs.Add(ControllerDoorID);
                        }
                        cardPrivileges.Add(cardPrivilege);
                    }
                    return cardPrivileges;
                }
            }
            return null;
        }
        //ADD
        public static string InsertAndGetLastID(CardPrivilege cardPrivilege)
        {
            string ControllerDoorIDs = "";
            foreach(string ControllerDoorID in cardPrivilege.ControllerDoorIDs)
            {
                ControllerDoorIDs = ControllerDoorIDs + ControllerDoorID + ',';
            }
            ControllerDoorIDs = ControllerDoorIDs.Substring(0, ControllerDoorIDs.Length - 2);
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description},
                                                         {TBL_COL_ControllerDoorIDs},{TBL_COL_TimezoneID})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{cardPrivilege.Name}',N'{cardPrivilege.Code}',N'{cardPrivilege.Description}',
                                          '{ControllerDoorIDs}','{cardPrivilege.TimezoneID}')
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
        //MODIFY
        public static bool Modify(CardPrivilege cardPrivilege, string ID)
        {
            string ControllerDoorIDs = "";
            foreach (string ControllerDoorID in cardPrivilege.ControllerDoorIDs)
            {
                ControllerDoorIDs = ControllerDoorIDs + ControllerDoorID + ',';
            }
            ControllerDoorIDs = ControllerDoorIDs.Substring(0, ControllerDoorIDs.Length - 2);
            string updateCMD = $@"UPDATE {TBL_NAME} 
                                 SET {TBL_COL_Name} = N'{cardPrivilege.Name}',
                                 {TBL_COL_Code} = N'{cardPrivilege.Code}',
                                 {TBL_COL_Description} = N'{cardPrivilege.Description}',
                                 {TBL_COL_ControllerDoorIDs} = '{ControllerDoorIDs}',
                                 {TBL_COL_TimezoneID} = '{cardPrivilege.TimezoneID}'
                                 WHERE {TBL_COL_ID} = '{ID}'
                                 ";
            if (!Staticpool.mdb.ExecuteCommand(updateCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(updateCMD))
                {
                    return false;
                }
            }
            return true;
        }
        //Delete
        public static bool Delete(string cardPrivilegeID)
        {
            if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{cardPrivilegeID}'"))
            {
                if (!Staticpool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{cardPrivilegeID}'"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
