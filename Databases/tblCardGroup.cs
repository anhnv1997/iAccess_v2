using iAccess.Objects.Customers.Cards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblCardGroup
    {
        public const string TBL_NAME = "tblCardGroup";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_Name = "Name";
        public const string TBL_COL_Code = "Code";
        public const string TBL_COL_Description = "Description";
        public const string TBL_COL_SortOrder = "SortOrder";

        public static string GetCMD = $@"Select {TBL_COL_ID},{TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description} from {TBL_NAME} order by {TBL_COL_SortOrder}";
        //Get
        public static CardGroupCollection LoadDataCardGroup(CardGroupCollection cardGroups)
        {
            cardGroups.Clear();
            DataTable dtCardGroup = Staticpool.mdb.FillData(GetCMD);
            if (dtCardGroup != null)
            {
                if (dtCardGroup.Rows.Count > 0)
                {
                    foreach (DataRow row in dtCardGroup.Rows)
                    {
                        CardGroup cardGroup = new CardGroup()
                        {
                            ID = row[TBL_COL_ID].ToString(),
                            Name = row[TBL_COL_Name].ToString(),
                            Code = row[TBL_COL_Code].ToString(),
                            Description = row[TBL_COL_Description].ToString(),
                        };
                        cardGroups.Add(cardGroup);
                    }
                    return cardGroups;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(CardGroup cardGroup)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{cardGroup.Name}',N'{cardGroup.Code}',N'{cardGroup.Description}')
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
        public static bool InsertMultyCardGroup(List<CardGroup> cardGroups)
        {
            string insertCMD = $@"INSERT INTO {TBL_NAME}({TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description}) values";
            foreach(CardGroup cardGroup in cardGroups)
            {
                insertCMD += $"('{cardGroup.Name}', '{cardGroup.Code}', '{cardGroup.Description}'),";
            }
            insertCMD = insertCMD.Substring(0,insertCMD.Length - 1);
            if (!Staticpool.mdb.ExecuteCommand(insertCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(insertCMD))
                {
                    return false;
                }
            }
            return true;
        }
        //Modify
        public static bool Modify(CardGroup cardGroup, string ID)
        {
            string updateCMD = $@"UPDATE {TBL_NAME} SET 
                                  {TBL_COL_Name} = N'{cardGroup.Name}',
                                  {TBL_COL_Code} = N'{cardGroup.Code}',
                                  {TBL_COL_Description} = N'{cardGroup.Description}'
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
        public static bool Delete(string cardGroupID)
        {
            string deleteCMD = $@"Delete {TBL_NAME} Where {TBL_COL_ID}='{cardGroupID}'";
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
