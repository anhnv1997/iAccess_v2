using iAccess.Objects.Customers;
using iAccess.Objects.Customers.Cards;
using iAccess.Objects.Devices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iAccess.Databases
{
    public class tblControllerGroup
    {
        public const string TBL_NAME = "tblControllerGroup";
        public const string TBL_COL_ID = "ID";
        public const string TBL_COL_Name = "Name";
        public const string TBL_COL_Code = "Code";
        public const string TBL_COL_Description = "Description";
        public const string TBL_COL_SortOrder = "SortOrder";

        public static string GetCMD = $@"Select {TBL_COL_ID},{TBL_COL_Name},{TBL_COL_Code},{TBL_COL_Description} from {TBL_NAME} order by {TBL_COL_SortOrder}";
        //Get
        public static ControllerGroupCollection LoadDataControllerGroup(ControllerGroupCollection ControllerGroups)
        {
            ControllerGroups.Clear();
            DataTable dtControllerGroup = Staticpool.mdb.FillData(GetCMD);
            if (dtControllerGroup != null)
            {
                if (dtControllerGroup.Rows.Count > 0)
                {
                    foreach (DataRow row in dtControllerGroup.Rows)
                    {
                        ControllerGroup ControllerGroup = new ControllerGroup()
                        {
                            ID = row[TBL_COL_ID].ToString(),
                            Name = row[TBL_COL_Name].ToString(),
                            Code = row[TBL_COL_Code].ToString(),
                            Description = row[TBL_COL_Description].ToString(),
                        };
                        ControllerGroups.Add(ControllerGroup);
                    }
                    return ControllerGroups;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(ControllerGroup controllerGroup)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_Name}, {TBL_COL_Code}, {TBL_COL_Description})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{controllerGroup.Name}',N'{controllerGroup.Code}',N'{controllerGroup.Description}')
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
        public static bool Modify(ControllerGroup controllerGroup, string ID)
        {
            string updateCMD = $@"UPDATE {TBL_NAME} SET 
                                  {TBL_COL_Name} = N'{controllerGroup.Name}',
                                  {TBL_COL_Code} = N'{controllerGroup.Code}',
                                  {TBL_COL_Description} = N'{controllerGroup.Description}'
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
        public static bool Delete(string controllerGroupID)
        {
            string deleteCMD = $@"Delete {TBL_NAME} Where {TBL_COL_ID}='{controllerGroupID}'";
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
